FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
COPY ./api /api
WORKDIR /api
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

ENTRYPOINT ["dotnet", "run"]