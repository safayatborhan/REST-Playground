#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1.28 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
#WORKDIR /build/
COPY ["TweetBook.csproj", "/build/"]
RUN dotnet restore "./build/TweetBook.csproj"
COPY . ./build/
WORKDIR "/build/"
RUN dotnet build "./TweetBook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./TweetBook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TweetBook.dll"]