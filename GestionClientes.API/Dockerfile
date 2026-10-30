# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY GestionClientes.API/GestionClientes.API.csproj GestionClientes.API/
RUN dotnet restore GestionClientes.API/GestionClientes.API.csproj
COPY GestionClientes.API/ GestionClientes.API/
RUN dotnet publish GestionClientes.API/GestionClientes.API.csproj -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
COPY --from=build /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "GestionClientes.API.dll"]
