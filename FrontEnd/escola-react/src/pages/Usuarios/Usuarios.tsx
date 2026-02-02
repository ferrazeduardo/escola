import { useState } from "react";
import {saveUsuario} from "../../api/usuario.api";
import type { Usuario } from "../../models/iusuario";


export function Usuarios() {
  const [nome, setNome] = useState('');
  const [usuarios, setUsuarios] = useState<Usuario[]>([]);

  async function buscar() {
    // const response = await api.post<Usuario[]>('/usuario/listar', {
    //   nome,
    // });

    // setUsuarios(response.data);
  }

  return (
    <div>
      <h1>Usuários</h1>

      <div>
        <input
          type="text"
          placeholder="Nome"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        />

        <button onClick={buscar}>
          Buscar
        </button>
      </div>

      <ul>
        {usuarios.map(usuario => (
          <li key={usuario.id}>
            {usuario.id} - {usuario.nome}
          </li>
        ))}
      </ul>
    </div>
  );
}
