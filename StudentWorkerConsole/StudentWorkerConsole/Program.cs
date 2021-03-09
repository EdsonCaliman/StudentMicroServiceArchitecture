using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudentWorkerConsole.Domain;
using System;
using System.Text;
using System.Text.Json;

namespace StudentWorkerConsole
{
    class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "studentQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var student = JsonSerializer.Deserialize<Student>(message);
                Console.WriteLine($"Received {student.Id} | {student.Name} | {student.Created_Date}");
            };
            channel.BasicConsume(queue: "studentQueue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
