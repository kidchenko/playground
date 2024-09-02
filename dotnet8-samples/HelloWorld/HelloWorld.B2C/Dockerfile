#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HelloWorld.B2C/HelloWorld.B2C.csproj", "HelloWorld.B2C/"]
RUN dotnet restore "HelloWorld.B2C/HelloWorld.B2C.csproj"
COPY . .
WORKDIR "/src/HelloWorld.B2C"
RUN dotnet build "HelloWorld.B2C.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWorld.B2C.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.B2C.dll"]