#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Acq.VideoSearch/Acq.VideoSearch.csproj", "Acq.VideoSearch/"]
COPY ["Acq.VideoSearch.Core/Acq.VideoSearch.Core.csproj", "Acq.VideoSearch.Core/"]
RUN dotnet restore "./Acq.VideoSearch/./Acq.VideoSearch.csproj"
COPY . .
WORKDIR "/src/Acq.VideoSearch"
RUN dotnet build "./Acq.VideoSearch.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Acq.VideoSearch.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acq.VideoSearch.dll"]