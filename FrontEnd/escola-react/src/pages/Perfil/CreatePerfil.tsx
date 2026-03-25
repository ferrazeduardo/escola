import { useState } from "react";
import type { Perfil } from "../../models/iperfil";
import { savePerfil } from "../../api/perfil.api";

export function CreatePerfil() {
    const [perfil, setPerfil] = useState<Perfil>({
        descricao: '',
    });

    const [loading, setLoading] = useState(false);
    function onSubmit(e: React.SubmitEvent) {
        e.preventDefault();
        setLoading(true);
        savePerfil(perfil);
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
                    <label>Perfil</label>
                    <input value={perfil?.descricao || ''}
                        onChange={e =>
                            setPerfil({ ...perfil, descricao: e.target.value })
                        } />
                </div>
                <button type="submit">Salvar</button>
            </div>
        </form>
    )
}