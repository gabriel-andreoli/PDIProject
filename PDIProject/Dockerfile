# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["PDIProject/PDIProject.csproj", "PDIProject/"]
RUN dotnet restore "PDIProject/PDIProject.csproj"
# Copy the rest of the application code
COPY . .

# Perform migrations and database update
WORKDIR /src/PDIProject
RUN dotnet ef migrations add DeployMigration -o Persistence/Migrations
RUN dotnet ef database update

# Publish the application
WORKDIR /src/PDIProject
RUN dotnet publish "PDIProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PDIProject.dll"]
