using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Collections;

namespace Simulator_FPMSZ16
{
    public partial class AddChannel : Form
    {

        private Dictionary<string, FPMS> existChannels;   //利用ChannelInfos的Flag判断该通道是否有效
        private UInt16 DefaultSectorCount = 1; //默认防区个数

        internal Dictionary<string, FPMS> ExistChannels { get => existChannels; set => existChannels = value; }
        public AddChannel()
        {            
            InitializeComponent();

            //根据ChannelCfg文件初始化            
            ExistChannels = new Dictionary<string, FPMS>();
        }     
        
        private void AddChannel_Load(object sender, EventArgs e)
        {
            ExistChannels = ReadChannelCfg.Create().ExistChannels;
            int rowindex = ExistChannels.Count;
           
            DGV_ChannelInfo.RowCount = rowindex;

            rowindex = 0;
            foreach (KeyValuePair<string, FPMS> kvp in ExistChannels)
            {
                DGV_ChannelInfo.Rows[rowindex].Cells[0].Value = kvp.Key;
                DGV_ChannelInfo.Rows[rowindex].Cells[1].Value = kvp.Value.sectorCount;
                DGV_ChannelInfo.Rows[rowindex].Cells[2].Value = kvp.Value.serverPort;
                rowindex++;
            }            
        }
        
        /// <summary>
        /// 序号列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_ChannelInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridViewX)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_AddRow_Click(object sender, EventArgs e)
        {
           DGV_ChannelInfo.Rows.Add();
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_RemoveRow_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < DGV_ChannelInfo.RowCount; i++)
            {
                if ((string)DGV_ChannelInfo.Rows[i].Cells[0].Value != "" && (string)DGV_ChannelInfo.Rows[i].Cells[0].Value != null)
                    num++;
            }

