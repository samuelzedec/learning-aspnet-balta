using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebBlog.Extensions;
using WebBlog.Models;

namespace WebBlog.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        // Irá ser usado para manipular e gerar o token
        var tokenHandler = new JwtSecurityTokenHandler();
        
        // O JWT não aceita string e espera um Array de Byte
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Irá transformar a string e uma array de bytes no padrão ASCII

        var claims = user.GetClaims();
        
        // Aqui irá ficar todas as informações do token de fato
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // Usamos o ClaimsIdentity para representar as informações (claims) associadas ao usuário ou entidade no token
            Subject = new ClaimsIdentity(claims),
            
            // Determina o tempo de válidade do token
            Expires = DateTime.UtcNow.AddHours(8), // O Usuário irá ter que fazer login novamente em 8Hrs
            
            // As credenciais de assinatura especificam como o token será assinado (por exemplo, qual chave e algoritmo usar
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), // é um tipo de chave usada para assinar o token com um algoritmo simétrico.
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor); // Aqui o token é gerado com base nas informações do descriptor

        return tokenHandler.WriteToken(token); // Retorna o token JWT como uma string
    }
}