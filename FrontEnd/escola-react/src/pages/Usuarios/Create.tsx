import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import { obterUsuario, saveUsuario, editUsuario } from "../../api/usuario.api";
import type { Usuario } from "../../models/iusuario";


export function Create() {
    const [nome, setNome] = useState('');
    const [cpf, setCpf] = useState('');
    const [email, setEmail] = useState('');
    const [loading, setLoading] = useState(false);
    const [usuario, setUsuario] = useState<Usuario>({
        id: 0,
        nome: '',
        cpf: '',
        email: '',
        dataNascimento: new Date(),
        senha: '',
        login: ''
    });

    const { id } = useParams();

    useEffect(() => {
        if (!id) return; // 👉 modo criação

        buscarUsuario(id);
    }, [id]);

    async function onSubmit() {
        if (id) {
            editUsuario(usuario)
        } else {
            saveUsuario(usuario)
        }


    }

    async function buscarUsuario(id: string) {
        setLoading(true);
        try {
            const response = await obterUsuario(Number(id));
            setUsuario(response.data);
        } catch (error) {
            console.error('Erro ao buscar usuário', error);
        } finally {
            setLoading(false);
        }
    }

    if (loading) {
        return <p>Carregando...</p>;
    }

    return (
        <form onSubmit={onSubmit}>

            <div>
                <h1>Cadastrar</h1>
                <div>
                    <label>Nome</label>
                    <input
                        type="text"
                        placeholder="Nome"
                        value={usuario?.nome || ''}
                        onChange={(e) =>
                            setUsuario({ ...usuario, nome: e.target.value })
                        }
                    />

                </div>
                <div>
                    <label htmlFor="">Cpf</label>
                    <input
                        type="text"
                        placeholder="Cpf"
                        value={usuario?.cpf || ''}
                        onChange={(e) =>
                            setUsuario({ ...usuario, cpf: e.target.value })
                        }
                    />
                </div>
                <div>
                    <label htmlFor="">Email</label>
                    <input
                        type="text"
                        placeholder="Emailf"
                        value={usuario?.email || ''}
                        onChange={(e) =>
                            setUsuario({ ...usuario, email: e.target.value })
                        }
                    />
                </div>
                <div>
                    <label htmlFor="">Data Nascimento</label>
                    <input
                        type="date"
                        placeholder="Data Nascimento"
                        value={
                            usuario?.dataNascimento
                                ? String(usuario.dataNascimento).split('T')[0]
                                : ''
                        }

                        onChange={(e) =>
                            setUsuario({ ...usuario, dataNascimento: new Date(e.target.value) })
                        }
                    />
                </div>
                <div>
                    <label>Login</label>
                    <input
                        type="text"
                        placeholder="Login"
                        value={usuario?.login || ''}
                        onChange={(e) =>
                            setUsuario({ ...usuario, login: e.target.value })
                        }
                    />
                </div>
                <div>
                    <label>Login</label>
                    <input
                        type="text"
                        placeholder="Senha"
                        value={usuario?.senha || ''}
                        onChange={(e) =>
                            setUsuario({ ...usuario, senha: e.target.value })
                        }
                    />
                </div>
                <button>Salvar</button>
            </div>
        </form>
    );
}


