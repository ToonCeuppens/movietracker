# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the csproj and restore any dependencies (via dotnet restore)
COPY ["MovieTrackerAPI.csproj", "./"]
RUN dotnet restore "MovieTrackerAPI.csproj"

# Publish to /app
WORKDIR "/src/."
COPY . .
RUN dotnet publish "MovieTrackerAPI.csproj" -c Release -o /app

# Use the ASP.NET runtime for our final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

COPY --from=build /app .

# Define the entry point of the Docker container to be the .NET application
ENTRYPOINT ["dotnet", "MovieTrackerAPI.dll"]
