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

		/// <summary>
		/// Configure the specified services. 
		/// As I dont currently have a Windows machine, this was my first attempt at using 
		/// the .Net App Core on a Mac. Unity and Ninject aren't currently compatible. Since using configuration file
		/// was in the requirements, I would probably have used Unity for the appSettings type binding. I realize writing the
		/// Assembly Full Name in the appsettings.json is just asking for a runtime error. This implemention allows for
		/// binding a single writer. If multiple writers is required then it would be a different pattern, such as chain of 
		/// responsibility with an array of writers, to be configured or turned off/on explicitly. 
		/// 
		/// </summary>
		/// <returns>void</returns>
		/// <param name="services">Services.</param>
		public static void Configure(IServiceCollection services)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", false)
			.Build();
			
			var section = configuration.GetSection("ConfigurationSettings");
			var writer = section["Writer"];
			Console.WriteLine(writer);
			var type = Type.GetType(writer);
			services.AddTransient(typeof(IMessageWriter), type);
			services.AddTransient<App>();
		}
    }
}
