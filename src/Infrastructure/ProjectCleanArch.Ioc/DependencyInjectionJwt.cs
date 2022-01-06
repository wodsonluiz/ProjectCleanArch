using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ProjectCleanArch.Ioc
{
    public static class DependencyInjectionJwt
    {
        public static IServiceCollection AddInfrasTructureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //Informar o tipo de autentificação JWT-Bearer
            //Definir o modelo de desafio de autentificação
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Habilita a autenticação JWT usando o esquema e desafio definidos
            //Valida o token
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    //Valores validados
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    
                    //Tempo extra de vida do seu token [Tempo default = 5 min]
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
