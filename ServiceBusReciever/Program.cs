using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace ServiceBusReciever
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Endpoint = sb://trialbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xN4pYhOcgxH5UL+0cUeguN5hjsi/1gFtGZkS6nZy/2Q=";

            string queueName = "demoqueue";

            await using ServiceBusClient client = new ServiceBusClient(connectionString);
            
            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // get the message body as a string
            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);

        }
    }
}
