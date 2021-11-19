using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.utils.TCP
{
    class TCPClinet
    {
        private Socket _socket;
        private SocketAsyncEventArgs _eventArgs;
        private byte[] receiveBuffer = new byte[2048];


        //创建事件委托实例
        public EventHandler<TCPClinet> AcceptWith;
        public EventHandler<TCPClinet> ReceiveWith;
        public EventHandler<TCPClinet> AutoReConnectWith;

        public TCPClinet()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _eventArgs = new SocketAsyncEventArgs();
            _eventArgs.Completed += ReceiveArgs_Saga;
            _eventArgs.SetBuffer(receiveBuffer, 0, 2048);
        }

        public TCPClinet(Socket socket)
        {
            _socket = socket;
            _eventArgs = new SocketAsyncEventArgs();
            _eventArgs.Completed += ReceiveArgs_Saga;
            _eventArgs.SetBuffer(receiveBuffer, 0, 2048);
        }

        private void ReceiveArgs_Saga(object sender,SocketAsyncEventArgs e)
        {
            switch(e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    AcceptWith?.Invoke(this,new TCPClinet(e.AcceptSocket));
                    break;
                case SocketAsyncOperation.Receive:
                    int echoLength = e.BytesTransferred;
                    if(echoLength != 0)
                    {
                        string msg = Encoding.Default.GetString(e.Buffer, 0, echoLength);
                        ReceiveWith?.Invoke(msg, this);
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }


        private void Accept()
        {
            //SocketAsyncEventArgs acceptEventArgs = new SocketAsyncEventArgs();
            //acceptEventArgs.Completed += ReceiveArgs_Saga;
            //socketServer.AcceptAsync(acceptEventArgs);
        }
        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }
        public void AcceptAsync()
        {
            _socket.AcceptAsync(_eventArgs);
        }
        public void ReceiveAsync()
        {
            _socket.ReceiveAsync(_eventArgs);
        }
        public void Close()
        {
            Connected = false;
            _socket.Close();
        }
        public bool Connected
        {
            get; set;
        }


    }
}
