using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading;
using System.Timers;

namespace Simulator_FPMSZ16
{
    public partial class Main : Form
    {
        private AddChannel addChannelDlg;
        private Sectors sectorsDlg;
        private Thread send;
        private bool _isRunning;
        private System.Windows.Forms.Timer sendTimer;
        private Dictionary<string, FPMS> existChannelInfos;
        private Dictionary<string, List<SectorInfo>> channelZoneInfos;
        public Main()
        {
            InitializeComponent();
            _isRunning = false;
            sendTimer = new System.Windows.Forms.Timer();
            sendTimer.Interval = 20000;
            sendTimer.Tick += DoJob;
          //  send = new Thread(DoJob);
         //   send.IsBackground = true;
            addChannelDlg = new AddChannel();
            sectorsDlg = new Sectors();
            timer.Start();
            existChannelInfos = new Dictionary<string, FPMS>();
            channelZoneInfos = new Dictionary<string, List<SectorInfo>>();
        }

        private void SendTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Menu_AddChannel_Click(object sender, EventArgs e)
        {
            addChannelDlg.ShowDialog();
        }

        private void Menu_AlarmZone_Click(object sender, EventArgs e)
        {
            sectorsDlg.ShowDialog();
        }

        private void Bt_Start_Click(object sender, EventArgs e)
        {
            int count = 0;
            existChannelInfos = ReadChannelCfg.Create().ExistChannels;
            channelZoneInfos = ReadSectorCfg.Create().ChannelSectorInfos;
            string ip = ipAddressInput.Value;
            if (Bt_Start.Text == "启 动")
            {
                RefreshTableControl(existChannelInfos, channelZoneInfos);
                foreach (KeyValuePair<string, FPMS> kvp in existChannelInfos)
                {
                    if(kvp.Value.serverPort != -1)
                    {
                        kvp.Value.udpClient = new UDP(ip, kvp.Value.serverPort, kvp.Key);
                        kvp.Value.udpClient.StartThread();     //启动线程发送心跳包
                        count++;
                    }
                }
                _isRunning = true;
                sendTimer.Start();                    
                Bt_Start.Text = "停 止";
                label_chanelNums.Text = count.ToString();
            }
            else
            {
                foreach (KeyValuePair<string, FPMS> kvp in existChannelInfos)
                {
                    if (kvp.Value.serverPort != -1 && kvp.Value.udpClient != null)
                    {                        
                        kvp.Value.udpClient.Disconnect();    
                    }
                }
                _isRunning = false;
                sendTimer.Stop();
                Bt_Start.Text = "启 动";                
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelX_Time.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void RefreshTableControl(Dictionary<string, FPMS> ExistChannels, Dictionary<string, List<SectorInfo>> channelZoneInfos)
        {
            Size size = tabControl.Tabs[0].AttachedControl.Size;
            DataGridViewX dgvx = (DataGridViewX)(tabControl.Tabs[0].AttachedControl.Controls[0]);
            tabControl.SuspendLayout();
            this.SuspendLayout();

            tabControl.Tabs.Clear();
            tabControl.TabAlignment = eTabStripAlignment.Top;
            List<int> channelNums = new List<int>();
            foreach (KeyValuePair<string, FPMS> kvp in ReadChannelCfg.Create().ExistChannels)
            {
                if (kvp.Value.serverPort != -1)
                {
                    channelNums.Add(int.Parse(kvp.Key));
                }
            }
            if (channelNums.Count == 0)
            {
                TabItem ti = tabControl.CreateTab("FPMS:1");
                ti.Name = "FPMS:1";
                ti.AttachedControl.Size = size;
                ti.AttachedControl.Dock = DockStyle.Fill;
                ti.AttachedControl.Controls.Add(dgvx);               
            }
            else
            {
                int[] num = channelNums.ToArray();
                Array.Sort(num);
                for (int i = 0; i < channelNums.Count; i++)
                {
                    TabItem ti = tabControl.CreateTab("FPMS:" + num[i]);
                    ti.Name = "FPMS:" + num[i];
                    ti.AttachedControl.Size = size;
                    ti.AttachedControl.Dock = DockStyle.Fill;
                    DataGridViewX dgv = new DataGridViewX();
                    dgv.AllowUserToAddRows = false;
                    dgv.Dock = DockStyle.Fill;
                    dgv.BackgroundColor = dgvx.BackgroundColor;
                    
                    for (int j = 0; j < dgvx.ColumnCount-2; j++)
                    {
                        dgv.Columns.Add(dgvx.Columns[j].Clone() as DataGridViewColumn);
                    }
                    dgv.Columns.Add("4", "手动");
                    dgv.Columns.Add("5", "自动");
                    //更新DataGridView中的行内容
                    List<SectorInfo> sectorinfos = new List<SectorInfo>();                    
                    if(channelZoneInfos.TryGetValue(num[i].ToString(),out sectorinfos))
                    {
                        sectorinfos.Sort((x, y) => int.Parse(x.sectorNum).CompareTo(int.Parse(y.sectorNum)));
                        for (int j = 0;j<sectorinfos.Count;j++)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            dgv.Rows.Add(row);
                            dgv.Rows[j].Cells[0].Value = sectorinfos[j].sectorNum;
                            dgv.Rows[j].Cells[4].Value = "";
                            dgv.Rows[j].Cells[5].Value = "";
                        }
                        //合并单元格                        
                        CheckBox cb = new CheckBox();
                        cb.Parent = dgv;
                        cb.CheckedChanged += Manul;
                        cb.Checked = false;
                        cb.Text = "";
                        cb.BackColor = Color.Transparent;
                        cb.Width = dgv.Columns[4].Width / 2;
                        cb.Location = new Point(480 + dgv.Columns[4].Width / 2, (dgv.Rows[0].Height * dgv.RowCount) / 2 + dgv.Location.Y + 25 / 2);
                        dgv.Controls.Add(cb);
                        CheckBox cb1 = new CheckBox();
                        cb1.Parent = dgv;
                        cb1.CheckedChanged += Auto;
                        cb1.Checked = false;
                        cb1.BackColor = Color.Transparent;
                        cb1.Text = "";
                        cb1.Width = dgv.Columns[5].Width / 2;
                        cb1.Location = new Point(580 + dgv.Columns[5].Width / 2, (dgv.Rows[0].Height * dgv.RowCount) / 2 + dgv.Location.Y + 25 / 2);
                        dgv.Controls.Add(cb1);
                    }
                    dgv.CellContentClick += Dgv_CellContentClick;
                    dgv.CurrentCellDirtyStateChanged += Dgv_CurrentCellDirtyStateChanged;
                    dgv.CellValueChanged += Dgv_CellValueChanged;
                    dgv.RowPostPaint += RowPostPaint;
                    dgv.CellPainting += CellPainting;
                    ti.AttachedControl.Controls.Add(dgv);
                }
            }
            tabControl.ResumeLayout(true);
            this.ResumeLayout(true);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX dgv1 = sender as DataGridViewX;
          //  TabItem tableitemname1 = dgv1.Parent.Parent as TabItem;
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 3)
            {
                DataGridViewX dgv = sender as DataGridViewX;
                string tableitemname = ((DevComponents.DotNetBar.TabControlPanel)(dgv.Parent)).TabItem.Name;
                int index = tableitemname.IndexOf(":");
                string equipnum = tableitemname.Substring(index + 1);
                FPMS equip;

                if(existChannelInfos.TryGetValue(equipnum,out equip))
                {
                    if(equip != null && equip.manulFlag)
                    {
                        if (equip.udpClient != null && equip.udpClient._socket.Connected)
                        {
                            Int16 sectornum = Int16.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                            switch (e.ColumnIndex)
                            {
                                case 1:
                                    equip.udpClient.SendAlarmMessage(Int16.Parse(equipnum), sectornum, AlarmType.Touch);
                                    break;
                                case 2:
                                    equip.udpClient.SendAlarmMessage(Int16.Parse(equipnum), sectornum, AlarmType.Intrude);
                                    break;
                                case 3:
                                    equip.udpClient.SendAlarmMessage(Int16.Parse(equipnum), sectornum, AlarmType.Break);
                                    break;
                            }
                        }
                    }
                    
                }
            }
        }

