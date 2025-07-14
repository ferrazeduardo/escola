const { rabbitmqUrl, queueName } = require('./config/env');
const startConsumer = require('./queue/consumer');
const runConsumer = require('./app/runConsumer');

(async () => {
    await runConsumer({ rabbitmqUrl, queueName, db });
})();
