using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace azizapp
{
    public class ResponseData
    {
#pragma warning disable CS0649 // Le champ 'ResponseData.items' n'est jamais assigné et aura toujours sa valeur par défaut null
        internal IEnumerable items;
#pragma warning restore CS0649 // Le champ 'ResponseData.items' n'est jamais assigné et aura toujours sa valeur par défaut null

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("perPage")]
        public int PerPage { get; set; }

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("items")]
        public List<Utilisateur> Items { get; set; }
    }

}