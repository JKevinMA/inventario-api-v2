using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class LocalModel
    {
        [JsonProperty("localId")]
        public int LocalId { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }
    }

    public partial class LocalModel
    {
        public static LocalModel FromJson(string json) => JsonConvert.DeserializeObject<LocalModel>(json, Models.Converter.Settings);
    }

}

