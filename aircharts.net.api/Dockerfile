FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /code

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /output

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /output /app
ENTRYPOINT ["dotnet", "aircharts.net.api.dll"]