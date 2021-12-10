using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class TipoInventarioModel
    {
        [JsonProperty("tipoInventarioId")]
        public int TipoInventarioId { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }

    public partial class TipoInventarioModel
    {
        public static TipoInventarioModel FromJson(string json) => JsonConvert.DeserializeObject<TipoInventarioModel>(json, Models.Converter.Settings);
    }
}
