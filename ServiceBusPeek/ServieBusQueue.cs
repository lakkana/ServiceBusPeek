using Azure.Messaging.ServiceBus;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PushVehicleIndexToServiceBus
{
    public class ServieBusQueue
    {
        public async static Task SendMessageAsync(string serviceBusMessage)
        {
            try
            {
                string queueName = "vehicleindexincrements";
                ServiceBusClient serviceBusClient = new ServiceBusClient("Endpoint=sb://jato-archsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lNSZ3xbcaeIXPS+EKlcfcU6Rrw/llVjhDMplhR/Owkg=", new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });
                ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);
                await serviceBusSender.SendMessageAsync(new ServiceBusMessage(serviceBusMessage));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string PeekMessageAsync()
        {
            try
            {
                string queueName = "vehicleindexincrements";
                ServiceBusClient serviceBusClient = new ServiceBusClient("Endpoint=sb://jato-archsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lNSZ3xbcaeIXPS+EKlcfcU6Rrw/llVjhDMplhR/Owkg=", new ServiceBusClientOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                });
                var serviceBusReceiver = serviceBusClient.CreateReceiver(queueName);
                var message = serviceBusReceiver.PeekMessagesAsync(1).Result;
                if (message.Any())
                {
                    Console.WriteLine(message.First().Body);
                    return message.First().Body.ToString();
                }
                else
                {
                    Console.WriteLine(@"Queue is Empty");
                    return "The Queue is Empty";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }   
    }
}
