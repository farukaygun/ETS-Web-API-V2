namespace Common.Services
{
	public class ConsoleLogger : ILoggerService
	{
		public void Log(string message)
		{
			Console.WriteLine($"[ConsoleLogger]: {message}");
		}
	}
}
