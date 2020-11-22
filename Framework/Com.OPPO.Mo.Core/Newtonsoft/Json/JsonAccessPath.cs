using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json
{
    public class JsonAccessPath
    {
        internal static string Combine(params string[] pathSegments) =>
            string.Join(":", pathSegments ?? throw new ArgumentNullException(nameof(pathSegments)));

        internal static string Combine(IEnumerable<string> pathSegments) =>
            string.Join(":", pathSegments ?? throw new ArgumentNullException(nameof(pathSegments)));
    }
}
