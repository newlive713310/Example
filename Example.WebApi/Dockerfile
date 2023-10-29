FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV https_proxy=''
ENV HTTPS_PROXY=''
ENV no_proxy=''
ENV NO_PROXY=''

WORKDIR /src
COPY . .
RUN dotnet restore "Example.WebApi/Example.WebApi.csproj"

COPY . .
WORKDIR "/src/Example.WebApi"
RUN dotnet build "Example.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://*:11500
EXPOSE 11500

ENTRYPOINT ["dotnet", "Example.WebApi.dll"]