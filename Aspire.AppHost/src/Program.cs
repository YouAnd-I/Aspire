var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);
var itUser = builder.AddParameter("it-user");
var cloudflareAccount = builder.AddParameter("cloudflare-account");
var cloudflareToken = builder.AddParameter("cloudflare-token", secret: true);
var neonConnection = builder.AddParameter("neon-connection-string", secret: true);

builder.AddProject("bot-discord", "../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken)
    .WithEnvironment("Discord__ItUser", itUser)
    .WithEnvironment("Cloudflare__AccountId", cloudflareAccount)
    .WithEnvironment("Cloudflare__ApiToken", cloudflareToken)
    .WithEnvironment("Postgres__ConnectionString", neonConnection)
    .WithEnvironment("Google__ClientId", builder.Configuration["Parameters:google-client-id"] ?? "")
    .WithEnvironment("Google__ClientSecret", builder.Configuration["Parameters:google-client-secret"] ?? "")
    .WithEnvironment("Google__RefreshToken", builder.Configuration["Parameters:google-refresh-token"] ?? "")
    .WithEnvironment("Google__SpreadsheetId", builder.Configuration["Parameters:google-spreadsheet-id"] ?? "");

builder.Build().Run();
