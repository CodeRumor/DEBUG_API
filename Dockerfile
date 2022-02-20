#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh

COPY ["DEBUG_COPPO_API/DEBUG_COPPO_API.csproj", "DEBUG_COPPO_API/"]
COPY ["COMMON/COMMON.csproj", "COMMON/"]
COPY ./nuget.config ./

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS "{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/ugololeivan-yahoo/CodeRumor/_packaging/DataAccessLibraryFeed/nuget/v3/index.json\", \"username\":\"docker\", \"password\":\"4xt2hdtrrxgu67b3eoszkh5yhg4zxr2d5q2xmbb4sfhize4gnx2q\"}]}"
RUN dotnet restore "DEBUG_COPPO_API/DEBUG_COPPO_API.csproj"

COPY . .
WORKDIR "/src/DEBUG_COPPO_API"
RUN dotnet build "DEBUG_COPPO_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DEBUG_COPPO_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DEBUG_COPPO_API.dll"]