        private void Auto(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                string equipnum = ((TabControlPanel)(cb.Parent.Parent)).TabItem.Name;
                int index = equipnum.IndexOf(":");
                equipnum = equipnum.Substring(index + 1);
                Dictionary<string, FPMS> existChannelInfos = ReadChannelCfg.Create().ExistChannels;
                if (existChannelInfos.Keys.Contains(equipnum))
                {
                    existChannelInfos[equipnum].manulFlag = false;
                    existChannelInfos[equipnum].autoFlag = true;
                }
                ReadChannelCfg.Create().ExistChannels = existChannelInfos;
                ((CheckBox)cb.Parent.Controls[2]).Checked = false;
            }
        }

        private void Manul(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                string equipnum = ((TabControlPanel)(cb.Parent.Parent)).TabItem.Name;
                int index = equipnum.IndexOf(":");
                equipnum = equipnum.Substring(index + 1);
                Dictionary<string, FPMS> existChannelInfos = ReadChannelCfg.Create().ExistChannels;
                if (existChannelInfos.Keys.Contains(equipnum))
                {
                    existChannelInfos[equipnum].manulFlag = true;
                    existChannelInfos[equipnum].autoFlag = false;
                }
                ReadChannelCfg.Create().ExistChannels = existChannelInfos;
               ((CheckBox)cb.Parent.Controls[3]).Checked = false;
            }
        }

        private void RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridViewX)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 对第5列相同单元格进行合并 
            DataGridViewX dgvx = sender as DataGridViewX;
            
            if ((e.ColumnIndex == 4 || e.ColumnIndex == 5) && e.RowIndex != -1 && dgvx.RowCount > 1)
            {
                using
                (
                Brush gridBrush = new SolidBrush(dgvx.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 清除单元格 
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // 画 Grid 边线（仅画单元格的底边线和右边线） 
                        // 如果下一行和当前行的数据不同，则在当前的单元格画一条底边线 
                        if (e.RowIndex < dgvx.Rows.Count - 1 && 
                        dgvx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() !=
                        e.Value.ToString())
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        //画最后一条记录的底线 
                        if (e.RowIndex == dgvx.Rows.Count - 1)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left + 2,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        // 画右边线 
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                        e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom);

                        // 画左边线 
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                        e.CellBounds.Top, e.CellBounds.Left,
                        e.CellBounds.Bottom);

                        // 画（填写）单元格内容，相同的内容的单元格只填写第一个 
                        if (e.Value != null)
                        {
                            if (e.RowIndex > 0 &&
                            dgvx.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() ==
                            e.Value.ToString())
                            {

                            }
                            else
                            {
                                //e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                //Brushes.Black, e.CellBounds.X + 2,
                                //e.CellBounds.Y + 5, StringFormat.GenericDefault);
                            }
                        }
                        e.Handled = true;
                    }
                }
            }
        }

        private void DoJob(object sender, EventArgs e)
        {
            if(_isRunning)
            {
                string[] equipnums = existChannelInfos.Keys.ToArray();
                for(int i=0;i<equipnums.Length;i++)
                {
                    List<SectorInfo> sectors = channelZoneInfos[equipnums[i]]; 
                    if(existChannelInfos[equipnums[i]].autoFlag)
                    {
                        for(int j=0;j<sectors.Count;j++)
                        {
                            if(sectors[j].touchFlag)
                            {
                                existChannelInfos[equipnums[i]].udpClient.SendAlarmMessage(Int16.Parse(equipnums[i]), Int16.Parse(sectors[j].sectorNum), AlarmType.Touch);
                            }
                            if(sectors[j].intrudeFlag)
                                existChannelInfos[equipnums[i]].udpClient.SendAlarmMessage(Int16.Parse(equipnums[i]), Int16.Parse(sectors[j].sectorNum), AlarmType.Intrude);
                            if(sectors[j].breakFlag)
                                existChannelInfos[equipnums[i]].udpClient.SendAlarmMessage(Int16.Parse(equipnums[i]), Int16.Parse(sectors[j].sectorNum), AlarmType.Break);

                        }
                    }                    
                }
                existChannelInfos = ReadChannelCfg.Create().ExistChannels;
                channelZoneInfos = ReadSectorCfg.Create().ChannelSectorInfos;
                //  Thread.Sleep(30000);
            }
        }


        /// <summary>
        /// 将当前单元格中的更改提交到数据缓存，但不结束编辑模式，及时获得其状态是选中还是未选中    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewX dgv = sender as DataGridViewX;
            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX dgv = sender as DataGridViewX;
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = dgv.CurrentCell.RowIndex;
                    int colIndex = dgv.CurrentCell.ColumnIndex;
                    bool flag = false;
                    if (colIndex == 4) //第4列
                    {
                        colIndex += 1;
                        flag = true;
                    }
                    else if(colIndex == 5)
                    {
                        colIndex -= 1;
                        flag = true;
                    }
                    if (flag)
                    {
                        string _selectValue = dgv.CurrentCell.EditedFormattedValue.ToString();
                        if (_selectValue == "True")
                        {
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                if (i != rowIndex)
                                {
                                    

                                }
                                string otherValue = dgv.Rows[i].Cells[colIndex].EditedFormattedValue.ToString();
                                if (otherValue == "True")
                                {
                                    ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[colIndex]).Value = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

    }
}
