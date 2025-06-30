using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Max.API.Models
{
	public class Bot: User
	{
		[JsonPropertyName("description")]
		public string? Description		{ get; init; }

		[JsonPropertyName("avatar_url")]
		public string? AvatarURL		{ get; init; }

		[JsonPropertyName("full_avatar_url")]
		public string? FullAvatarURL	{ get; init; }

		[JsonPropertyName("commands")]
		public IReadOnlyCollection<Command> Commands	{ get; init; } = [];

		public class Command
		{
			[JsonPropertyName("name")]
			public string Name			{ get; init; } = default!;

			[JsonPropertyName("description")]
			public string? Description	{ get; init; }
		}
	}
}
