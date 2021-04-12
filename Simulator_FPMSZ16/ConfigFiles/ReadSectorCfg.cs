using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Simulator_FPMSZ16
{
    class ReadSectorCfg
    {
        private readonly FileSystemWatcher _fsw;
        public object obj;        
        private string ConfigPath;
        private Dictionary<string, List<SectorInfo>> channelSectorInfos;
        internal Dictionary<string, List<SectorInfo>> ChannelSectorInfos { get => channelSectorInfos; set => channelSectorInfos = value; }


        private static ReadSectorCfg _instance;
        public static ReadSectorCfg Create()
        {
            return _instance ?? (_instance = new ReadSectorCfg());
        }       
        public ReadSectorCfg()
        {
            obj = new object();
            // ConfigPath = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName + "\\ConfigFiles\\";
            ConfigPath = System.Environment.CurrentDirectory + "\\";
            ChannelSectorInfos = new Dictionary<string, List<SectorInfo>>();
            LoadOption();

            if (_fsw == null)
            {
                _fsw = new FileSystemWatcher
                {
                    Path = ConfigPath,
                    Filter = "SectorCfg.config",
                    NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.Attributes
                };
                _fsw.Changed += new FileSystemEventHandler(FswChanged);
                _fsw.EnableRaisingEvents = true;
            }
        }

        public void LoadOption()
        {
            string ConfigFilePath = ConfigPath + "SectorCfg.config";
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = ConfigFilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                string value = GetIndexConfigValue(key);
                if (value.Length >= 1)
                {
                    int channelNum = -1;
                    if (key.Contains('_')) //设备编号_防区信息
                    {
                        string equipnum = key.Split('_')[0].Trim();
                        string sectornum = key.Split('_')[1].Trim();
                        if (!ChannelSectorInfos.Keys.Contains(equipnum))   //集合中有该通道信息
                        {
                            List<SectorInfo> sectortempinfo = new List<SectorInfo>();
                            ChannelSectorInfos.Add(equipnum, sectortempinfo);
                        }

                        //判断该通道是否包含配置文件中的防区信息    
                        int count = ChannelSectorInfos[equipnum].Count;
                        bool flag = false;
                        
                        for(int i=0;i<count;i++)
                        {
                            if(ChannelSectorInfos[equipnum][i].sectorNum.ToString() == sectornum)
                            {                                
                                string[] values = value.Split(';');
                                for (int j = 0; j < values.Length; j++)
                                {
                                    SectorInfo sectorinfo = ChannelSectorInfos[equipnum][i];
                                    string[] temp = values[j].Split('=');
                                    if (temp.Length >= 1)
                                    {
                                        if (temp[0].Trim().ToLower().Contains("touch"))
                                            sectorinfo.touchFlag = bool.Parse(temp[1].Trim().ToString());
                                        else if (temp[0].Trim().ToLower().Contains("intrude"))
                                            sectorinfo.intrudeFlag = bool.Parse(temp[1].Trim().ToString());
                                        else if (temp[0].Trim().ToLower().Contains("break"))
                                            sectorinfo.breakFlag = bool.Parse(temp[1].Trim().ToString());
                                    }
                                    sectorinfo.sectorNum = sectornum;
                                    ChannelSectorInfos[equipnum][i] = sectorinfo;
                                }
                                flag = true;
                                break;
                            }
                        }
                        if(!flag)
                        {
                            SectorInfo sectorinfo = new SectorInfo();
                            sectorinfo.sectorNum = sectornum;
                            string[] values = value.Split(';');
                            for (int j = 0; j < values.Length; j++)
                            {
                                string[] temp = values[j].Split('=');
                                if (temp.Length >= 1)
                                {
                                    if (temp[0].Trim().ToLower().Contains("touch"))
                                        sectorinfo.touchFlag = bool.Parse(temp[1].Trim().ToString());
                                    else if (temp[0].Trim().ToLower().Contains("intrude"))
                                        sectorinfo.intrudeFlag = bool.Parse(temp[1].Trim().ToString());
                                    else if (temp[0].Trim().ToLower().Contains("break"))
                                        sectorinfo.breakFlag = bool.Parse(temp[1].Trim().ToString());
                                }
                            }
                            ChannelSectorInfos[equipnum].Add(sectorinfo);
                        }
                     }
                }
            }            
        }

        public string GetIndexConfigValue(string key)
        {
            string flag = "";
            string indexConfigPath = ConfigPath + "SectorCfg.config";
            if (string.IsNullOrEmpty(indexConfigPath))
                return flag = "-1";//配置文件为空
            if (!File.Exists(indexConfigPath))
                return flag = "-1";//配置文件不存在

            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = indexConfigPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            try
            {
                flag = config.AppSettings.Settings[key].Value;
            }
            catch (Exception)
            {
                flag = "-2";
            }
            return flag;
        }

        private void FswChanged(object sender, FileSystemEventArgs e)
        {
            if (String.Compare(e.Name, "SectorCfg.config", StringComparison.OrdinalIgnoreCase) != 0) return;
            try
            {
                FileSystemWatcher watcher = (FileSystemWatcher)sender;
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    Thread th = new Thread(new ThreadStart(delegate ()
                    {
                        Thread.Sleep(1000);
                        watcher.EnableRaisingEvents = true;
                    }));
                    th.Start();
                   // LoadOption();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void SetValue(Dictionary<string,List<SectorInfo>> channelsectorinfos)
        {
            //更新ChannelCfg配置文件 
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = ConfigPath + "SectorCfg.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            foreach (string key1 in config.AppSettings.Settings.AllKeys)
                config.AppSettings.Settings.Remove(key1);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件  

            foreach (KeyValuePair<string, List<SectorInfo>> kvp in channelsectorinfos)
            {
                if (kvp.Value != null)
                {
                    int count = kvp.Value.Count;                    
                    for (int i = 0; i < count; i++)
                    {
                        string value = "Touch = " + kvp.Value[i].touchFlag.ToString() + "; Intrude =" + kvp.Value[i].intrudeFlag.ToString() + "; Break = " + kvp.Value[i].breakFlag.ToString() + ";";
                        string key = kvp.Key + "_" + kvp.Value[i].sectorNum;
                        if (config.AppSettings.Settings[key] == null)
                            config.AppSettings.Settings.Add(key, value);
                        else
                            config.AppSettings.Settings[key].Value = value;
                    }                        
                }
            }                  
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件   
        }
    }
}
