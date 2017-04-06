using System;
using Xunit;
using Moq;
using MessageWriter;
using hello_world;

namespace MessageWriterTest
{
    public class UnitTest1
    {
        [Fact]
        public void Writer_Should_Write_Hello_World()
        {
			var message = "Hello World";
			var mockWriter = new Mock<IMessageWriter>();
			var app = new App(mockWriter.Object);
			app.Start();
			mockWriter.Verify(mw => mw.Write(message), Times.Once);

        }
    }
}
