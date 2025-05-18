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
# copy file EmailService.csproj qua folder EmailService của docker
COPY ./EmailService/EmailService.csproj ./EmailService/

# đảm bảo dependency được cài đặt trước khi build project
RUN dotnet restore EmailService/EmailService.csproj

# copy toàn bộ code từ local qua docker
COPY ./EmailService/. ./EmailService/

WORKDIR /src/EmailService
RUN dotnet build "EmailService.csproj" -c Release -o /app/build

# publish ứng dụng để deploy
FROM build AS publish
RUN dotnet publish "EmailService.csproj" -c Release -o /app/publish -p:UseAppHost=false

# final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailService.dll"]
