using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.BpmService.Filters
{
    public class SwaggerEnumDocumentFilter : IDocumentFilter
    {
        private static readonly ImmutableList<string> assemblyNames = new List<string> {
            "Com.OPPO.Mo.Core",
            "Com.OPPO.Mo.Bpm.Application.Contracts" }.ToImmutableList();
        private static readonly Lazy<Dictionary<string, Type>> allEnumTypes = new Lazy<Dictionary<string, Type>>(GetAllEnumTypes(assemblyNames));

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var item in swaggerDoc.Components.Schemas)
            {
                var property = item.Value;
                var typeName = item.Key;
                if (property.Enum != null && property.Enum.Count > 0)
                {
                    var enumType = allEnumTypes.Value.ContainsKey(typeName) ? allEnumTypes.Value[typeName] : null;
                    var openApiIntegers = new List<OpenApiInteger>();
                    foreach (var enums in property.Enum)
                    {
                        openApiIntegers.Add((OpenApiInteger)enums);
                    }
                    property.Description += GetEnumDescription(enumType, openApiIntegers);
                }
            }
        }

        private static Dictionary<string, Type> GetAllEnumTypes(ImmutableList<string> assemblyNams)
        {
            var allEnums = new Dictionary<string, Type>();
            assemblyNams.ForEach(x =>
            {
                var enums = Assembly.Load(x).GetTypes().Where(y => y.IsEnum).ToList();
                enums.ForEach(z =>
                {
                    if (!allEnums.ContainsKey(z.FullName))
                        allEnums.Add(z.FullName, z);
                });

            });

            return allEnums;
        }

        private static string GetEnumDescription(Type enumType, List<OpenApiInteger> enumItems)
        {
            var enumItemDescriptions = new List<string>();
            foreach (var enumItem in enumItems)
            {
                if (enumType == null) continue;
                var enumValue = Enum.Parse(enumType, enumItem.Value.ToString());
                var enumItemDescription = GetEnumItemDescription(enumType, enumValue);
                if (string.IsNullOrEmpty(enumItemDescription))
                    enumItemDescriptions.Add($"{enumItem.Value}:{Enum.GetName(enumType, enumValue)}; ");
                else
                    enumItemDescriptions.Add($"{enumItem.Value}:{Enum.GetName(enumType, enumValue)},{enumItemDescription}; ");
            }

            return $"<br/>{Environment.NewLine}{string.Join("<br/>" + Environment.NewLine, enumItemDescriptions)}";
        }

        private static string GetEnumItemDescription(Type enumType, object enumValue)
        {
            foreach (var memberInfo in enumType.GetMembers())
            {
                if (memberInfo.Name == enumType.GetEnumName(enumValue))
                {
                    foreach (var attribute in Attribute.GetCustomAttributes(memberInfo))
                    {
                        if (attribute.GetType() == typeof(DescriptionAttribute))
                        {
                            return ((DescriptionAttribute)attribute).Description;
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}