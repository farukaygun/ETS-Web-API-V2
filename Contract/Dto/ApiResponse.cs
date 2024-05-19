namespace Contract.Dto
{
	public class ApiResponse<T>
	{
		public bool Success { get; set; } = true;
		public T? Data { get; set; } 
		public string? Message { get; set; }
		public int? StatusCode { get; set; }
		public string? StackTrace { get; set; }
	}
}
