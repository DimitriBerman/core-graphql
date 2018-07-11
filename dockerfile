FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /src
EXPOSE 80
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
RUN pwd
RUN ls
COPY /src/MusicStore.csproj .
RUN dotnet restore
RUN pwd
RUN ls
COPY ./src .
RUN dotnet build
RUN pwd
RUN ls
# FROM build AS publish
# RUN dotnet publish -c Release -o ./pub
# RUN pwd
# RUN ls
# FROM base AS final
# COPY --from=publish ./src/pub .
# RUN pwd
# RUN pwd
# RUN ls 
# RUN ls 
ENTRYPOINT ["dotnet", "MusicStore.dll"]