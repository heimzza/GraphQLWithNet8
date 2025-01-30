FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GraphQLWithNet8/GraphQLWithNet8.csproj", "GraphQLWithNet8/"]
RUN dotnet restore "GraphQLWithNet8/GraphQLWithNet8.csproj"
COPY . .
WORKDIR "/src/GraphQLWithNet8"
RUN dotnet build "GraphQLWithNet8.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GraphQLWithNet8.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLWithNet8.dll"]
