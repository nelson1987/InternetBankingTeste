﻿using BGB.InternetBanking.Api.Contracts.Datas;
using BGB.InternetBanking.Api.Security;
using BGB.InternetBanking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace BGB.InternetBanking.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v1.0/[controller]")]
    public class SecurityController : Controller
    {
        #region [ Actions ]

        [AllowAnonymous]
        [HttpPost]
        public object Authenticate(
                    [FromBody]CredentialDto credential,
                    [FromServices] SigningConfigurations signingConfigurations,
                    [FromServices] TokenConfigurations tokenConfigurations,
                    [FromServices] IUserService _userService)
        {
            //TODO: Chamar o serviço para validar credencial do usuário
            var credenciaisValidas = (credential != null && !string.IsNullOrWhiteSpace(credential.Key) &&
                credential.AccountNumber.Equals("1") && credential.Key == "1");

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(credential.Login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, credential.Key)
                    }
                );

                var dataCriacao = DateTime.Now;
                var dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        #endregion [ Actions ]

    }
}