## ✨ Funcionalidades Principais

- Cadastro e gerenciamento de **Redes de ensino**
- Cadastro e gerenciamento de **Unidades Escolares** (escolas)
- Cadastro de **Séries / Anos letivos** e turmas
- Cadastro completo de **Alunos** (dados pessoais, responsáveis, documentos, histórico)
- **Matrícula** de alunos em turmas
- Lançamento de **Frequência** (presença / diário de classe por aula ou dia)
- Lançamento de **Notas**, cálculo de médias e status de aprovação/reprovação
- Cadastro e autenticação de **Usuários** do sistema (Administrador, Diretor, Coordenador, Professor, Secretaria)
- Perfis com diferentes níveis de permissão (RBAC – Role Based Access Control)

### Funcionalidades planejadas (roadmap)

- [ ] Geração de boletim online (PDF/HTML)
- [ ] Comunicação com responsáveis (avisos, ocorrências, notificações)
- [ ] Relatórios gerenciais (evasão escolar, desempenho por turma/série, frequência consolidada)
- [ ] Área do aluno e do responsável (portal do aluno)
- [ ] Integração com WhatsApp Business API / e-mail (envio automático)
- [ ] Exportação de dados (Excel, CSV)

## 🚀 Tecnologias Utilizadas

- **Backend**: .NET 8 (ASP.NET Core)
- **Frontend**: React
- **Banco de dados**:  PostgreSQL 
- **ORM**: Entity Framework Core (Code First)
- **Outras ferramentas**:
  - .NET CLI
  - Git
  - Docker / Docker Compose (opcional para ambiente de produção)
  - xUnit + Moq (testes unitários/integração – em desenvolvimento)

## Estrutura Básica do Banco de Dados (entidades principais)
