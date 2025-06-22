const amqp = require('amqplib');

async function startConsumer(rabbitUrl, queueName, onMessage) {
  try {
    const connection = await amqp.connect(rabbitUrl);
    const channel = await connection.createChannel();

    await channel.assertQueue(queueName, { durable: true });

    console.log(`[✔️] Aguardando mensagens na fila: ${queueName}`);

    channel.consume(queueName, (msg) => {
      if (msg !== null) {
        const content = msg.content.toString();
        console.log(`[📥] Mensagem recebida: ${content}`);
        
        // Chama a função de processamento
        onMessage(content);

        // Confirma o recebimento da mensagem
        channel.ack(msg);
      }
    });

  } catch (err) {
    console.error('[❌] Erro ao conectar no RabbitMQ:', err);
  }
}

module.exports = startConsumer;
