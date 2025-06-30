using Microsoft.Extensions.Configuration;

namespace Max.API.Test.Init
{
	internal class Settings
	{
		private static Settings? _instance;
		private static readonly string _invalidvalue = "--- from settings.secret.json ---";

		public static Settings Get(string path = "./")
		{
			return _instance ??= new Settings(path);
		}

		private Settings(string path)
		{
			new ConfigurationBuilder()
				//.SetBasePath(path)
				.AddJsonFile("settings.json", false)
				.AddJsonFile("settings.secret.json", false)
				.Build()
				.Bind(this);

			Assert.NotNull(AccessToken);
			Assert.NotEmpty(AccessToken);
			Assert.NotEqual(_invalidvalue, AccessToken);
			Assert.NotEqual(0, TestBotID);
			Assert.NotNull(TestBotUserName);
			Assert.NotEmpty(TestBotUserName);
			Assert.NotEqual(_invalidvalue, TestBotUserName);
		}

		public string AccessToken		{ get; init; }

		public long TestBotID			{ get; init; }

		public string TestBotUserName	{ get; init; }
	}
}
