# Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj e faz o restore
COPY Library.csproj ./
RUN dotnet restore ./Library.csproj

# Copia o conteúdo do projeto
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Fase final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Library.dll"]
