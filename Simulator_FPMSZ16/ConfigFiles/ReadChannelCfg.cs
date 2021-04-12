using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Simulator_FPMSZ16
{
    public class ReadChannelCfg
    {
        private static ReadChannelCfg _instance;
        public static ReadChannelCfg Create()
        {
            return _instance ?? (_instance = new ReadChannelCfg());
        }
        private readonly FileSystemWatcher _fsw;
        public object obj;
        private Dictionary<string, FPMS> existChannels;       //配置的设备，key为主机编号

        private string ConfigPath;

        internal Dictionary<string, FPMS> ExistChannels { get => existChannels; set => existChannels = value; }

        public ReadChannelCfg()
        {
            obj = new object();
            // ConfigPath = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName + "\\ConfigFiles\\";
            ConfigPath = System.Environment.CurrentDirectory + "\\";
            ExistChannels = new Dictionary<string, FPMS>();
            LoadOption();

            if (_fsw == null)
            {
                _fsw = new FileSystemWatcher
                {
                    Path = ConfigPath,
                    Filter = "ChannelCfg.config",
                    NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.Attributes
                };
                _fsw.Changed += new FileSystemEventHandler(FswChanged);
                _fsw.EnableRaisingEvents = true;
            }
        }

        private void LoadOption()
        {
            string ConfigFilePath = ConfigPath + "ChannelCfg.config";
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = ConfigFilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                string value = GetIndexConfigValue(key);
                if (value.Length >= 1)
                {
                    string[] values = value.Split(';');
                    if (values.Length >= 1)
                    {
                        FPMS channelInfo = new FPMS();
                        if (ExistChannels.TryGetValue(key, out channelInfo))   //字典中有该分区，直接用新的值替换
                        {
                            //更新该通道的ChannelInfos
                            for (int i = 0; i < values.Length; i++)
                            {
                                string[] temp = values[i].Split('=');
                                if (temp.Length > 1)
                                {
                                    if (temp[0].Trim().ToLower().Contains("sectorcount"))
                                        channelInfo.sectorCount = ushort.Parse(temp[1]);    
                                    if(temp[0].Trim().ToLower().Contains("port"))
                                        channelInfo.serverPort = int.Parse(temp[1]);
                                }
                            }
                        }
                        else
                        {
                            channelInfo = new FPMS();
                            channelInfo.equipNum = key;
                            //新增该通道的ChannelInfos
                            for (int i = 0; i < values.Length; i++)
                            {
                                string[] temp = values[i].Split('=');
                                if (temp.Length > 1)
                                {
                                    if (temp[0].Trim().ToLower().Contains("sectorcount"))
                                        channelInfo.sectorCount = ushort.Parse(temp[1]);
                                    if (temp[0].Trim().ToLower().Contains("port"))
                                        channelInfo.serverPort = int.Parse(temp[1]);
                                }
                            }
                            ExistChannels.Add(key, channelInfo);
                        }
                    }          
                }
            }
        }

        public string GetIndexConfigValue(string key)
        {
            string flag = "";
            string indexConfigPath = ConfigPath + "ChannelCfg.config";
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
            if (String.Compare(e.Name, "ChannelCfg.config", StringComparison.OrdinalIgnoreCase) != 0) return;
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
                    LoadOption();                    
                }
            }
            catch (Exception ex)
            {                
            }
        }

        public void SetValue(Dictionary<string,FPMS> existChannels)
        {
            //更新ChannelCfg配置文件 
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = ConfigPath + "ChannelCfg.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            string[] fileKeys = config.AppSettings.Settings.AllKeys;
            List<string> newkeys = new List<string>();
            foreach(KeyValuePair<string, FPMS> kvp in existChannels)
            {
                newkeys.Add(kvp.Key);
            }
            //更新文件中已有的键值对
            for(int i=0; i<newkeys.Count;i++)
            {
                string value = "SectorCount = " + existChannels[newkeys[i]].sectorCount + ";" + "Port = " + existChannels[newkeys[i]].serverPort + ";";
                if (((IList)fileKeys).Contains(newkeys[i]))
                    config.AppSettings.Settings[newkeys[i]].Value = value;
                else                
                    config.AppSettings.Settings.Add(newkeys[i], value);                
            }
            //删除文件中多余的键值对
            string[] delectkey = fileKeys.Except(newkeys).ToArray();
            if(delectkey != null)
            {
                for(int i = 0;i<(delectkey.Length);i++)               
                    config.AppSettings.Settings.Remove(delectkey[i]);                
            }
            
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件   
        }


    }
}
