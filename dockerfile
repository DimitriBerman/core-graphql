FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
COPY /src/MusicStore.csproj /app
RUN dotnet restore

COPY ./src ./app
RUN dotnet build -c Release -o ./app

FROM build AS publish
RUN dotnet publish -c Release -o ./app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./app/MusicStore.dll"]