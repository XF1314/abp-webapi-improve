using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 将<see cref="IList{String}"/>以分隔符\3进行拼接
    /// </summary>
    public class MO2DataGrandStringListConverter : JsonConverter
    {
        /// <summary>
        /// 是否开启自定义反序列化，
        /// 值为true时，反序列化时会走ReadJson方法，值为false时，不走ReadJson方法，而是默认的反序列化
        /// </summary>
        public override bool CanRead { get { return true; } }

        /// <summary>
        /// 是否开启自定义序列化，
        /// 值为true时，序列化时会走WriteJson方法，值为false时，不走WriteJson方法，而是默认的序列化
        /// </summary>
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
                    items = Regex.Split(value.TrimEnd('\\'), @"\\3", RegexOptions.IgnorePatternWhitespace).ToList();
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
            writer.WriteValue(string.Join("\\3", strings));
        }
    }
}
