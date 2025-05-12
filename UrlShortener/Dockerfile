# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet publish -c Release -o out

#runtime stage

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "UrlShortener.dll"]



