# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY MyFirstShopifyApp/*.csproj ./MyFirstShopifyApp/
RUN dotnet restore

# Copy everything and build
COPY MyFirstShopifyApp/. ./MyFirstShopifyApp/
WORKDIR /src/MyFirstShopifyApp
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 for Render (Render forwards traffic here)
EXPOSE 8080

# Run the app
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "MyFirstShopifyApp.dll"]