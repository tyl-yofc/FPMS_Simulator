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
        public Socket _socket;
        private IPEndPoint endPoint;
        private bool _isRunning;
        private string equipNum;
        private bool _isConnected;
        private bool _stopThread;
        private Thread _connectServer;
       // public Socket _socket;
        private Thread _sendHeart;
        byte[] heart;

        public UDP(string ipaddress, int port,string equipnum)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _isRunning = false;
            endPoint = new IPEndPoint(IPAddress.Parse(ipaddress), port);
            _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            equipNum = equipnum;
            heart = new byte[6];
            BitConverter.GetBytes(Int16.Parse(equipNum) - 1).Reverse().ToArray().CopyTo(heart, 0);
            for (int i =2; i < heart.Length; i++)
                heart[i] = 0xaa;

            _connectServer = new Thread(Connect);
            _sendHeart = new Thread(DoJob);
        }
        public void StartThread()
        {
            _isConnected = false;
            _stopThread = false;
            _connectServer.Start();
        }

        private void StopThread()
        {
            _isConnected = false;
            _stopThread = true;
            if (_connectServer != null)
                _connectServer.Abort();
        }

        public void Connect()
        {
            while (!_stopThread)
            {
                if (_isConnected)
                    return;

               // IPEndPoint endPoint = new IPEndPoint(_remoteIP, _remotePort);
               
                try
                {
                    _socket.Connect(endPoint);
                }
                catch (SocketException ex)
                {
                    if (_socket?.Connected ?? false) _socket.Shutdown(SocketShutdown.Both);
                    _socket?.Close();
                }
                if (_socket.Connected)
                {
                    _isConnected = true;
                    _sendHeart.Start();
                    return;
                }
                Thread.Sleep(1000);
            }
        }

        public void Disconnect()
        {
            if (_isConnected)
            {
                try
                {
                    if (_socket?.Connected ?? false) _socket.Shutdown(SocketShutdown.Both);
                    _socket?.Close();
                }
                catch (ObjectDisposedException) { }
            }
            StopThread();
        }

        public void Reconnect()
        {
           // IPEndPoint endPoint = new IPEndPoint(_remoteIP, _remotePort);
            try
            {
                if (_socket == null)
                {
                    _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    _socket.Connect(endPoint);
                }
                else if (!_socket.Connected)
                {
                    _socket.Close();
                    _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    _socket.Connect(endPoint);
                }
            }
            catch (Exception ex) { }
        }

        /*
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
 */
        public void DoJob()
        {
            while (true)
            {
                if (_socket != null && _socket.Connected && heart != null)
                {
                    try
                    {
                        string heart = "00";
                        if (Int16.Parse(equipNum) - 1 < 10)
                            heart += "0" + (Int16.Parse(equipNum) - 1).ToString() + "aaaaaaaa";
                        else
                            heart += (Int16.Parse(equipNum) - 1).ToString() + "aaaaaaaa";

                        _socket.Send(System.Text.Encoding.Default.GetBytes(heart));
                    }
                    catch (Exception ex)
                    {
                        Reconnect();
                    }
                }
                else if (_stopThread)
                    return;
                else
                {
                    Reconnect();
                }
                Thread.Sleep(5000);
            }            
        }

        public void SendAlarmMessage(Int16 equipnum, Int16 sectornum,AlarmType alarmtype)
        {
            if(_socket != null && _socket.Connected)
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
                    _socket.Send(System.Text.Encoding.Default.GetBytes(alarm));
                }
            }
            else if (_stopThread)
                return;
            else
            {
                Reconnect();
            }
        }
    }
}
