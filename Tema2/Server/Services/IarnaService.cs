using Grpc.Core;
using Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class IarnaService : Iarna.IarnaBase
    {
        private string[] lines;
        public IarnaService()
        {
            lines = System.IO.File.ReadAllLines("Services/Iarna.txt");
        }

        private string whichZodie(string date)
        {
            foreach (string line in lines)
            {

                int m1 = Int32.Parse(line.Substring(3, 2));
                int m2 = Int32.Parse(line.Substring(9, 2));
                int m = Int32.Parse(date.Substring(3, 2));
                int d1 = Int32.Parse(line.Substring(0, 2));
                int d2 = Int32.Parse(line.Substring(6, 2));
                int d = Int32.Parse(date.Substring(0, 2));
                Console.WriteLine(m1 + " " + m2 + " " + m);
                if ((m >= m1 && m <= m2) && (d >= d1 || d <= d2))
                {

                    return line.Substring(12, line.Length - 12);
                }
            }
            return "aa";
        }
        public override Task<ZodieIarna> SendBack(UserInfoIarna request, ServerCallContext context)
        {
            var reply = new ZodieIarna();
            reply.Zodie = whichZodie(request.DateOfBirth);
            return Task.FromResult(reply);
        }
    }
}
