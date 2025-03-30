# Use the official .NET 9 ASP.NET runtime as a base image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 9 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project files and restore any dependencies
# Adjust the COPY command based on your solution structure
COPY *.sln ./
COPY ["BGtest.sln", "."]
COPY ["BGtest.API/", "BGtest.API/"]
COPY ["BGTest.Application/", "BGTest.Application/"]
COPY ["BGTest.Core/", "BGTest.Core/"]
COPY ["BGTest.Infrastructure/", "BGTest.Infrastructure/"]
COPY ["BGTest.Tests/", "BGTest.Tests/"]
RUN dotnet restore

# Copy the rest of the application code and publish the project in Release mode
COPY . .
RUN dotnet publish --no-restore BGtest.API/BGtest.API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Final stage: build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "BGtest.API.dll"]
