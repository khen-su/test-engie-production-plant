FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app
COPY PowerPlantCodingChallenge/bin/Debug/netcoreapp3.1/publish .

ENTRYPOINT ["dotnet", "PowerPlantCodingChallenge.dll"]