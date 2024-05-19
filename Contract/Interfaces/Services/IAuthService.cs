using Contract.Dto;
using Contract.Dto.Auth;

namespace Contract.Interfaces.Services
{
	public interface IAuthService
	{
		public Task<ApiResponse<LoginResponseDto>> Login(LoginDto dto);
		public Task<ApiResponse<RegisterDto>> Register(RegisterDto dto);
	}
}