import { useState } from "react";
import { useParams } from "react-router-dom";
import type { Rede } from "../../models/irede";

export function CreateRede() {
    const [rede, setRede] = useState<Rede>({
        cnpj: '',
        razaoSocial: '',
        diasVencimentoRede: []
    });
    const [loading, setLoading] = useState(false);
    const dias = Array.from({ length: 20 }, (_, i) => i + 1);
 
    return (
        <form>
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
                    <select >
                        <option>Selecione</option>
                        {dias.map(d => (
                            <option key={d}>{d}</option>
                        ))}
                    </select>
                </div>

            </div>
        </form>
    )
}