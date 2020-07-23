#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Producer.Api/Producer.Api.csproj", "Producer.Api/"]
RUN dotnet restore "Producer.Api/Producer.Api.csproj"
COPY . .
WORKDIR "/src/Producer.Api"
RUN dotnet build "Producer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Producer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Producer.Api.dll"]