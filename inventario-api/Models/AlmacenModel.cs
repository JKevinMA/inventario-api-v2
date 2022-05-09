using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class AlmacenModel
    {
        [JsonProperty("almacenId")]
        public int AlmacenId { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("localId")]
        public int LocalId { get; set; }

        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }

        [JsonProperty("habilitado")]
        public bool Habilitado { get; set; }

    }

    public partial class AlmacenModel
    {
        public static AlmacenModel FromJson(string json) => JsonConvert.DeserializeObject<AlmacenModel>(json, Models.Converter.Settings);
    }
}
