FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SignalRChat/SignalRChat.csproj", "SignalRChat/"]
RUN dotnet restore "SignalRChat/SignalRChat.csproj"
COPY . .
WORKDIR "/src/SignalRChat"
RUN dotnet build "SignalRChat.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SignalRChat.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SignalRChat.dll"]
