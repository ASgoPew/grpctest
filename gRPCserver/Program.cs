using DatabaseProtos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCserver
{
    public class gRPCserver : DBService.DBServiceBase
    {
        public override Task<MapsFinishedResponse> GetParkourMapsFinished(MapsFinishedRequest request, ServerCallContext context)
        {
            var response = new MapsFinishedResponse();
            response.Maps.Add("kek");
            response.Maps.Add(request.Username);
            response.Maps.Add("lol");
            return Task.FromResult(response);
        }

        public override Task<SecretsFoundResponse> GetSecretsFound(SecretsFoundRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SecretsFoundResponse());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server()
            {
                Services = { DatabaseProtos.DBService.BindService(new gRPCserver()) },
                Ports = { new ServerPort("127.0.0.1", 50051, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.ReadKey();
        }
    }
}
