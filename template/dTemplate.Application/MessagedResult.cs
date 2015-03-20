namespace dTemplate.Application
{
	public class MessagedResult<T>
	{
		public T Value { get; private set; }

		public string Message { get; private set; }

		public MessagedResult(T value, string message)
		{
			Value = value;
			Message = message;
		}
	}
}
