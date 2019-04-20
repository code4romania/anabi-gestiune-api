FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore && \
    dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/Anabi/out .
ENTRYPOINT ["dotnet", "Anabi.dll"]
