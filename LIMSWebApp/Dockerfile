
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53251
EXPOSE 44399

#RUN chmod +x /entrypoint.sh
#CMD /bin/bash /entrypoint.sh

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["LIMSWebApp/LIMSWebApp.csproj", "LIMSWebApp/"]
COPY ["LIMSCore/LIMSCore.csproj", "LIMSCore/"]
COPY ["LIMSInfrastructure/LIMSInfrastructure.csproj", "LIMSInfrastructure/"]
RUN dotnet restore "LIMSWebApp/LIMSWebApp.csproj"

COPY . .
WORKDIR "/src/LIMSWebApp"
RUN dotnet build "LIMSWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LIMSWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LIMSWebApp.dll"]