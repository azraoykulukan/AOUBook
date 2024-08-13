#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AOUBook.Api/AOUBook.Api.csproj", "AOUBook.Api/"]
COPY ["WebApplication1.DataAccess/AOUBook.DataAccess.csproj", "WebApplication1.DataAccess/"]
COPY ["WebApplication1.Models/AOUBook.Models.csproj", "WebApplication1.Models/"]
COPY ["WebApplication1.Utility/AOUBook.Utility.csproj", "WebApplication1.Utility/"]
RUN dotnet restore "./AOUBook.Api/AOUBook.Api.csproj"
COPY . .
WORKDIR "/src/AOUBook.Api"
RUN dotnet build "./AOUBook.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/AOUBook.Api"
RUN dotnet publish "./AOUBook.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AOUBook.Api.dll"]