# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["WebApplication1/AOUBook.csproj", "WebApplication1/"]
COPY ["WebApplication1.DataAccess/AOUBook.DataAccess.csproj", "WebApplication1.DataAccess/"]
COPY ["WebApplication1.Models/AOUBook.Models.csproj", "WebApplication1.Models/"]
COPY ["WebApplication1.Utility/AOUBook.Utility.csproj", "WebApplication1.Utility/"]
RUN dotnet restore "./WebApplication1/AOUBook.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
WORKDIR "/src/WebApplication1"
RUN dotnet build "./AOUBook.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AOUBook.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./WebApplication1/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "AOUBook.dll"]