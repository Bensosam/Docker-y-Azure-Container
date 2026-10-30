# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY GestionClientes.Blazor/GestionClientes.Blazor.csproj GestionClientes.Blazor/
RUN dotnet restore GestionClientes.Blazor/GestionClientes.Blazor.csproj
COPY GestionClientes.Blazor/ GestionClientes.Blazor/
RUN dotnet publish GestionClientes.Blazor/GestionClientes.Blazor.csproj -c Release -o /app/publish --no-restore

FROM nginx:1.27-alpine AS runtime
COPY GestionClientes.Blazor/nginx.conf.template /etc/nginx/templates/default.conf.template
COPY --from=build /app/publish/wwwroot/ /usr/share/nginx/html/
ENV API_UPSTREAM=http://api:8080
EXPOSE 8080
