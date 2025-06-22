const db = require('../db/pgClient');

async function processMessage(msg) {
  try {
    const data = JSON.parse(msg); // espera que a mensagem seja JSON

    const result = await db.query(
      '',
      [data.conteudo]
    );

    console.log(`[✅] Mensagem salva no banco, ID: ${result.rows[0].id}`);
  } catch (err) {
    console.error('[❌] Erro ao processar a mensagem:', err.message);
  }
}

module.exports = processMessage;
