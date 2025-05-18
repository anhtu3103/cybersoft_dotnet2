using Confluent.Kafka;
using System.Text.Json;

namespace AuthenticationService.Services
{
    public class KafkaProducerService
    {
        private readonly IProducer<string, string> _producer;
        private const string Topic = "user-registered";

        public KafkaProducerService()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "kafka:9092"
                
            };
            
            _producer = new ProducerBuilder<string, string>(config).Build();
        }


        //wrie function to send event to Kafka message broker
        public async Task PublicUserRegisteredEvent(string email, string username)
        {
            var message = new
            {
                Email = email,
                Username = username,
                Timestamp = DateTime.UtcNow
            };

            //convert to Json
            var jsonMessage = JsonSerializer.Serialize(message);

            //send message to Kafka

            await _producer.ProduceAsync(Topic, new Message<string, string> { 
                
                Key = email,
                Value = jsonMessage
            });
        }

        //function close producer and clear memory
        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
