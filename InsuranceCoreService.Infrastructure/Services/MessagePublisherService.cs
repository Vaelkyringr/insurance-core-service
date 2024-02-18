namespace InsuranceCoreService.Infrastructure.Services;

public class MessagePublisherService : IMessagePublisherService
{
    private IModel? _channel;
    private readonly IConfiguration _configuration;

    public MessagePublisherService(IConfiguration configuration)
    {
        _configuration = configuration;
        SetupConnection();
    }

    public void SetupConnection()
    {
        var hostname = _configuration["RabbitMQ:Hostname"];
        var username = _configuration["RabbitMQ:Username"];
        var password = _configuration["RabbitMQ:Password"];

        var factory = new ConnectionFactory() { HostName = hostname, UserName = username, Password = password };
        var connection = factory.CreateConnection();

        _channel = connection.CreateModel();
    }

    public void Publish(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        var queueName = _configuration["RabbitMQ:QueueName"];

        _channel?.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
    }
}