using Newtonsoft.Json;
using System;

namespace Backend.Kubernetes.API.Domain.Models
{
    public class GetPersonaNaturalResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rut")]
        public int Rut { get; set; }

        [JsonProperty("dv")]
        public string Dv { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("sexoId")]
        public int SexoId { get; set; }

        [JsonProperty("fechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [JsonProperty("fechaFallecimiento")]
        public DateTime? FechaFallecimiento { get; set; }

        [JsonProperty("isapreId")]
        public int IsapreId { get; set; }

        [JsonProperty("afpId")]
        public int AfpId { get; set; }

        [JsonProperty("nacionalidadId")]
        public int NacionalidadId { get; set; }

        [JsonProperty("tipoPersona")]
        public string TipoPersona { get; set; }

        [JsonProperty("contactoComercial")]
        public ContactoComercial ContactoComercial { get; set; }

        [JsonProperty("contactoParticular")]
        public ContactoParticular ContactoParticular { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ContactoComercial
    {
        [JsonProperty("tipoDireccionComercialId")]
        public int TipoDireccionComercialId { get; set; }

        [JsonProperty("direccionComercial")]
        public string DireccionComercial { get; set; }

        [JsonProperty("emailComercial")]
        public string EmailComercial { get; set; }

        [JsonProperty("telefonoComercial")]
        public string TelefonoComercial { get; set; }

        [JsonProperty("celularComercial")]
        public string CelularComercial { get; set; }

        [JsonProperty("comunaComercialId")]
        public int ComunaComercialId { get; set; }

        [JsonProperty("comunaComercial")]
        public string ComunaComercial { get; set; }

        [JsonProperty("regionComercial")]
        public string RegionComercial { get; set; }

        [JsonProperty("regionComercialId")]
        public int RegionComercialId { get; set; }

        [JsonProperty("paisComercialId")]
        public int PaisComercialId { get; set; }

        [JsonProperty("paisComercial")]
        public string PaisComercial { get; set; }

        [JsonProperty("provinciaComercialId")]
        public int ProvinciaComercialId { get; set; }

        [JsonProperty("provinciaComercial")]
        public string ProvinciaComercial { get; set; }
    }

    public class ContactoParticular
    {
        [JsonProperty("tipoDireccionParticularId")]
        public int TipoDireccionParticularId { get; set; }

        [JsonProperty("direccionParticular")]
        public string DireccionParticular { get; set; }

        [JsonProperty("emailParticular")]
        public string EmailParticular { get; set; }

        [JsonProperty("telefonoParticular")]
        public string TelefonoParticular { get; set; }

        [JsonProperty("celularParticular")]
        public string CelularParticular { get; set; }

        [JsonProperty("comunaParticularId")]
        public int ComunaParticularId { get; set; }

        [JsonProperty("comunaParticular")]
        public string ComunaParticular { get; set; }

        [JsonProperty("regionParticularId")]
        public int RegionParticularId { get; set; }

        [JsonProperty("regionParticular")]
        public string RegionParticular { get; set; }

        [JsonProperty("paisParticularId")]
        public int PaisParticularId { get; set; }

        [JsonProperty("paisParticular")]
        public string PaisParticular { get; set; }

        [JsonProperty("provinciaParticularId")]
        public int ProvinciaParticularId { get; set; }

        [JsonProperty("provinciaParticular")]
        public string ProvinciaParticular { get; set; }
    }

}
