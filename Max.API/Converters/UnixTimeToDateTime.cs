using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Max.API.Converters
{
	internal class UnixTimeToDateTime: JsonConverter<DateTime>
	{
		private static readonly DateTime _EPOCH = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return _EPOCH.AddMilliseconds(reader.GetInt64());
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}
