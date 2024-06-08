using Contract.Dto.Token;
using System.Security.Claims;

namespace Contract.Interfaces.Services;

public interface ITokenService
{
	public TokenDto CreateAccessToken(List<Claim> claims);
}