const { Pool } = require('pg');
const { pgConfig } = require('../config/env');

const pool = new Pool(pgConfig);

pool.on('error', (err) => {
  console.error('Erro inesperado no cliente do PostgreSQL', err);
  process.exit(-1);
});

module.exports = pool;
