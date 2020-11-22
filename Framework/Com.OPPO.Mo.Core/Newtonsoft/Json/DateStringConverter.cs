using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json
{

    /// <summary>
    /// <see cref="DateTime"/>与字符串Converter
    /// </summary>
    public class DateStringConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value as string);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd"));
        }
    }
}
