using System;
using WebSocket4Net;

namespace azizapp.home
{
    public class WebSocketManager
    {
        private readonly WebSocket _webSocket;

        public event EventHandler<string> NotificationReceived;

        public WebSocketManager()
        {
            string websocketUrl = "ws://your_websocket_server_url";
            _webSocket = new WebSocket(websocketUrl);
            _webSocket.MessageReceived += OnMessageReceived;
            _webSocket.Open();
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            NotificationReceived?.Invoke(this, e.Message);
        }

        public void Close()
        {
            _webSocket.Close();
        }
    }
}
