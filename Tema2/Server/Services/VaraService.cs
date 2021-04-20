using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Server.Protos;

namespace Server.Services
{
    public class VaraService : Vara.VaraBase
    {
        private string[] lines;
        public VaraService()
        {

            lines = System.IO.File.ReadAllLines("Seasons/Vara.txt");
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
                if (m1 == m2 && m1 == m)
                {
                    if (d >= d1 && d <= d2)
                    {
                        return line.Substring(12, line.Length - 12);
                    }

                }
                else
                {
                    if (m == m1)
                    {
                        if (d >= d1)
                        {
                            return line.Substring(12, line.Length - 12);
                        }
                    }

                    else if (m == m2)
                    {
                        if (d <= d2)
                        {
                            return line.Substring(12, line.Length - 12);
                        }
                    }
                }
            }
            return "aa";
        }
        public override Task<ZodieVara> SendBack(UserInfoVara request, ServerCallContext context)
        {

            var reply = new ZodieVara();
            reply.Zodie = whichZodie(request.DateOfBirth);
            return Task.FromResult(reply);
        }
    }
}
