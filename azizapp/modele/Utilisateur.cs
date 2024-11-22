using SQLite;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace azizapp.models
{



    public class Utilisateur
    {


        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Nom")]
        public string Nom { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("PostPicker")]
        public string PostPicker { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }
    }

    public class ResponseData
    {
        [JsonProperty("items")]
        public List<Utilisateur> Items { get; set; }
    }




    public class admin
    {

        [PrimaryKey, NotNull]
        public String Id_admin { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(100), NotNull]
        public string Nom_admin { get; set; }

        [MaxLength(100), NotNull]
        public string Mail_admin { get; set; }

        [MaxLength(50), NotNull]
        public string Post_admin { get; set; }

        [MaxLength(30), NotNull]
        public string Password_admin { get; set; }

    }
    public class MessageModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id_message { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Contenu { get; set; }

        public DateTime SentTime { get; set; }

        [MaxLength(20)]
        [NotNull]
        public string Id_source { get; set; }

        public string Id_destination { get; set; }
    }
    public class notification
    {
        [PrimaryKey]
        public Guid Id_notification { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Contenu_notif { get; set; }

        [NotNull]
        public DateTime Date_notif { get; set; }

        [NotNull, Unique]
        public Guid Id_utilisateur { get; set; }

        [NotNull, Unique]
        public Guid Id_log { get; set; }

        public bool Lue { get; set; }
    }
}


