export interface UsuarioSaveRequest {
  nome: string;
  cpf: string;
  dataNascimento: string; // ISO (yyyy-MM-dd) -> DateTime no backend
  email: string;
  senha: string;
  ehRaiz: boolean;
}
