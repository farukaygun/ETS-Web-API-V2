using Contract.Dto.Token;

namespace Contract.Dto.Auth;

public record LoginResponseDto
{
	public string? Email { get; set; }
	public string? UserName { get; set; }
	public TokenDto? Token { get; set; }
}
