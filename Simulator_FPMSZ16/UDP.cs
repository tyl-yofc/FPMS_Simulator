using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Simulator_FPMSZ16
{
    public class UDP
    {
        public Socket client;
        private IPEndPoint endPoint;
        private bool _isRunning;
        private string equipNum;
        byte[] heart;

        public UDP(string ipaddress, int port,string equipnum)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _isRunning = false;
            endPoint = new IPEndPoint(IPAddress.Parse(ipaddress), port);
            equipNum = equipnum;
            heart = new byte[6];
            BitConverter.GetBytes(Int16.Parse(equipNum) - 1).Reverse().ToArray().CopyTo(heart, 0);
            for (int i =2; i < heart.Length; i++)
                heart[i] = 0xaa;
        }

        public void Connect()
        {
            try
            {
                client.Connect(endPoint);

                Thread t = new Thread(DoJob);
                _isRunning = true;
                t.Start();
            }
            catch(Exception ex)
            {

            }
        }

        public void DisConnect()
        {
            _isRunning = false;
            try
            {
                if(client!= null && client.Connected)
                {
                    client.Close();
                    client = null;
                }

            }
            catch(Exception ex)
            {

            }
            
        }

        public void DoJob()
        {
            while (_isRunning)
            {
                if(client.Connected)
                {
                    //发送心跳包
                    if(heart != null)
                    {
                        string heart = "00";
                        if (Int16.Parse(equipNum) - 1 < 10)
                            heart += "0"+ (Int16.Parse(equipNum) - 1).ToString() + "aaaaaaaa";
                        else
                            heart += (Int16.Parse(equipNum) - 1).ToString() + "aaaaaaaa";                        

                        client.Send(System.Text.Encoding.Default.GetBytes(heart));
                    }
                       // client.Send(heart);
                    Thread.Sleep(5000);
                }
            }
        }

        public void SendAlarmMessage(Int16 equipnum, Int16 sectornum,AlarmType alarmtype)
        {
            if(client.Connected)
            {
                byte[] sendmessage = new byte[6];
              //  BitConverter.GetBytes(equipnum - 1).Reverse().ToArray().CopyTo(sendmessage, 0);
              //  BitConverter.GetBytes(sectornum - 1).Reverse().ToArray().CopyTo(sendmessage, 4);
                string value = "";
                if(alarmtype == AlarmType.Touch)
                {
                    value = "0000";
                }
                else if(alarmtype == AlarmType.Intrude)
                {
                    value = "0001";
                }
                else if(alarmtype == AlarmType.Break)
                {
                    value = "0002";
                }
                if (value != "")
                {
                    string alarm = "00";
                    if ((equipnum - 1) < 10)
                        alarm += "0" + (equipnum - 1).ToString() + "00";
                    else
                        alarm += (equipnum - 1).ToString() + "00";

                    if ((sectornum - 1) < 10)
                        alarm += "0" + (sectornum - 1).ToString();
                    else
                        alarm += (sectornum - 1).ToString();

                    alarm += value;
                    //    BitConverter.GetBytes(value).Reverse().ToArray().CopyTo(sendmessage, 8);
                    client.Send(System.Text.Encoding.Default.GetBytes(alarm));
                }
            }
        }
    }
}
