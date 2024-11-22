using Xamarin.Forms;
using static azizapp.home.receivemessage;

namespace azizapp.messs
{
    public class MessageItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SentMessageTemplate { get; set; }
        public DataTemplate ReceivedMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // Vérifiez si l'élément est un message envoyé ou reçu et retournez le modèle de données approprié
            if (item is MessageItem message)
            {
                if (message.Id_source == App.CurrentUserId)
                    return SentMessageTemplate;
                else
                    return ReceivedMessageTemplate;
            }

            return null;
        }
    }
}
