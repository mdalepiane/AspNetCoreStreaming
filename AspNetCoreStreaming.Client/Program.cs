using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCoreStreaming.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to send request ...");
                Console.ReadLine();

                using (var stream = await client.GetStreamAsync("https://localhost:50001/api/values"))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        int counter = 0;
                        int chunkCounter = 0;
                        while (streamReader.EndOfStream == false)
                        {
                            counter++;
                            if (streamReader.Read() == (int)'-')
                            {
                                chunkCounter++;
                                Console.WriteLine($"Finished chunk {chunkCounter} with {counter} chars ...");
                                counter = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
