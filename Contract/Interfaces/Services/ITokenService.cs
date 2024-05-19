using System.Security.Claims;
using Contract.Dto.Token;

namespace Contract.Interfaces.Services;

	public interface ITokenService
	{
		public TokenDto CreateAccessToken(List<Claim> claims);
	}