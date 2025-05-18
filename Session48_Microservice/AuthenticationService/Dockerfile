FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# tạo folder chứa source code
WORKDIR /app

# EXPOSE PORT 80
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

# build stage build để tạo thư mục build các dependency
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy file .csproj qua src docker
# file .csproj là file chứa các dependency của project (quan trọng của project)
# tương tự như file pom.xml trong java, file package.json trong nodejs
# copy file AuthenticationService.csproj qua folder AuthenticationService của docker
COPY ./AuthenticationService/AuthenticationService.csproj ./AuthenticationService/

# đảm bảo dependency được cài đặt trước khi build project
RUN dotnet restore AuthenticationService/AuthenticationService.csproj

# copy toàn bộ code từ local qua docker
COPY ./AuthenticationService/. ./AuthenticationService/

WORKDIR /src/AuthenticationService
RUN dotnet build "AuthenticationService.csproj" -c Release -o /app/build

# publish ứng dụng để deploy
FROM build AS publish
RUN dotnet publish "AuthenticationService.csproj" -c Release -o /app/publish -p:UseAppHost=false

# final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationService.dll"]
