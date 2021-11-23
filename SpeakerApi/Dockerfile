FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY SpeakerApi/dist /app
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/tcp
ENTRYPOINT ["dotnet", "SpeakerApi.dll"]