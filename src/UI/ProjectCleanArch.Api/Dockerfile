#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UI/ProjectCleanArch.Api/ProjectCleanArch.Api.csproj", "src/UI/ProjectCleanArch.Api/"]
COPY ["src/Infrastructure/ProjectCleanArch.Ioc/ProjectCleanArch.Ioc.csproj", "src/Infrastructure/ProjectCleanArch.Ioc/"]
COPY ["src/Infrastructure/ProjectCleanArch.Data/ProjectCleanArch.Data.csproj", "src/Infrastructure/ProjectCleanArch.Data/"]
COPY ["src/Core/ProjectCleanArch.Domain/ProjectCleanArch.Domain.csproj", "src/Core/ProjectCleanArch.Domain/"]
COPY ["src/Application/ProjectCleanArch.Application/ProjectCleanArch.Application.csproj", "src/Application/ProjectCleanArch.Application/"]
RUN dotnet restore "src/UI/ProjectCleanArch.Api/ProjectCleanArch.Api.csproj"
COPY . .
WORKDIR "/src/src/UI/ProjectCleanArch.Api"
RUN dotnet build "ProjectCleanArch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectCleanArch.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectCleanArch.Api.dll"]