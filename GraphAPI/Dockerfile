FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23195
EXPOSE 44393

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY GraphAPI/GraphAPI.csproj GraphAPI/
RUN dotnet restore GraphAPI/GraphAPI.csproj
COPY . .
WORKDIR /src/GraphAPI
RUN dotnet build GraphAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GraphAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphAPI.dll"]
