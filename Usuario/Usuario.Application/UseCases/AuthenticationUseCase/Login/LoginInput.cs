using System;
using MediatR;

namespace Usuario.Application.UseCases.AuthenticationUseCase.Login;

public class LoginInput : IRequest<LoginOutput>
{   
    public string login { get; set; }
    public string senha { get; set; }
}
