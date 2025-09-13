#
# \file Dockerfile
# \brief Dockerfile to create an image for building and running the backend application
#
# This Dockerfile implements a multi-stage build:
# - Builds the application using the .NET SDK image
# - Publishes the app for production
# - Runs the app on a lightweight ASP.NET runtime image under a non-root user
#
# Exposes ports 8080 and 8081 for the backend service
#
# \date 10-09-2025                                                                                                                                                                                             
# \updated 13-09-2025
#

ARG DOTNET_VERSION=8.0
ARG DOTNET_CONFIGURATION=Release

#
# BASE
#
FROM mcr.microsoft.com/dotnet/aspnet:$DOTNET_VERSION AS base

RUN addgroup -S app && adduser -S -G app app

WORKDIR /app

RUN chown -R app:app /app

USER app

EXPOSE 8080
EXPOSE 8081

#
# BUILD
#
FROM mcr.microsoft.com/dotnet/sdk:$DOTNET_VERSION AS builder

WORKDIR /src

COPY apps/backend/Transacto.sln ./
COPY apps/backend/Transacto.API/Transacto.API.csproj ./Transacto.API/
COPY apps/backend/Transacto.Application/Transacto.Application.csproj ./Transacto.Application/
COPY apps/backend/Transacto.Domain/Transacto.Domain.csproj ./Transacto.Domain/
COPY apps/backend/Transacto.Infrastructure/Transacto.Infrastructure.csproj ./Transacto.Infrastructure/

RUN dotnet restore Transacto.sln

COPY apps/backend/ ./

RUN dotnet build Transacto.sln -c $DOTNET_CONFIGURATION -o /app/build

#
# PUBLISH
#
FROM builder AS publish

RUN dotnet publish "Transacto.API/Transacto.API.csproj" -c $DOTNET_CONFIGURATION -o /app/publish

#
# PRODUCTION
#
FROM base AS production

WORKDIR /app

COPY --from=builder /app/publish .

ENTRYPOINT ["dotnet", "Transacto.API.dll"]
