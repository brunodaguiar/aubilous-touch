#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AubilousTouch.Api/AubilousTouch.Api.csproj", "AubilousTouch.Api/"]
RUN dotnet restore "AubilousTouch.Api/AubilousTouch.Api.csproj"
COPY . .
WORKDIR "/src/AubilousTouch.Api"
RUN dotnet build "AubilousTouch.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "AubilousTouch.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AubilousTouch.Api.dll"]