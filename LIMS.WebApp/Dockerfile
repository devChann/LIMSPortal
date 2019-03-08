
FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53251
EXPOSE 44399

#RUN chmod +x /entrypoint.sh
#CMD /bin/bash /entrypoint.sh

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY ["LIMS.WebApp/LIMS.WebApp.csproj", "LIMS.WebApp/"]
COPY ["LIMS.Core/LIMS.Core.csproj", "LIMS.Core/"]
COPY ["LIMS.Infrastructure/LIMS.Infrastructure.csproj", "LIMS.Infrastructure/"]
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
