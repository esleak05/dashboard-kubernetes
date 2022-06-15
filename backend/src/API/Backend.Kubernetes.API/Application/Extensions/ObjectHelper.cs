using Newtonsoft.Json;
using System;

namespace Backend.Kubernetes.API.Application.Extensions
{
    public static class ObjectHelper
    {
        public static string Dump<T>(this T obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }
    }
}
