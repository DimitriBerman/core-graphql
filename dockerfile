FROM         microsoft/dotnet-alpine
COPY         ./src /app
WORKDIR      /app
RUN dotnet restore
ENTRYPOINT   ["dotnet", "MusicStore.dll"]