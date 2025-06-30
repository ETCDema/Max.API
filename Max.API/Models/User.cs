using System;
using System.Text.Json.Serialization;

using Max.API.Converters;

namespace Max.API.Models
{
	public class User
	{
		[JsonPropertyName("user_id")]
		public long ID					{ get; init; }

		[JsonPropertyName("first_name")]
		public string FirstName			{ get; init; } = default!;

		[JsonPropertyName("last_name")]
		public string? LastName			{ get; init; }

		[JsonPropertyName("username")]
		public string? UserName			{ get; init; }

		[JsonPropertyName("is_bot")]
		public bool IsBot				{ get; init; }

		[JsonPropertyName("last_activity_time")]
		[JsonConverter(typeof(UnixTimeToDateTime))]
		public DateTime LastActivity	{ get; init; }
	}
}
