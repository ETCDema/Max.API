using Max.API.Test.Init;

namespace Max.API.Test
{
	public class ClientMain
	{
		[Fact]
		public void GetMe()
		{
			var settings        = Settings.Get();
			using var client    = new Client(settings.AccessToken);

			var bot             = client.Me();
			Assert.NotNull(bot);
			Assert.Equal(settings.TestBotID, bot.ID);
			Assert.Equal(settings.TestBotUserName, bot.UserName);
			Assert.True(bot.IsBot);
		}
	}
}
