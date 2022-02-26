FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY WebApi/WebApi.csproj .
RUN dotnet restore

COPY WebApi .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .

# Local
# ENTRYPOINT ["dotnet", "WebApi.dll"]

# Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApi.dll