namespace dTemplate.Application
{
	public class MessagedResult<T>
	{
		public T Value { get; set; }

		public string Message { get; set; }

		public MessagedResult(T value)
			: this(value, string.Empty)
		{ }

		public MessagedResult(T value, string message)
		{
			this.Value = value;
			this.Message = message;
		}
	}
}
