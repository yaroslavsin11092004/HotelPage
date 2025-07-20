FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /Hotel
COPY ./Hotel.csproj ./
RUN dotnet restore "./Hotel.csproj"
COPY . .
RUN dotnet build -c Release
ENTRYPOINT dotnet /Hotel/build/net9.0/Hotel.dll
