using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newtonsoft.Json.Linq
{
    public static class JObjectExtensions
    {
        private static List<JTokenType> availiablePropertyTypes = new List<JTokenType>(new JTokenType[] {
                JTokenType.String, JTokenType.Integer, JTokenType.Float, JTokenType.Boolean,JTokenType.String,
                JTokenType.Null, JTokenType.Date, JTokenType.Bytes, JTokenType.Guid, JTokenType.Uri, JTokenType.TimeSpan });
        private static List<JTokenType> availiableObjectTypes = new List<JTokenType>(new JTokenType[] { JTokenType.Array, JTokenType.Object });

        /// <summary>
        /// 将<see cref="JObject"对象解析为<see cref="SortedDictionary{string, string}"/>
        /// </summary>
        /// <param name="jObject"><see cref="JObject"/></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> ConvertToSortedDictionary(this JObject jObject)
        {
            var sortedDictionary = new SortedDictionary<string, string>();
            ParseJObject2SortedDictionary(sortedDictionary, jObject);

            return sortedDictionary;
        }

        private static void ParseJObject2SortedDictionary(SortedDictionary<string, string> sortedDictionary, JObject jObject)
        {
            var jObjectProperties = jObject.Properties();
            foreach (JProperty jProperty in jObjectProperties)
            {
                if (availiablePropertyTypes.Contains(jProperty.Value.Type))
                {
                    ParseJsonKeyValue(sortedDictionary, jProperty);
                }
                else if (availiableObjectTypes.Contains(jProperty.Value.Type))
                {
                    if (jProperty.Value.Type == JTokenType.Array && jProperty.Value.HasValues)
                    {
                        ParseJsonArray(sortedDictionary, jProperty);
                    }

                    if (jProperty.Value.Type == JTokenType.Object)
                    {
                        var jObject1 = new JObject();
                        jObject1 = JObject.Parse(jProperty.Value.ToString());
                        var paramName = jProperty.Name.ToString();
                        sortedDictionary.Add(paramName, jProperty.Value.ToString());
                        if (jObject1.HasValues)
                        {
                            ParseJObject2SortedDictionary(sortedDictionary, jObject1);
                        }
                    }
                }
            }
        }

        private static void ParseJsonKeyValue(SortedDictionary<string, string> sortedDictionary, JProperty jProperty)
        {
            sortedDictionary.Add(jProperty.Name, jProperty.Value.ToString());
        }

        private static void ParseJsonArray(SortedDictionary<string, string> sortedDictionary, JProperty jProperty)
        {
            var jArray = (JArray)jProperty.Value;
            var paramName = jProperty.Name.ToString();
            sortedDictionary.Add(paramName, jProperty.Value.ToString());
            for (int i = 0; i < jArray.Count; i++)
            {
                paramName = i.ToString();
                sortedDictionary.Add(paramName, jArray.Values().ElementAt(i).ToString());

                var jObject = new JObject();
                jObject = JObject.Parse(jArray[i].ToString());
                var jProperties = jObject.Properties();
                foreach (JProperty jPropertyItem in jProperties)
                {
                    var jPropertyItemValue = jPropertyItem.Value.ToString(Formatting.None);
                    if (jPropertyItemValue.Length > 0)
                    {
                        switch (jPropertyItemValue.Substring(0, 1))
                        {
                            case "[":
                                ParseJsonArray(sortedDictionary, jPropertyItem);
                                break;
                            case "{":
                                var jObject1 = new JObject();
                                jObject1 = JObject.Parse(jPropertyItemValue);
                                ParseJObject2SortedDictionary(sortedDictionary, jObject1);
                                break;
                            default:
                                ParseJsonKeyValue(sortedDictionary, jPropertyItem);
                                break;
                        }
                    }
                }
            }
        }

    }
}
