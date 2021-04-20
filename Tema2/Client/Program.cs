using Grpc.Net.Client;
using System;
using Server;
using System.Threading.Tasks;
using Server.Protos;
using System.Text.RegularExpressions;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your date of birth like the following example: DD/MM/YYYY");
            var day = Console.ReadLine();
            DateTime dt;
            DateTime.TryParse(day, out dt);
            while(dt.Day == 1 && dt.Month == 1 && dt.Year == 1)
            {
                Console.WriteLine(dt);
                Console.WriteLine("The Date you entered is wrong, please try again: ");
                day = Console.ReadLine();
                DateTime.TryParse(day, out dt);

            }
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Gate.GateClient(channel);
            var clientRequest = new UserInfo { DateOfBirth = day };
            var reply = await client.ParseToSeasonAsync(clientRequest);
            Console.WriteLine(reply.Zodie);
        }
    }
}
