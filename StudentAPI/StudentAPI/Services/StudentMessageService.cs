using RabbitMQ.Client;
using StudentAPI.Domain;
using System.Text;
using System.Text.Json;

namespace StudentAPI.Services
{
    public class StudentMessageService
    {
        public void SendMessage(Student student)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "studentQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(student);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "studentQueue",
                                 basicProperties: null,
                                 body: body);

        }
    }
}
