# Aspire AppHost — the bot's composition root for orchestration

Runs the Discord bot (`DotNet/Bot.Discord`) as the `bot-discord` project
resource, wiring every credential from **parameters** (resolved from this
AppHost's user secrets — nothing secret is ever committed):

| Parameter | User secret key | Feeds the bot env |
|---|---|---|
| `discord-token` | `Parameters:discord-token` | `Discord__Token` |
| `it-user` | `Parameters:it-user` | `Discord__ItUser` |
| `cloudflare-account` | `Parameters:cloudflare-account` | `Cloudflare__AccountId` |
| `cloudflare-token` | `Parameters:cloudflare-token` | `Cloudflare__ApiToken` |
| `neon-connection-string` | `Parameters:neon-connection-string` | `Postgres__ConnectionString` |

## Run it

```bash
cd Aspire.AppHost/src
DOTNET_ENVIRONMENT=Development aspire run
```

`DOTNET_ENVIRONMENT=Development` is required: .NET only loads **user
secrets** in Development, so without it every parameter reports `ValueMissing`
and `bot-discord` never gets its credentials. (Set a value once with
`dotnet user-secrets set "Parameters:<name>" "<value>" --project Aspire.AppHost/src`.)

Use `aspire` commands, never `dotnet run`, against the AppHost:
`aspire ps`, `aspire describe`, `aspire logs bot-discord`, `aspire stop`.
