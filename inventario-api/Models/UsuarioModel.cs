using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace inventario_api.Models
{
    public partial class UsuarioModel
    {
        [JsonProperty("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("clave")]
        public string Clave { get; set; }

        [JsonProperty("administrador")]
        public bool Administrador { get; set; }

        [JsonProperty("supervisor")]
        public bool Supervisor { get; set; }

        [JsonProperty("inventario")]
        public bool Inventario { get; set; }

        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }

        [JsonProperty("su")]
        public int Su { get; set; }
    }

    public partial class UsuarioLogin
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public partial class UsuarioModel
    {
        public static UsuarioModel FromJson(string json) => JsonConvert.DeserializeObject<UsuarioModel>(json, Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this UsuarioModel self) => JsonConvert.SerializeObject(self, Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

