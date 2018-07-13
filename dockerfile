FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
COPY ./src /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

# RUN chmod +x ./entrypoint.sh
# CMD /bin/bash ./entrypoint.sh

ENTRYPOINT ["dotnet", "run"]