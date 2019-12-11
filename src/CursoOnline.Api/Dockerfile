# FROM microsoft/aspnetcore-build:2.2 AS build-env
# WORKDIR /app

# # Copiar csproj e restaurar dependencias
# COPY *.csproj ./
# RUN dotnet restore

# # Build da aplicacao
# COPY . ./
# RUN dotnet publish -c Release -o out

# # Build da imagem
# FROM microsoft/aspnetcore:2.2
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "CursoOnline.Api.dll"]

FROM microsoft/aspnetcore-build:2.2 AS build-env
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

