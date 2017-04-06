using System;
namespace MessageWriter
{
	public class ConsoleWriter : IMessageWriter
	{
		public ConsoleWriter()
		{
		}
		public void Write(string message)
		{
			Console.WriteLine(message);
		}
	}
}
