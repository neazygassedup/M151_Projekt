#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["M151_Eisstand/M151_Eisstand.csproj", "M151_Eisstand/"]
RUN dotnet restore "M151_Eisstand/M151_Eisstand.csproj"
COPY . .
WORKDIR "/src/M151_Eisstand"
RUN dotnet build "M151_Eisstand.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "M151_Eisstand.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "M151_Eisstand.dll"]