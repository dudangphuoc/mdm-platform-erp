FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MDMPlatform.Web.Host/MDMPlatform.Web.Host.csproj", "src/MDMPlatform.Web.Host/"]
COPY ["src/MDMPlatform.Web.Core/MDMPlatform.Web.Core.csproj", "src/MDMPlatform.Web.Core/"]
COPY ["src/MDMPlatform.Application/MDMPlatform.Application.csproj", "src/MDMPlatform.Application/"]
COPY ["src/MDMPlatform.Core/MDMPlatform.Core.csproj", "src/MDMPlatform.Core/"]
COPY ["src/MDMPlatform.EntityFrameworkCore/MDMPlatform.EntityFrameworkCore.csproj", "src/MDMPlatform.EntityFrameworkCore/"]
WORKDIR "/src/src/MDMPlatform.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MDMPlatform.Web.Host", "src/MDMPlatform.Web.Host"]
COPY ["src/MDMPlatform.Web.Core", "src/MDMPlatform.Web.Core"]
COPY ["src/MDMPlatform.Application", "src/MDMPlatform.Application"]
COPY ["src/MDMPlatform.Core", "src/MDMPlatform.Core"]
COPY ["src/MDMPlatform.EntityFrameworkCore", "src/MDMPlatform.EntityFrameworkCore"]
WORKDIR "/src/src/MDMPlatform.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MDMPlatform.Web.Host.dll"]
