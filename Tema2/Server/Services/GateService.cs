using Grpc.Core;
using Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class GateService : Gate.GateBase
    {
        public GateService()
        {

        }
        public override Task<Reply> ParseToSeason(UserInfo request, ServerCallContext context)
        {
            DateTime date;
            DateTime.TryParse(request.DateOfBirth, out date);
            var reply = new Reply();
            if (date.Month == 12 || date.Month == 1 || date.Month == 2)
            {
                var temp = new IarnaService();
                var req = new UserInfoIarna();
                req.DateOfBirth = request.DateOfBirth;
                reply.Zodie = temp.SendBack(req, context).Result.Zodie;

            }
            else if (date.Month >= 3 && date.Month < 6)
            {
                var temp = new PrimavaraService();
                var req = new UserInfoPrimavara();
                req.DateOfBirth = request.DateOfBirth;
                reply.Zodie = temp.SendBack(req, context).Result.Zodie;
            }
            else if (date.Month >= 6 && date.Month < 9)
            {
                var temp = new VaraService();
                var req = new UserInfoVara();
                req.DateOfBirth = request.DateOfBirth;
                reply.Zodie = temp.SendBack(req, context).Result.Zodie;
            }
            else
            {
                var temp = new ToamnaService();
                var req = new UserInfoToamna();
                req.DateOfBirth = request.DateOfBirth;
                reply.Zodie = temp.SendBack(req, context).Result.Zodie;
            }
            return Task.FromResult(reply);
        }

    }
}
