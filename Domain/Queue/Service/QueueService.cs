using Domain.MailNS;
using Domain.Models.EntregaNS;
using Domain.Queue.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


namespace Domain.Queue.Service
{
    public class QueueService : IQueueService
    {
        public void Enqueue(Entrega entrega)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "EntregaQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = System.Text.Json.JsonSerializer.Serialize(entrega);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "EntregaQueue",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" AlunoId {0} enviou uma entrega relativa à {1} em {2}. Link: {3}", entrega.AlunoId, entrega.TarefaId, entrega.DataEntrega, entrega.BlobUrl);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
