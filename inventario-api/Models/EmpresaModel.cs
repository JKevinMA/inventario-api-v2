using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class EmpresaModel
    {
        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("su")]
        public int Su { get; set; }

    }

    public partial class EmpresaModel
    {
        public static EmpresaModel FromJson(string json) => JsonConvert.DeserializeObject<EmpresaModel>(json, Models.Converter.Settings);
    }
}
