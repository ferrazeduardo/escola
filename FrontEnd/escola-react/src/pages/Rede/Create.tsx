import { useState } from "react";
import { useParams } from "react-router-dom";
import type { Rede } from "../../models/irede";

export function Create() {
    const [rede, setRede] = useState<Rede>({
        cnpj: '',
        razaoSocial: '',
        diasVencimentoRede: []
    });

    let dias: number[] = [];

    function listarDias() {
        for (let i = 1; i <= 20; i++) {
            dias.push(i)
        }
    }

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