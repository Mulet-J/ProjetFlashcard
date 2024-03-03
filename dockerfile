# Use the official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the project file and restore dependencies
COPY . ./
RUN dotnet restore ProjetFlashcard.sln
COPY ./appsettings.docker.json ./appsettings.json
EXPOSE 5285
ENTRYPOINT [ "dotnet", "run", "--project", "WebApi/WebApi.csproj" ]

# Copy the remaining files and build the application
#RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# COPY ./appsettings.docker.json ./appsettings.json
# ENTRYPOINT ["dotnet", "WebApi.dll"]