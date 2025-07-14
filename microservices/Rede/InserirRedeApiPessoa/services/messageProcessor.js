const db = require('../db/pgClient');

module.exports = async function processMessage(msg) {
  try {
    const data = JSON.parse(msg); // espera que a mensagem seja JSON

    const result = await db.query(
      'INSERT INTO Rede (Id, DS_REDE) VALUES ($1, $2) RETURNING Id',
      [data.Id, data.DS_REDE]
    );

    console.log(`[✅] Mensagem salva no banco, ID: ${result.rows[0].id}`);
  } catch (err) {
    console.error('[❌] Erro ao processar a mensagem:', err.message);
  }
}

module.exports = processMessage;
