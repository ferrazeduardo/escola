require('dotenv').config();

module.exports = {
  rabbitmqUrl: process.env.RABBITMQ_URL,
  queueName: process.env.QUEUE_NAME,
  pgConfig: {
    host: process.env.PG_HOST,
    port: process.env.PG_PORT,
    user: process.env.PG_USER,
    password: process.env.PG_PASSWORD,
    database: process.env.PG_DATABASE,
  },
};
