using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contract.Dto.Token;
using Contract.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Contract.Services
{
	public class TokenService(IConfiguration configuration) : ITokenService
	{
		public TokenDto CreateAccessToken(List<Claim> claims)
		{
			var tokenDto = new TokenDto();
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			tokenDto.Expiration = DateTime.Now.AddMinutes(30);
			var securityToken = new JwtSecurityToken(
				issuer: configuration["Token:Issuer"],
				audience: configuration["Token:Audience"],
				claims: claims,
				expires: tokenDto.Expiration,
				notBefore: DateTime.Now,
				signingCredentials: credentials
			);

			var tokenHandler = new JwtSecurityTokenHandler();

			tokenDto.AccessToken = tokenHandler.WriteToken(securityToken);
			tokenDto.RefreshToken = CreateRefreshToken();

			return tokenDto;
		}

		private static string CreateRefreshToken() => Guid.NewGuid().ToString();
	}
}