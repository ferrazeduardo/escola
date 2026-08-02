export interface LoginRequest {
  login: string;
  senha: string;
}

export interface LoginResponse {
  token: string;
}

export interface ApiErrorResponse {
  error: string;
  details: string;
}
