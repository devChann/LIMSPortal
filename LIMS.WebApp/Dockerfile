FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/tcp

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["LIMS.WebApp/LIMS.WebApp.csproj", "LIMS.WebApp/"]
COPY ["LIMS.Infrastructure/LIMS.Infrastructure.csproj", "LIMS.Infrastructure/"]
COPY ["LIMS.Core/LIMS.Core.csproj", "LIMS.Core/"]
RUN dotnet restore "LIMS.WebApp/LIMS.WebApp.csproj"

COPY . .
WORKDIR "/src/LIMS.WebApp"
RUN dotnet build "LIMS.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LIMS.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LIMS.WebApp.dll"]
