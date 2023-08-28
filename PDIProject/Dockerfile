# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["PDIProject/PDIProject.csproj", "PDIProject/"]
RUN dotnet restore "PDIProject/PDIProject.csproj"

# Copy the rest of the application code and build
COPY . .
WORKDIR "/src/PDIProject"
RUN dotnet build "PDIProject.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "PDIProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDIProject.dll"]
