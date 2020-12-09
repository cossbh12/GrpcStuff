using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class TurnByTurnService : TurnByTurn.TurnByTurnBase
    {
        public override async Task StartGuidance(GuidanceRequest request, IServerStreamWriter<Step> responseStream, ServerCallContext context)
        {
            var steps = new List<Step>
            {
                new Step {Direction="Left", Road = "Morse"},
                new Step {Direction="Left", Road = "Hienz Hill"},
                new Step {Direction="Right", Road= "Broadway"}
            };
            foreach(var step in steps)
            {
                await Task.Delay(new Random().Next(2000, 3000));
                await responseStream.WriteAsync(step);
            };

        }
        
    }
}
