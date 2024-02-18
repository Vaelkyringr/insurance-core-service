using RabbitMQ.Client;
using System.Text;

namespace InsuranceCoreService.Infrastructure.Services;

public class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IModel _channel;

    public DomainEventPublisher(string hostname, string username, string password)
    {
        var factory = new ConnectionFactory() { HostName = hostname, UserName = username, Password = password };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public void Publish(string queueName, string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        _channel.QueueDeclare(queue: queueName,durable: false,exclusive: false, autoDelete: false, arguments: null);
        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
    }
}