FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY swTestApp/swTestApp.csproj swTestApp/
RUN dotnet restore swTestApp/swTestApp.csproj
COPY . .
WORKDIR /src/swTestApp
RUN dotnet build swTestApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish swTestApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "swTestApp.dll"]
