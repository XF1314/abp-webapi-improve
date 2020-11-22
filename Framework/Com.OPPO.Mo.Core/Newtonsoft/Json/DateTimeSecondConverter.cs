using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json
{
    public class DateTimeSecondConverter : JsonConverter
    {
        public static readonly DateTime EraTime = new DateTime(1970, 1, 1);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ConvertStampToDateTime(long.Parse(reader.Value.ToString()));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var totalSeconds = ConvertDateTimeToStamp((DateTime)value);
            if (totalSeconds < 0) totalSeconds = 0;

            writer.WriteValue(totalSeconds);
        }

        public long ConvertDateTimeToStamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - EraTime).Ticks / 10000000;
        }

        public DateTime ConvertStampToDateTime(long seconds)
        {
            return EraTime.AddSeconds(seconds);
        }
    }
}
