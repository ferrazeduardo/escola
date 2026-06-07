#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
EXPOSE 8080


FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /src
COPY ["Rede.Api/Rede.Api.csproj", "."]
RUN dotnet restore "./Rede.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Rede.Api/Rede.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rede.Api/Rede.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rede.Api.dll"]

