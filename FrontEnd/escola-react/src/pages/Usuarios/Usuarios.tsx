import { useState } from "react";
import { listarUsuarios } from "../../api/usuario.api";
import type { Usuario } from "../../models/iusuario";
import { useNavigate } from 'react-router-dom';

export function Usuarios() {
  const [nome, setNome] = useState('');
  const [usuarios, setUsuarios] = useState<Usuario[]>([]);
  const navigate = useNavigate();

  async function buscar() {
    const response = await listarUsuarios(nome);

    setUsuarios(response.data);
  }

  function editar(id: number) {
    navigate(`/usuarios/editar/${id}`);
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

      <table>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>CPF</th>
            <th>Ação</th>
          </tr>
        </thead>
        <tbody>
          {usuarios.map(usuario => (
            <tr key={usuario.id}>
              <td>{usuario.id}</td>
              <td>{usuario.nome}</td>
              <td>{usuario.cpf}</td>
              <td><button onClick={() => editar(usuario.id)}></button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
