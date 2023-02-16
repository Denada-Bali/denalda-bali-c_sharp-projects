# Use the official Microsoft .NET Core runtime as a parent image
//FROM mcr.microsoft.com/dotnet/sdk:5.0
FROM mcr.microsoft.com/dotnet/sdk:6.0 As build-env

# Set the working directory in the container to /app
WORKDIR /app

# Copy the contents of the C# project into the container at /app
COPY . /app

# Restore as distinct layers
RUN dotnet restore

# Build the C# project
RUN dotnet build

# Build and publish a release 
RUN dotnet publish -c Release -o out

# Expose port 5000 for the web application to listen on
EXPOSE 5000

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=bild-env /app/out .

# Start the web application when the container starts
ENTRYPOINT ["dotnet", "run"]

