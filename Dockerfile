FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo .csproj
COPY Library/Library.csproj ./Library/
RUN dotnet restore ./Library/Library.csproj

# Copia todos os arquivos da pasta Library
COPY Library/ ./Library/
WORKDIR /src/Library
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Library.dll"]
