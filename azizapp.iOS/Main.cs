using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Création d'un client HTTP
        using (var client = new HttpClient())
        {
            // Définition de l'URL de votre serveur PocketBase pour créer un nouveau record
            string url = "http://localhost:8080/api/data";

            // Création des données à envoyer (par exemple, un objet JSON)
            string jsonData = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";

            // Création du contenu de la requête
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Envoi de la requête POST avec les données JSON
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Vérification de la réponse
                if (response.IsSuccessStatusCode)
                {
                    // Lecture de la réponse JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Affichage de la réponse
                    Console.WriteLine("Réponse JSON de PocketBase :");
                    Console.WriteLine(jsonResponse);

                    // Vous pouvez analyser la réponse JSON ici pour extraire des informations si nécessaire
                }
                else
                {
                    Console.WriteLine($"Échec de la création du nouveau record avec le code : {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Une erreur s'est produite lors de la requête HTTP : {e.Message}");
            }
        }
    }
}
