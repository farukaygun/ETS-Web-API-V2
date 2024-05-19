namespace Common.Services
{
	public class DbLogger : ILoggerService
	{
		public void Log(string message)
		{
			Console.WriteLine($"[DbLogger]: {message}");
		}
	}
}
