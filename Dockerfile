FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /build

COPY . .

RUN dotnet restore "src/ErpBackend.WebAPI/ErpBackend.WebAPI.csproj" --force --no-cache
RUN dotnet publish "src/ErpBackend.WebAPI/ErpBackend.WebAPI.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS final

WORKDIR /app
COPY --from=build /app .

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "ErpBackend.WebAPI.dll"]