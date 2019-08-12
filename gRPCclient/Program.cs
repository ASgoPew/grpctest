using DatabaseProtos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCclient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DBService.DBServiceClient(channel);

            var response = client.GetParkourMapsFinished(new MapsFinishedRequest() { Username = "ASgo" });
            Console.WriteLine(response.Maps);
            Console.ReadKey();
        }
    }
}
