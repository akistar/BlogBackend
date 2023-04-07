FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.17-arm64v8 AS build
WORKDIR /source

COPY *.csproj .
RUN dotnet restore -r linux-musl-arm64


COPY . .
RUN dotnet publish -c Release -o /app -r linux-musl-arm64 --self-contained false --no-restore

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.17-arm64v8
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT [ "./TodoApi" ]



