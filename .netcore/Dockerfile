# ---------- Step 1: Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into the container
COPY . .

# Go into the project directory
WORKDIR /src/AboutUsApi

# Restore dependencies
RUN dotnet restore

# Publish the app to a folder
RUN dotnet publish -c Release -o /app/publish

# ---------- Step 2: Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published files from the build stage
COPY --from=build /app/publish .

# Expose the port your app runs on (optional)
EXPOSE 8080

# Run the app (it will automatically run AboutUsApi.dll)
ENTRYPOINT ["dotnet", "AboutUsApi.dll"]
