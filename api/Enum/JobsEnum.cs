using System.Text.Json.Serialization;

namespace api.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobsEnum
    {
        Operational = 1,
        Admin = 2,
        Boss = 3
    }
}