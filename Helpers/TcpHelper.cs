using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AnimeList.Helpers
{
    public class TcpHelper
    {
        private TcpListener listener;
        private TcpClient client;
        public string Code = "";
        public string FirstIpPart = "";
        public delegate void Connected(TcpClient client);
        public event Connected OnConnected;
        public event Connected OnAccepted;
        public delegate void Error(string message);
        public event Error OnError;

        public TcpHelper()
        {


        }

        public void Start()
        {
            try
            {
                var resolved = Dns.GetHostEntry(Dns.GetHostName());
                var found = resolved.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);


                var ip = found.ToString();

                Console.WriteLine(ip);

                var parts = ip.Split('.');
                var gateway = parts[parts.Length - 1];

                Console.WriteLine(gateway);
                FirstIpPart = parts[0] + "." + parts[1] + "." + parts[2] + ".";

                if (Convert.ToInt32(gateway) == 1)
                {
                    Code = "Нет сети";
                    OnError?.Invoke("Нет подключения к сети.");
                    return;
                }



                listener = new TcpListener(System.Net.IPAddress.Any, 0);
                listener.Start();
                var port = ((IPEndPoint)listener.LocalEndpoint).Port;




                Code = ConvertToBase62(Convert.ToInt32(gateway)) + "-" + ConvertToBase62(Convert.ToInt32(port));
            } catch (Exception ex)
            {
                Code = "Нет сети";
            }
        }

        public async Task StartWaiting()
        {
            try
            {
                var client = await listener.AcceptTcpClientAsync();
                OnAccepted?.Invoke(client);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<Models.AnimeList> ReadIncomingAsync()
        {
            try
            {
                var stream = client.GetStream();

                StreamReader sr = new StreamReader(stream);
                if (client.Connected)
                {
                    var reading = await sr.ReadLineAsync();
                    var gotList = JsonSerializer.Deserialize<Models.AnimeList>(reading, new JsonSerializerOptions()
                    {
                        IncludeFields = true,
                        PropertyNameCaseInsensitive = true
                    });
                    return gotList;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public async Task SendAnimeList(TcpClient connectedClient, Models.AnimeList list)
        {
            try 
            {
                var stream = connectedClient.GetStream();
                var sw = new StreamWriter(stream);
                sw.WriteLine(JsonSerializer.Serialize(list));
                await sw.FlushAsync();
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        public string ReturnCode()
        {
            return Code;
        }

        public void Dispose()
        {
            try
            {
                if(listener != null)
                    listener.Stop();
                if (client != null)
                {
                    client.Close();
                    client.Dispose();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static long ConvertToDecimal(string base62Number)
        {
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int baseCount = 62;
            long result = 0;

            for (int i = 0; i < base62Number.Length; i++)
            {
                char digit = base62Number[i];
                int value = digits.IndexOf(digit);
                result = result * baseCount + value;
            }

            return result;
        }

        public static string ConvertToBase62(long decimalNumber)
        {
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int baseCount = 62;
            StringBuilder result = new StringBuilder();

            while (decimalNumber > 0)
            {
                int remainder = (int)(decimalNumber % baseCount);
                result.Insert(0, digits[remainder]);
                decimalNumber /= baseCount;
            }

            return result.ToString();
        }

        public async Task Connect(string codeEntered)
        {
            client = new TcpClient(AddressFamily.InterNetwork);
            
            var split = codeEntered.Split('-');
            
            var gateway = ConvertToDecimal(split[0]);
            var port = ConvertToDecimal(split[1]);

            Console.WriteLine(gateway);
            Console.WriteLine(port);

            await client.ConnectAsync(FirstIpPart + gateway.ToString(), Convert.ToInt32(port));

            OnConnected?.Invoke(client);
            Console.WriteLine("Connection");
        }
    }


}
