FROM mcr.microsoft.com/dotnet/aspnet:8.0.10-alpine3.20 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0.403 AS build
WORKDIR /src
COPY ["MigrationBundleDemo/MigrationBundleDemo.csproj", "MigrationBundleDemo/"]
RUN dotnet restore "MigrationBundleDemo/MigrationBundleDemo.csproj"
COPY . .
WORKDIR /src/MigrationBundleDemo/
RUN dotnet build "MigrationBundleDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MigrationBundleDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "MigrationBundleDemo.dll" ]