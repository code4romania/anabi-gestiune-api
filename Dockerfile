FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore && \
    dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/Anabi/out .
ENTRYPOINT ["dotnet", "Anabi.dll"]
