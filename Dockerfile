#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh

COPY ["DEBUG_API/DEBUG_API.csproj", "DEBUG_API/"]
COPY ["COMMON/COMMON.csproj", "COMMON/"]
COPY ./nuget.config ./
ARG FEED_ACCESSTOKEN
ARG FEED_PATH

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS "{\"endpointCredentials\": [{\"endpoint\":\"${FEED_PATH}\", \"username\":\"docker\", \"password\":\"${FEED_ACCESSTOKEN}\"}]}"
RUN dotnet restore "DEBUG_API/DEBUG_API.csproj"

COPY . .
WORKDIR "/src/DEBUG_API"
RUN dotnet build "DEBUG_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DEBUG_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DEBUG_API.dll"]