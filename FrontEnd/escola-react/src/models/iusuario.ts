export interface Usuario {
  id: number;
  nome: string;
  cpf: string;
  email: string;
  dataNascimento: Date;
  senha?: string;
  login?: string;
}
