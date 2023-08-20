FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app

COPY ./graph-api/ ./

RUN dotnet publish "./graph-api.csproj" -c Release -o ./out/

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 80
WORKDIR /app
COPY --from=build /app/out/ .
RUN apt-get update && apt-get install -y curl
ENTRYPOINT ["dotnet", "graph-api.dll"]
