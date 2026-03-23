import { useState } from "react";
import type { Unidade } from "../../models/iunidade";
import { addUnidade } from "../../api/unidade.api";

export function CreateUnidade() {
    const [unidade, setUnidade] = useState<Unidade>({
        endereco: '',
        cep: '',
        complemento: '',
        numeroUnidade: '',
        usuarioRegistro: 1,
        telefones: [''],
        id_rede: 1
    })

    const [loading, setLoading] = useState(false)

    function onSubmit(e: React.SubmitEvent) {
        e.preventDefault();
        setLoading(true);
        addUnidade(unidade);
        setLoading(false);
    }

    const handleTelefoneChange = (index: number, value: string) => {
        const novosTelefones = [...unidade.telefones];
        novosTelefones[index] = value;

        setUnidade({
            ...unidade,
            telefones: novosTelefones
        });
    };

    const adicionarTelefone = () => {
        setUnidade({
            ...unidade,
            telefones: [...unidade.telefones, '']
        });
    };

    const removerTelefone = (index: number) => {
        const novosTelefones = unidade.telefones.filter((_, i) => i !== index);

        setUnidade({
            ...unidade,
            telefones: novosTelefones
        });
    };

    if (loading) {
        return <p>Carregando...</p>;
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <h1>Cadastrar</h1>
                <div>
                    <label htmlFor="">Endereço</label>
                    <input type="text"
                        value={unidade?.endereco || ''}
                        onChange={(e) =>
                            setUnidade({ ...unidade, endereco: e.target.value })
                        } />
                </div>
                <div>
                    <label htmlFor="">Cep</label>
                    <input type="text"
                        value={unidade?.cep || ''}
                        onChange={(e) =>
                            setUnidade({ ...unidade, cep: e.target.value })
                        } />
                </div>
                <div>
                    <label htmlFor="">Complemento</label>
                    <input type="text"
                        value={unidade?.complemento || ''}
                        onChange={(e) =>
                            setUnidade({ ...unidade, complemento: e.target.value })
                        } />

                </div>
                <div>
                    <label htmlFor="">Número</label>
                    <input type="text"
                        value={unidade?.numeroUnidade || ''}
                        onChange={(e) =>
                            setUnidade({ ...unidade, numeroUnidade: e.target.value })
                        } />

                </div>

                {unidade.telefones.map((tel, index) => (
                    <div key={index} style={{ marginBottom: '8px' }}>
                        <input
                            type="text"
                            value={tel}
                            onChange={(e) => handleTelefoneChange(index, e.target.value)}
                            placeholder="Digite o telefone"
                        />

                        <button type="button" onClick={() => removerTelefone(index)}>
                            Remover
                        </button>
                    </div>
                ))}

                <button type="button" onClick={adicionarTelefone}>
                    Adicionar telefone
                </button>
                <button type="submit">Salvar</button>
            </div>
        </form>
    )
}