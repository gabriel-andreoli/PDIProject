# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["PDIProject/PDIProject.csproj", "PDIProject/"]
RUN dotnet restore "PDIProject/PDIProject.csproj"
# Copy the rest of the application code
COPY . .

# Stage 2: Run Entity Framework Migrations
FROM build AS migration
WORKDIR /src/PDIProject

# Install the EF Core CLI tool
#RUN dotnet tool install --global dotnet-ef --version 7.0.9
#
## Add the EF Core CLI tool to the PATH
#ENV PATH="${PATH}:/root/.dotnet/tools"
#
## Perform migrations and database update
#RUN dotnet ef migrations add DeployMigration -o Persistence/Migrations
#RUN dotnet ef database update
#
# Stage 3: Publish the application
FROM migration AS publish
WORKDIR /src/PDIProject
RUN dotnet publish "PDIProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDIProject.dll"]

