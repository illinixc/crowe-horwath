using System;
using MessageWriter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;

namespace hello_world
{
	class Program
	{
		public IConfigurationRoot Configuration { get; set; }

		static void Main(string[] args)
		{
			var services = new ServiceCollection();
			Configure(services);
			var provider = services.BuildServiceProvider();
			provider.GetService<App>().Start();

		}

		public static void Configure(IServiceCollection services)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", false)
			.Build();
			
			var section = configuration.GetSection("ConfigurationSettings");
			var writer = section["Writer"];
			var type = Type.GetType(writer);
			services.AddTransient(typeof(IMessageWriter), type);
			services.AddTransient<App>();
		}
    }
}
