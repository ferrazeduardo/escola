import { useState } from "react";
import { useParams } from "react-router-dom";
import type { Rede } from "../../models/irede";
import { saveRede } from "../../api/rede.api";

export function CreateRede() {
    const [rede, setRede] = useState<Rede>({
        cnpj: '',
        razaoSocial: '',
        diasVencimentoRede: [],
        codigoUsuario: 1
    });
    const [loading, setLoading] = useState(false);
    const dias = Array.from({ length: 20 }, (_, i) => i + 1);

    function onSubmit(e: React.SubmitEvent) {
        e.preventDefault();
        setLoading(true);
        saveRede(rede);
        setLoading(false);
    }

    if (loading) {
        return <p>Carregando...</p>;
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <h1>Cadastrar</h1>
                <div>
                    <label htmlFor="">CNPJ</label>
                    <input type="text"
                        value={rede?.cnpj || ''}
                        onChange={(e) =>
                            setRede({ ...rede, cnpj: e.target.value })
                        } />
                </div>
                <div>
                    <label htmlFor="">Razão Social</label>
                    <input type="text"
                        value={rede?.razaoSocial || ''}
                        onChange={(e) =>
                            setRede({ ...rede, razaoSocial: e.target.value })
                        } />
                </div>
                <div>
                    <label htmlFor="">Dias Vencimanto</label>
                    <select
                        multiple
                        onChange={(e) => {
                            const values = Array.from(e.target.selectedOptions, opt => Number(opt.value));
                            setRede({ ...rede, diasVencimentoRede: values });
                        }}
                    >
                        {dias.map(d => (
                            <option key={d} value={d}>{d}</option>
                        ))}
                    </select>

                </div>
                <button type="submit">Salvar</button>
            </div>
        </form>
    )
}