using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id = 0;
            string name = "";

            Console.WriteLine("Enter ID :");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();

            ConsumeWCF_XML_Service(id,name);

            Console.ReadLine(); 


        }

        public static async void ConsumeWCF_XML_Service(int id,string name)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.0.94/Service1.svc/Web1/GetStatus1");
                var content = new StringContent("<Class1 xmlns=\"http://tempuri.org/\"><id>"+id+"</id><name>"+name+"</name></Class1>", null, "application/xml");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
