using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {

            Program program = new Program();
            // await program.GetItems();

            for (int i = 4; i <= 13; i++)
            {
                var tasks = new[]
                {
                    program.GetItems(i),
                };
              
                try
                {

                    var task = await Task.WhenAny(tasks);
                 
                
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
           
        }

        private async Task GetItems(int id)
        {

            string response = await client.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            Console.WriteLine(response);
            using (StreamWriter writer= new StreamWriter("path.txt",true))
            {
                await writer.WriteLineAsync(response);
            }
           
        }
    }
}
