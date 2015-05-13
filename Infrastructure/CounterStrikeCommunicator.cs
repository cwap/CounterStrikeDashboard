using CounterStrikeDashboard.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Infrastructure
{
    public class CounterStrikeCommunicator : ICounterStrikeCommunicator
    {
        private const string STATUS_COMMAND = "status";
        private const string LOGGING_COMMAND = "mp_logfile";

        public CounterStrikeCommunicator()
        {

        }

        public string GetStatus(CounterStrikeCommunicatorConfiguration configuration = null)
        {
            return SendCommand(configuration.Ip, configuration.Port, configuration.RConPassword, STATUS_COMMAND);
        }

        private string SendCommand(string serverIp, int serverPort, string rconPassword, string command)
        {
            try
            {
                using (var client = new UdpClient())
                {
                    client.Connect(serverIp, serverPort);

                    //sending challenge command to counter strike server 
                    string getChallenge = "challenge rcon\n";
                    byte[] bufferSend = this.prepareCommand(getChallenge);

                    //send challenge command and get response
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    client.Send(bufferSend, bufferSend.Length);
                    byte[] bufferRec = client.Receive(ref RemoteIpEndPoint);

                    //retrive number from challenge response 
                    string challenge_rcon = Encoding.ASCII.GetString(bufferRec);
                    challenge_rcon = string.Join(null, Regex.Split(challenge_rcon, "[^\\d]"));

                    //preparing rcon command to send
                    string fullCommand = "rcon \"" + challenge_rcon + "\" " + rconPassword + " " + command + "\n";
                    bufferSend = this.prepareCommand(fullCommand);

                    client.Send(bufferSend, bufferSend.Length);
                    bufferRec = client.Receive(ref RemoteIpEndPoint);
                    return Encoding.ASCII.GetString(bufferRec);
                }
            }
            catch (Exception ex)
            {
                throw new CounterStrikeCommunicationException("Error in counter strike connection", ex);
            }
        }

        private byte[] prepareCommand(string command)
        {
            byte[] bufferTemp = Encoding.ASCII.GetBytes(command);
            byte[] bufferSend = new byte[bufferTemp.Length + 4];

            //intial 5 characters as per standard
            bufferSend[0] = byte.Parse("255");
            bufferSend[1] = byte.Parse("255");
            bufferSend[2] = byte.Parse("255");
            bufferSend[3] = byte.Parse("255");

            //copying bytes from challenge rcon to send buffer
            int j = 4;

            for (int i = 0; i < bufferTemp.Length; i++)
            {
                bufferSend[j++] = bufferTemp[i];
            }
            return bufferSend;
        }


        public string SetLogging(bool enabled, CounterStrikeCommunicatorConfiguration configuration = null)
        {
            return SendCommand(configuration.Ip, configuration.Port, configuration.RConPassword, LOGGING_COMMAND + " " + (enabled ? "1" : "0"));
        }
    }
}
