using System;
using MessageWriter;

namespace hello_world
{
	public class App
	{
		readonly IMessageWriter writer;
		public App(IMessageWriter writer)
		{
			this.writer = writer;
		}

		public void Start() 
		{
			writer.Write("Hello World");
		}

	}
}
