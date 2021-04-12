using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_FPMSZ16
{
    public class FPMS
    {
        public string equipNum;     //设备编号
        public int sectorCount;    //防区个数，默认至少为1
        public int serverPort;    //服务端端口号

        public UDP udpClient;

        public List<SectorInfo> sectorStatus;      //防区状态,可能同时存在多个状态

        public bool manulFlag;
        public bool autoFlag;
        public FPMS()
        {
            sectorCount = 1;
            serverPort = -1;
            sectorStatus = new List<SectorInfo>();
            manulFlag = false;
            autoFlag = false;
        }
    }

    public class SectorInfo
    {
        public string sectorNum;    //防区编号

        public bool intrudeFlag;   //入侵

        public bool touchFlag;   //触碰

        public bool breakFlag;   //破坏
    }

    public enum AlarmType
    {
        Touch = 0,
        Intrude,
        Break
    }

    
}
