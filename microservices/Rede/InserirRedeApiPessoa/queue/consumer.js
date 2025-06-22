const amqp = require('amqplib');

async function startConsumer(rabbitUrl, queueName, onMessage) {
  try {
    const conn = await amqp.connect(rabbitUrl);
    const channel = await conn.createChannel();
    await channel.assertQueue(queueName, { durable: true });

    console.log(`[🎧] Aguardando mensagens na fila: ${queueName}`);

    channel.consume(queueName, async (msg) => {
      if (msg !== null) {
        const content = msg.content.toString();
        console.log(`[📥] Mensagem recebida: ${content}`);

        try {
          await onMessage(content);
          channel.ack(msg);
        } catch (err) {
          console.error('[❌] Erro ao processar mensagem:', err);
          // Se quiser reprocessar depois, use channel.nack(msg, false, true);
          channel.ack(msg); // ou channel.nack(msg, false, false) para descartar
        }
      }
    });

    return { conn, channel };
  } catch (err) {
    console.error('[❌] Falha ao iniciar consumidor:', err.message);
  }
}

module.exports = startConsumer;
