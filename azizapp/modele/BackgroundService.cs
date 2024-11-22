using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace azizapp.modele
{
    public class BackgroundService
    {
        private const string PocketBaseUrl = "http://10.0.2.2:8090"; // Modifier l'URL selon votre configuration

        public async Task CheckAndNotifyNewNotifications()
        {
            // Récupérer toutes les notifications de la collection
            List<Notification> allNotifications = await GetAllNotifications();

            // Stocker localement les notifications récupérées
            await StoreNotificationsLocally(allNotifications);

            // Vérifier s'il y a de nouvelles notifications depuis la dernière vérification
            await CheckForNewNotifications(allNotifications);

            // Si une nouvelle notification est trouvée, déclencher une notification
        }

        private async Task<List<Notification>> GetAllNotifications()
        {
#pragma warning disable CS0168 // La variable est déclarée mais jamais utilisée
            try
            {
                string apiUrl = $"{PocketBaseUrl}/api/collections/notification/records";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var notificationsApiResponse = JsonConvert.DeserializeObject<NotificationsApiResponse>(content);
                    return notificationsApiResponse.Items;
                }
                else
                {
                    // Gérer l'échec de la récupération des notifications
                    return new List<Notification>();
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception
                return new List<Notification>();
            }
#pragma warning restore CS0168 // La variable est déclarée mais jamais utilisée
        }

        private async Task StoreNotificationsLocally(List<Notification> notifications)
        {
#pragma warning disable CS0168 // La variable est déclarée mais jamais utilisée
            try
            {
                // Convertir les notifications en chaîne JSON
                string json = JsonConvert.SerializeObject(notifications);

                // Stocker les notifications localement à l'aide de Xamarin.Essentials Secure Storage
                await SecureStorage.SetAsync("Notifications", json);
            }
            catch (Exception ex)
            {
                // Gérer l'exception
            }
#pragma warning restore CS0168 // La variable est déclarée mais jamais utilisée
        }

        private async Task CheckForNewNotifications(List<Notification> allNotifications)
        {
#pragma warning disable CS0168 // La variable est déclarée mais jamais utilisée
            try
            {
                // Récupérer les notifications précédemment stockées localement
                string storedNotificationsJson = await SecureStorage.GetAsync("Notifications");

                // Convertir la chaîne JSON en liste de notifications
                List<Notification> storedNotifications = JsonConvert.DeserializeObject<List<Notification>>(storedNotificationsJson);

                // Comparer les nouvelles notifications avec celles stockées localement pour trouver de nouvelles notifications
                foreach (var notification in allNotifications)
                {
                    if (!storedNotifications.Contains(notification))
                    {
                        // Nouvelle notification trouvée
                        // Déclencher une notification ou effectuer une autre action
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception
            }
#pragma warning restore CS0168 // La variable est déclarée mais jamais utilisée
        }
    }

    // Modèle de données pour les notifications
    public class Notification
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }

    // Classe de réponse pour les notifications
    public class NotificationsApiResponse
    {
        public List<Notification> Items { get; set; }
    }
}
