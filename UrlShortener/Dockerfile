# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and 
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish the release
RUN dotnet publish -o out

# runtime stage

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "UrlShortener.dll"]



