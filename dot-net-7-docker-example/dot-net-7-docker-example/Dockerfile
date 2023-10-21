#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["dot-net-7-docker-example/dot-net-7-docker-example.csproj", "dot-net-7-docker-example/"]
RUN dotnet restore "dot-net-7-docker-example/dot-net-7-docker-example.csproj"
COPY . .
WORKDIR "/src/dot-net-7-docker-example"
RUN dotnet build "dot-net-7-docker-example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dot-net-7-docker-example.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dot-net-7-docker-example.dll"]