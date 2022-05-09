using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public partial class ArticuloModel
    {
        [JsonProperty("articuloId")]
        public int ArticuloId { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("empresaId")]
        public int EmpresaId { get; set; }

        [JsonProperty("categoriaId")]
        public int CategoriaId { get; set; }

        [JsonProperty("familiaId")]
        public int FamiliaId { get; set; }

        [JsonProperty("unidadMedidaId")]
        public int UnidadMedidaId { get; set; }

        //AUX

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }

        [JsonProperty("familia")]
        public string Familia { get; set; }

        [JsonProperty("unidadMedida")]
        public string UnidadMedida { get; set; }

        [JsonProperty("habilitado")]
        public bool Habilitado { get; set; }
    }

    public partial class ArticuloModel
    {
        public static ArticuloModel FromJson(string json) => JsonConvert.DeserializeObject<ArticuloModel>(json, Models.Converter.Settings);
    }
}
