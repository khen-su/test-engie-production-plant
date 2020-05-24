# ReadMe
Hello there,

This application was written in **C# 9**, **ASP.NET CORE 3.1** In Visual Studio 2019 but seeing that no tech-specific features of the latest version  have been used , it should work from **C# 6**, **ASP.NET CORE 2.0** upward.

## Requisites

### To setup the server
* A computer
* A free *8888* port
* [.NET CORE SDK](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.300-macos-x64-installer)
* Visual Studio (preferably 2019 but 2017 should do, too) or Visual Studio Code.

### To make the request

* Any client able to make HTTP Requests with a payload
* BONUS : *a SignalR client (will have to call endpoint /ws)*


## Launch instruction

1) * dotnet run PowerPlantCodingChallenge.sln in the root app folder
2) * open the solution file (PowerPlantCodingChallenge.sln) with Visual Studio (or VS Code). 
    * Make sure the startup project is PowerPlantCodingChallenge
    * Run

## What can be done

* Calling the endpoint *https://localhost:8888/productionplan* with HTTP POST and a payload of type:

```json
{
  "load": 0,
  "fuels": {
    "gas(euro/MWh)": 0,
    "kerosine(euro/MWh)": 0,
    "co2(euro/ton)": 0,
    "wind(%)": 0
  },
  "powerplants": [
    {
      "name": "string",
      "type": "string",
      "efficiency": 0,
      "pmin": 0,
      "pmax": 0
    }
  ]
}
```

*(instruction detailed on swagger page)*

* Registering to the websocket hub *https://localhost:8888/ws* (I have provided a SimpleWebSocketClient to give you an example)

### Remarks

* *To be completely honest with you, it's my first time with SignalR so my code for that part will be sub-optimal, feel free to ignore that part if it seems too hard to make it work on your side*

* Thanks a lot for reviewing!