using CounterStrikeDashboard.Core.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Communication
{
    public class CommunicationServer : ICounterStrikeCommunicationServer, IDisposable
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
        const int MESSAGE_OFFSET = 0;

        private UdpClient _udpClient = null;
        private Thread _udpThread = null;
        private bool _stopRequested = false;
        public int Port { get; private set; }
        public bool IsRunning { get; private set; }

        public CommunicationServer ()
        {            
            this.IsRunning = false;
        }

        public event Action<string> OnNewEvent;
        public event Action OnClosed;
        public event Action<Exception> OnError;

        public void Start(int port)
        {
            this.Port = port;

            if (_udpClient != null)
                throw new IOException("CommunicationServer already started");

            _udpClient = new UdpClient(Port);            

            Console.WriteLine("Listening on port {0}", Port);

            _udpThread = new Thread(RunServer);
            _udpThread.Start();
        }

        public void Stop()
        {
            _log.Debug("Stop requested");

            StopServer();
        }

        private void StopServer()
        {
            _stopRequested = true;
        }

        private void RunServer()
        {
            try
            {
                IsRunning = true;

                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);

                while (!_stopRequested)
                {
                    var data = _udpClient.Receive(ref ipEndPoint);
                    var dataString = Encoding.ASCII.GetString(data, MESSAGE_OFFSET, data.Length - MESSAGE_OFFSET);

                    if (OnNewEvent != null)
                        OnNewEvent(dataString);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Error in server connection", ex);

                if (OnError != null)
                    OnError(ex);
            }
            finally
            {
                IsRunning = false;
                if (OnClosed != null)
                    OnClosed();

                _log.Debug("UdpThread stopped");
            }            
        }

        public void Dispose()
        {
            this.Stop();
        }
    }
}
