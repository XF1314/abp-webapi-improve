using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Newtonsoft.Json
{
    public  class ListAndSpacesSeparatedStringConverter:JsonConverter
    {
        public override bool CanRead { get { return true; } }

        public override bool CanWrite { get { return true; } }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(IList<string>));
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var items = new List<string>();
            if (reader.TokenType.ToString() == "StartArray")
                while (reader.TokenType.ToString() != "EndArray")
                    items.Add(reader.ReadAsString());
            else
            {
                var value = reader.Value as string;
                if (!string.IsNullOrEmpty(value))
                {
                    items = Regex.Split(value.TrimEnd(' '), @" ", RegexOptions.IgnorePatternWhitespace).ToList();
                    items.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                }
            }
            items.RemoveAll(x => string.IsNullOrWhiteSpace(x));

            return items;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var strings = value as IList<string>;
            writer.WriteValue(string.Join(" ", strings));
        }
    }
}
