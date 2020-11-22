using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json
{
    public class DateTimeMillisecondConverter : JsonConverter
    {
        public static readonly DateTime EraTime = new DateTime(1970, 1, 1);

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null)
                return null;
            else
                return ConvertStampToDateTime(long.Parse(reader.Value.ToString()));
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is null)
                writer.WriteValue(0);
            else
            {
                var totalSeconds = ConvertDateTimeToStamp((DateTime)value);
                if (totalSeconds < 0) totalSeconds = 0;

                writer.WriteValue(totalSeconds);
            }
        }

        private long ConvertDateTimeToStamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - EraTime).Ticks / 10000;
        }

        public DateTime ConvertStampToDateTime(long milliseconds)
        {
            return EraTime.AddMilliseconds(milliseconds);
        }


    }
}
