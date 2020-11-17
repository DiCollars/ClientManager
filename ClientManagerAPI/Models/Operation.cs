using System.Text.Json.Serialization;

namespace ClientManagerAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Operation
    {
        Decrease,
        Increase
    }
}
