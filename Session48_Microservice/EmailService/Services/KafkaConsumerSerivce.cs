using Confluent.Kafka;
using System.Text.Json;

namespace EmailService.Services
{
    public class KafkaConsumerSerivce : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly IEmailService _emailService;
        private const string Topic = "user-registered";

        public KafkaConsumerSerivce(IEmailService emailService)
        {
            //config consumer
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka:9092",
                GroupId = "user-registered-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();

            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //subcribe topic
            _consumer.Subscribe(Topic);
            while (!stoppingToken.IsCancellationRequested) //cannot cancel token request
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken); //consume token

                    //convert from json to object
                    var message = JsonSerializer.Deserialize<UserRegistered>(consumeResult.Message.Value);
                    if (message != null)
                    {
                        await _emailService.SendWelcomeEmail(message.Email, message.Username);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error: " + ex);
                }
            }
        }

        public override void Dispose()
        {
            _consumer?.Dispose();
            base.Dispose();
        }
    }

    public class UserRegistered
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
