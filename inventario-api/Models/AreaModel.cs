using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class AreaModel
    {
        [JsonProperty("areaId")]
        public int AreaId { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("almacenId")]
        public int AlmacenId { get; set; }

        [JsonProperty("almacen")]
        public string Almacen { get; set; }

        [JsonProperty("localId")]
        public int LocalId { get; set; }

        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }
    }

    public partial class AreaModel
    {
        public static AreaModel FromJson(string json) => JsonConvert.DeserializeObject<AreaModel>(json, Models.Converter.Settings);
    }
}
