require('dotenv').config();
const startConsumer = require('./consumer');

const rabbitUrl = process.env.RABBITMQ_URL;
const queueName = process.env.QUEUE_NAME;

function processMessage(message) {
  console.log(`[🛠️] Processando: ${message}`);
  // Aqui você coloca sua lógica de negócio
}

startConsumer(rabbitUrl, queueName, processMessage);
