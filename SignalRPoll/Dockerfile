FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SignalRPoll/SignalRPoll.csproj", "SignalRPoll/"]
RUN dotnet restore "SignalRPoll/SignalRPoll.csproj"
COPY . .
WORKDIR "/src/SignalRPoll"
RUN dotnet build "SignalRPoll.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SignalRPoll.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SignalRPoll.dll"]