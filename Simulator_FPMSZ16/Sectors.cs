using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Simulator_FPMSZ16
{
    public partial class Sectors : Form
    {
        public Dictionary<string, List<SectorInfo>> ChannelZoneInfos;   //key为设备编号,value为该通道下的防区信息

        private string oldEquipNum;

        private Dictionary<string, FPMS> existChannels;   //利用ChannelInfos
        internal Dictionary<string, FPMS> ExistChannels { get => existChannels; set => existChannels = value; }
        public Sectors()
        {
            InitializeComponent();      
        }
        private void AlarmZones_Load(object sender, EventArgs e)
        {
            ExistChannels = ReadChannelCfg.Create().ExistChannels;
            ChannelZoneInfos = ReadSectorCfg.Create().ChannelSectorInfos;
            cmb_ChooseChannel.Items.Clear();
            foreach (KeyValuePair<string, FPMS> kvp in ExistChannels)
            {          
                cmb_ChooseChannel.Items.Add("FPMS：" + kvp.Key);
            }
            if (cmb_ChooseChannel.Items.Count > 0)
            {
                cmb_ChooseChannel.SelectedIndex = 0;
                int index = cmb_ChooseChannel.SelectedItem.ToString().IndexOf("：");
                oldEquipNum = cmb_ChooseChannel.SelectedItem.ToString().Substring(index + 1);
            }
            /*
            int count = ExistChannels.Count;
            string[] keys = ExistChannels.Keys.ToArray();
            if (ChannelZoneInfos.Count == 0)
            {                
                for(int i = 0;i<count;i++)
                {
                    int sectorcount = ExistChannels[keys[i]].sectorCount;
                    if (sectorcount > 0)
                    {
                        List<SectorInfo> sectorinfos = new List<SectorInfo>();
                        for (int j = 0; j < sectorcount; j++)
                        {
                            SectorInfo temp = new SectorInfo();
                            temp.sectorNum = j.ToString();
                            temp.touchFlag = false;
                            temp.intrudeFlag = false;
                            temp.breakFlag = false;
                            sectorinfos.Add(temp);
                        }

                        if (ChannelZoneInfos.Keys.Contains(keys[i]))
                            ChannelZoneInfos[keys[i]] = sectorinfos;
                        else
                            ChannelZoneInfos.Add(keys[i], sectorinfos);
                    }
                }
            }
            else
            {
                for(int i = 0; i < count; i++)
                {
                    int sectorcount = ExistChannels[keys[i]].sectorCount;
                    if(ChannelZoneInfos.Keys.Contains(keys[i]))
                    {
                        int counts = ChannelZoneInfos[keys[i]].Count;
                        List<int> sectornums = new List<int>();
                        for(int j=0;j<counts;j++)
                        {
                            sectornums.Add(int.Parse(ChannelZoneInfos[keys[i]][j].sectorNum));
                        }
                        if (counts < sectorcount)
                        {
                            Random r = new Random();
                            for (int j = 1;j<=sectorcount - counts;j++)
                            {
                                SectorInfo temp = new SectorInfo();
                                int value = r.Next(1, 16);
                                while(sectornums.Contains(value))
                                {
                                    value = r.Next(1, 16);
                                }
                                temp.sectorNum = value.ToString();
                                temp.touchFlag = false;
                                temp.intrudeFlag = false;
                                temp.breakFlag = false;
                                ChannelZoneInfos[keys[i]].Add(temp);
                                sectornums.Add(value);
                            }
                        }
                        else if(ChannelZoneInfos[keys[i]].Count > sectorcount)
                        {
                            ChannelZoneInfos[keys[i]].RemoveRange(0, ChannelZoneInfos[keys[i]].Count - sectorcount);
                        }
                    }
                    else
                    {
                        List<SectorInfo> sectorinfos = new List<SectorInfo>();
                        for (int j = 1; j <= sectorcount; j++)
                        {
                            SectorInfo temp = new SectorInfo();
                            temp.sectorNum = j.ToString();
                            temp.touchFlag = false;
                            temp.intrudeFlag = false;
                            temp.breakFlag = false;
                            sectorinfos.Add(temp);
                        }
                        ChannelZoneInfos.Add(keys[i], sectorinfos);
                    }                    
                }
            }*/


            foreach (KeyValuePair<string, List<SectorInfo>> kvp in ChannelZoneInfos)
            {
                int index = cmb_ChooseChannel.SelectedItem.ToString().IndexOf("：");
                string equipnum = ((string)cmb_ChooseChannel.SelectedItem).Substring(index + 1);
                if (kvp.Key.Contains(equipnum))
                {
                    DGV_ZoneInfos.RowCount = ChannelZoneInfos[kvp.Key].Count;
                    List<SectorInfo> sectors = kvp.Value;
                    sectors.Sort((x, y) => int.Parse(x.sectorNum).CompareTo(int.Parse(y.sectorNum))); 
                    for (int i = 0; i < kvp.Value.Count; i++)
                    {
                        DGV_ZoneInfos.Rows[i].Cells[0].Value = sectors[i].sectorNum;
                        DGV_ZoneInfos.Rows[i].Cells[1].Value = sectors[i].touchFlag;
                        DGV_ZoneInfos.Rows[i].Cells[2].Value = sectors[i].intrudeFlag;
                        DGV_ZoneInfos.Rows[i].Cells[3].Value = sectors[i].breakFlag;
                    }
                }
            }
            DGV_ZoneInfos.Columns[0].ReadOnly = true;


        }            
        private void cmb_ChooseChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //切换通道前需要保存当前通道所有防区信息
            int index = cmb_ChooseChannel.SelectedItem.ToString().IndexOf("：");
            string num = cmb_ChooseChannel.SelectedItem.ToString().Substring(index + 1);
            if (oldEquipNum != null && num != oldEquipNum)
            {
                List<SectorInfo> channelZones = new List<SectorInfo>();
                for (int i = 0; i < DGV_ZoneInfos.RowCount; i++)
                {
                    SectorInfo zonetempinfo = new SectorInfo();
                    zonetempinfo.sectorNum = DGV_ZoneInfos.Rows[i].Cells[0].Value.ToString();
                    zonetempinfo.touchFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[1].Value.ToString());
                    zonetempinfo.intrudeFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[2].Value.ToString());
                    zonetempinfo.breakFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[3].Value.ToString());
                    if (int.Parse(zonetempinfo.sectorNum) < 16)
                        channelZones.Add(zonetempinfo);
                }
                if (ChannelZoneInfos.Keys.Contains(oldEquipNum))
                {
                    ChannelZoneInfos[oldEquipNum] = channelZones;
                }
                else
                    ChannelZoneInfos.Add(oldEquipNum, channelZones);

                oldEquipNum = cmb_ChooseChannel.SelectedItem.ToString().Substring(index + 1);

                //更新Datagridview
                DGV_ZoneInfos.Rows.Clear();
                DGV_ZoneInfos.RowCount = ChannelZoneInfos[oldEquipNum].Count;
                for(int i=0;i<DGV_ZoneInfos.RowCount;i++)
                {
                    DGV_ZoneInfos.Rows[i].Cells[0].Value = ChannelZoneInfos[oldEquipNum][i].sectorNum;
                    DGV_ZoneInfos.Rows[i].Cells[1].Value = ChannelZoneInfos[oldEquipNum][i].touchFlag;
                    DGV_ZoneInfos.Rows[i].Cells[2].Value = ChannelZoneInfos[oldEquipNum][i].intrudeFlag;
                    DGV_ZoneInfos.Rows[i].Cells[3].Value = ChannelZoneInfos[oldEquipNum][i].breakFlag;
                }
            }           
        }

        private void DGV_ZoneInfos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridViewX)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
               // e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void AlarmZones_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保持当前通道的防区信息   
            List<SectorInfo> channelZones = new List<SectorInfo>();
            for (int i = 0; i < DGV_ZoneInfos.RowCount; i++)
            {
                SectorInfo zonetempinfo = new SectorInfo();
                zonetempinfo.sectorNum = DGV_ZoneInfos.Rows[i].Cells[0].Value.ToString();
                zonetempinfo.touchFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[1].Value.ToString());
                zonetempinfo.intrudeFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[2].Value.ToString());
                zonetempinfo.breakFlag = bool.Parse(DGV_ZoneInfos.Rows[i].Cells[3].Value.ToString());
                if (int.Parse(zonetempinfo.sectorNum) < 16)
                    channelZones.Add(zonetempinfo);
            }
            if (ChannelZoneInfos.Keys.Contains(oldEquipNum))
            {
                ChannelZoneInfos[oldEquipNum] = channelZones;
            }
            else
                ChannelZoneInfos.Add(oldEquipNum, channelZones);

            int index = cmb_ChooseChannel.SelectedItem.ToString().IndexOf("：");
            oldEquipNum = cmb_ChooseChannel.SelectedItem.ToString().Substring(index + 1);

            //更新配置文件            
            ReadSectorCfg.Create().SetValue(ChannelZoneInfos);
        }
    }
}
