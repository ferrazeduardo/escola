import { MenuItem } from "../core/models/menuItem";

export const MENU: MenuItem[] = [
    {
        label: 'Acadêmico',
        filhos: [
            { label: 'Cadastrar Aluno', rota: '/academico/alunos/novo', permissao: 'aluno.cadastrar' },
            { label: 'Matricular', rota: '/academico/matricula', permissao: 'aluno.matricular' },
            { label: 'Cadastrar Turma', rota: '/academico/turmas/nova', permissao: 'turma.cadastrar' },
        ]
    },
    {
        label: 'Rede',
        filhos:[
            {label: 'Cadastrar Unidade', rota: 'rede/unidade/cadastrar', permissao: 'unidade.cadastrar'},
        ]
    },
    {
        label: 'Sistema',
        filhos: [
            {label: 'Cadastrar Usuário', rota: 'sistema/usuario/cadastrar', permissao: 'usuario.cadastrar'},
            {label: 'Vincular Perfil', rota: 'sistema/perfil/vincular', permissao: 'perfil.vincular'},
        ]
    }
];