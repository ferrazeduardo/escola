const { rabbitmqUrl, queueName } = require('./config/env');
const startConsumer = require('./queue/consumer');
const runConsumer = require('./app/runConsumer');
const db = require('./db/pgClient');

(async () => {
    await runConsumer({ rabbitmqUrl, queueName, db });
})();
