FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23196
EXPOSE 44313

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MusicStore/MusicStore.csproj MusicStore/
RUN dotnet restore MusicStore/MusicStore.csproj
COPY . .
WORKDIR /src/MusicStore
RUN dotnet build MusicStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MusicStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MusicStore.dll"]
