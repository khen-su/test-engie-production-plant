using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Web.WebSockets;

namespace PowerPlantCodingChallenge
{
    public class SimpleWebSocketHandler: WebSocketHandler

    {

        private static WebSocketCollection _wsClients = new WebSocketCollection();
        public override void OnOpen()

        {
            _wsClients.Add(this);
            base.OnOpen();
        }

        public override void OnClose()

        {
            _wsClients.Remove(this);
            base.OnClose();
        }

        public void SendMessage(WebSocketResponse response)
        {
            OnOpen();
            _wsClients.Broadcast(JsonSerializer.Serialize(response));
        }
        }
    }
