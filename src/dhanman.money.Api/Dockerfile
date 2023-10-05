#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/dhanman.money.Api/dhanman.money.Api.csproj", "src/dhanman.money.Api/"]
COPY ["src/dhanman.money.Application/dhanman.money.Application.csproj", "src/dhanman.money.Application/"]
COPY ["src/dhanman.money.Domain/dhanman.money.Domain.csproj", "src/dhanman.money.Domain/"]
COPY ["src/dhanman.money.Persistence/dhanman.money.Persistence.csproj", "src/dhanman.money.Persistence/"]
RUN dotnet restore "src/dhanman.money.Api/dhanman.money.Api.csproj"
COPY . .
WORKDIR "/src/src/dhanman.money.Api"
RUN dotnet build "dhanman.money.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dhanman.money.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dhanman.money.Api.dll"]