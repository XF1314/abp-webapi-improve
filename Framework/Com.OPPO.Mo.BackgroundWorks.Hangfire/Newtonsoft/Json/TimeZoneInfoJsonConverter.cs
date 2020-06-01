using System;

namespace Newtonsoft.Json
{

    public class TimeZoneInfoJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(TimeZoneInfo);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;

			if (reader.Value == null) return null;

			return TimeZoneInfo.FindSystemTimeZoneById(reader.Value.ToString());
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var o = value as TimeZoneInfo;

			writer.WriteValue(o.StandardName);
		}
	}
}