            if ((string)DGV_ChannelInfo.CurrentRow.Cells[0].Value != "" && (string)DGV_ChannelInfo.CurrentRow.Cells[0].Value != null)
            {                
                if ( num > 1)
                {
                    string msg = "确定需要删除主机" + DGV_ChannelInfo.CurrentRow.Cells[0].Value + " 吗？";
                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == 1)
                    {
                        DGV_ChannelInfo.Rows.Remove(DGV_ChannelInfo.CurrentRow);
                    }
                }
            }
            else
                DGV_ChannelInfo.Rows.Remove(DGV_ChannelInfo.CurrentRow);
        }

        /// <summary>
        /// 保存DataGridView中的通道信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Save_Click(object sender, EventArgs e)
        {
            List<string> newkeys = new List<string>();
           
            for (int i=0;i<DGV_ChannelInfo.RowCount;i++)
            {
                string equipnum = (string)DGV_ChannelInfo.Rows[i].Cells[0].Value;
                if (equipnum != null && int.Parse(equipnum) > 0)
                {
                    if (!newkeys.Contains(equipnum))
                        newkeys.Add(equipnum);
                    //更新通道信息
                    if (ExistChannels.Keys.Contains(equipnum))
                    {
                        if (DGV_ChannelInfo.Rows[i].Cells[1].Value == null || DGV_ChannelInfo.Rows[i].Cells[1].Value == "")
                            ExistChannels[equipnum].sectorCount = DefaultSectorCount;      //默认
                        else
                            ExistChannels[equipnum].sectorCount = Convert.ToInt16(DGV_ChannelInfo.Rows[i].Cells[1].Value);

                        if (DGV_ChannelInfo.Rows[i].Cells[2].Value == null || DGV_ChannelInfo.Rows[i].Cells[2].Value == "")
                            ExistChannels[equipnum].serverPort = -1;      //默认
                        else
                            ExistChannels[equipnum].serverPort = Convert.ToInt32(DGV_ChannelInfo.Rows[i].Cells[2].Value);
                    }
                    else
                    {
                        //新增通道
                        FPMS channelInfos = new FPMS();
                        if (DGV_ChannelInfo.Rows[i].Cells[1].Value == null || DGV_ChannelInfo.Rows[i].Cells[1].Value == "")
                            channelInfos.sectorCount = DefaultSectorCount;      //默认
                        else if (int.Parse(DGV_ChannelInfo.Rows[i].Cells[1].Value.ToString()) > 16)
                            channelInfos.sectorCount = 16;
                        else
                            channelInfos.sectorCount = int.Parse(DGV_ChannelInfo.Rows[i].Cells[1].Value.ToString());

                        if (DGV_ChannelInfo.Rows[i].Cells[2].Value == null || DGV_ChannelInfo.Rows[i].Cells[2].Value == "")
                            channelInfos.serverPort = -1;      //默认
                        else
                            channelInfos.serverPort = Convert.ToInt32(DGV_ChannelInfo.Rows[i].Cells[2].Value);

                        ExistChannels.Add(equipnum, channelInfos);
                    }
                }
            }         
           

            Dictionary<string, List<SectorInfo>> channelsectorinfos = ReadSectorCfg.Create().ChannelSectorInfos;
            foreach (KeyValuePair<string,FPMS> kvp in ExistChannels)
            {                
                int newsectorcount = kvp.Value.sectorCount;               
                if (channelsectorinfos.Keys.Contains(kvp.Key))
                {
                    int oldsectorcount = channelsectorinfos[kvp.Key].Count;
                    int[] sectors = new int[17];
                    for (int j = 0; j < oldsectorcount; j++)
                    {
                        int temp = int.Parse(channelsectorinfos[kvp.Key][j].sectorNum);
                        for(int i=1;i<sectors.Length;i++)
                        {
                            if (i == temp)
                            {
                                sectors[i] = temp;
                                break;
                            }
                        }
                        
                       // sectornums.Add(int.Parse(channelsectorinfos[kvp.Key][j].sectorNum));
                    }
                    if (newsectorcount > 16)
                        newsectorcount = 16;
                    if (newsectorcount > oldsectorcount)
                    {
                        int index = 1;
                        for (int i = 1; i <= newsectorcount - oldsectorcount; i++)
                        {
                            for(int j=index;j< sectors.Length;j++)
                            {
                                if (sectors[j] == 0)
                                {
                                    sectors[j] = j;
                                    SectorInfo temp = new SectorInfo();                                    
                                    temp.sectorNum = j.ToString();
                                    temp.touchFlag = false;
                                    temp.intrudeFlag = false;
                                    temp.breakFlag = false;
                                    channelsectorinfos[kvp.Key].Add(temp);
                                    index = j + 1;
                                    break;
                                }
                                    
                            }
                        }
                    }
                    else if(newsectorcount < oldsectorcount)
                    {
                        channelsectorinfos[kvp.Key].RemoveRange(0, oldsectorcount - newsectorcount);
                    }
                }
                else
                {
                    List<SectorInfo> sectorinfos = new List<SectorInfo>();
                    for (int j = 1; j <= newsectorcount; j++)
                    {
                        SectorInfo temp = new SectorInfo();
                        temp.sectorNum = j.ToString();
                        temp.touchFlag = false;
                        temp.intrudeFlag = false;
                        temp.breakFlag = false;
                        sectorinfos.Add(temp);
                    }
                    channelsectorinfos.Add(kvp.Key, sectorinfos);
                }
            }
            //删除字典中多余的主机
            if (newkeys.Count > 0)
            {
                string[] oldkeys = ExistChannels.Keys.ToArray();
                string[] oldkeys1 = channelsectorinfos.Keys.ToArray();
                string[] dif = oldkeys.Except(newkeys).ToArray();
                string[] dif1 = oldkeys1.Except(newkeys).ToArray();
                if (dif.Length > 0)
                {
                    for (int i = 0; i < dif.Length; i++)
                    {
                        ExistChannels.Remove(dif[i]);
                    }
                }
                if (dif1.Length > 0)
                {
                    for (int i = 0; i < dif1.Length; i++)
                    {
                        channelsectorinfos.Remove(dif1[i]);
                    }
                }

                ReadChannelCfg.Create().ExistChannels = ExistChannels;
                ReadSectorCfg.Create().ChannelSectorInfos = channelsectorinfos;
                ReadSectorCfg.Create().SetValue(channelsectorinfos);
            }

            
            this.Close();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void DGV_ChannelInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewX grid = (DataGridViewX)sender;
            TextBox tx = e.Control as TextBox;

            tx.KeyPress += new KeyPressEventHandler(tx_KeyPress1);
                               
        }
        private void tx_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//允许输入退格键 
            {
                int len = ((TextBox)sender).Text.Length;
                if (len < 1 && e.KeyChar == '0')
                    e.Handled = true;
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//允许输入0-9数字                 
                    e.Handled = true;
            }                
       }
        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //允许输入数字、小数点、删除键
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.'))
                e.Handled = true;  
            //小数点只能输入一次
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
                e.Handled = true;
            if(e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
                e.Handled = true;
            //第一位是0，第二位必须为小数点
            if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
                e.Handled = true;
        }

        private void AddChannel_FormClosed(object sender, FormClosedEventArgs e)
        {
            //更新配置文件
            ReadChannelCfg.Create().SetValue(ExistChannels);
        }

    }
}
