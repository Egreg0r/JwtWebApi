#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM postgres:9.4
RUN localedef -i de_DE -c -f UTF-8 -A /usr/share/locale/locale.alias de_DE.UTF-8
ENV LANG ru_RU.utf8
EXPOSE 5432
CMD ["postgres"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM postgres:latest
EXPOSE 5432
COPY dbscripts/10-init.sql /docker-entrypoint-initdb.d/10-init.sql
COPY dbscripts/20-damienbod.sql /docker-entrypoint-initdb.d/20-database.sql

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JwtWebApi/JwtWebApi.csproj", "JwtWebApi/"]
RUN dotnet restore "JwtWebApi/JwtWebApi.csproj"
COPY . .
WORKDIR "/src/JwtWebApi"
RUN dotnet build "JwtWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JwtWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JwtWebApi.dll"]