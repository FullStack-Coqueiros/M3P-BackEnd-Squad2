using System.Text.Json.Serialization;

namespace MedicalCare.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ETipoDieta
    {
        lowcarb = 0,
        dash = 1,
        paleolitica = 2,
        cetogenica = 3,
        dukan = 4,
        mediterranea = 5,
        outra = 6
    }
}



