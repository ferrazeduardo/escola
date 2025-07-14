const startConsumer = require('../queue/consumer');
const createMessageProcessor = require('../services/messageProcessor');

function runConsumer({ rabbitmqUrl, queueName, db }) {
  const processMessage = createMessageProcessor({ db }); // ← injetando dependência
  return startConsumer({ rabbitmqUrl, queueName, onMessage: processMessage });
}

module.exports = runConsumer;
