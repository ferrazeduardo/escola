const { rabbitmqUrl, queueName } = require('./config/env');
const startConsumer = require('./queue/consumer');
const processMessage = require('./services/messageProcessor');

(async () => {
  await startConsumer(rabbitmqUrl, queueName, processMessage);
})();
