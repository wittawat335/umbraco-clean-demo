using System.Text.Json.Nodes;

namespace umbraco_clean_demo.Application
{
	public class Response<T>
	{
		public T data { get; set; }
		public bool isSuccess { get; set; } = false;
		public string message { get; set; }
	}
}
