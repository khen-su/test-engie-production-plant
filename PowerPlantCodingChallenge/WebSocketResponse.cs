using System;
using System.Text.Json;

namespace PowerPlantCodingChallenge
{
    public class WebSocketResponse
    {
        private readonly object _request;
        private readonly object _response;
        public WebSocketResponse(object request, object response)
        {
            _request = request;
            _response = response;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(new { Request = _request, Response = _response });
        }
    }
}
