using System.Text.Json;

using Max.API.Models;

namespace Max.API.Test
{
	public class JsonToModels
	{
		[Fact]
		public void ToUser()
		{
			var json            = @"{ ""user_id"": 11, ""first_name"": ""Fname"", ""last_name"": ""Lname"", ""username"": ""User 11"", ""is_bot"": false, ""last_activity_time"": 1751320197164 }";
			var user            = JsonSerializer.Deserialize<User>(json);

			Assert.NotNull(user);
			Assert.Equal(11,			user.ID);
			Assert.Equal("Fname",		user.FirstName);
			Assert.Equal("Lname",		user.LastName);
			Assert.Equal("User 11",		user.UserName);
			Assert.False(user.IsBot);
			Assert.Equal(new DateTime(2025, 6, 30, 21,49,57, 164, DateTimeKind.Unspecified), user.LastActivity);
		}

		[Fact]
		public void ToBotWithoutCommands()
		{
			var json            = @"{ ""user_id"": 21, ""first_name"": ""Bot name"", ""username"": ""Botname_bot"", ""is_bot"": true, ""last_activity_time"": 1751320197164, ""description"": ""Bot info"", ""avatar_url"": ""https://avatar.local/21"", ""full_avatar_url"": null }";
			var bot				= JsonSerializer.Deserialize<Bot>(json);

			Assert.NotNull(bot);
			Assert.Equal(21,			bot.ID);
			Assert.Equal("Bot name",	bot.FirstName);
			Assert.Null(bot.LastName);
			Assert.Equal("Botname_bot", bot.UserName);
			Assert.True(bot.IsBot);
			Assert.Equal(new DateTime(2025, 6, 30, 21, 49, 57, 164, DateTimeKind.Unspecified), bot.LastActivity);
			Assert.Equal("Bot info",	bot.Description);
			Assert.Equal("https://avatar.local/21", bot.AvatarURL);
			Assert.Null(bot.FullAvatarURL);

			Assert.Empty(bot.Commands);
		}

		[Fact]
		public void ToBotWithCommands()
		{
			var json            = @"{ ""user_id"": 22, ""first_name"": ""Bot name"", ""username"": ""Botname_bot"", ""is_bot"": true, ""commands"": [ { ""name"": ""/help"", ""description"": ""GetHelp"" }, { ""name"": ""/start"" } ] }";
			var bot             = JsonSerializer.Deserialize<Bot>(json);

			Assert.NotNull(bot);
			Assert.Equal(22, bot.ID);
			Assert.Equal("Bot name", bot.FirstName);
			Assert.Null(bot.LastName);
			Assert.Equal("Botname_bot", bot.UserName);
			Assert.True(bot.IsBot);
			Assert.Equal(default, bot.LastActivity);
			Assert.Null(bot.Description);
			Assert.Null(bot.AvatarURL);
			Assert.Null(bot.FullAvatarURL);

			Assert.Collection(bot.Commands, [
				cmd =>
				{
					Assert.Equal("/help",	cmd.Name);
					Assert.Equal("GetHelp", cmd.Description);
				},
				cmd =>
				{
					Assert.Equal("/start",   cmd.Name);
					Assert.Null(cmd.Description);
				},
			]);
		}
	}
}