
# Portalul bunurilor confiscate

Dezvoltăm pentru Agenția Națională pentru Administrarea Bunurilor Indisponibilizate (ANABI) o platformă despre ce, cât și de unde se confiscă în România, din infracțiuni. Punem totul pe hartă, pentru ca tu să știi ce se petrece. ANABI va folosi platforma pentru a gestiona aceste bunuri la nivel național, inclusiv re-directionarea acestor resurse. Astfel, platforma va transparentiza procesul de utilizare a bunurilor confiscate.

### anabi-gestiune-api
Acesta este API-ul portalului de gestiune pentru ANABI

# Stack
.Net Core 1.1 ^

SQL Server Express

Visual Studio Community Edition (Free/Multiplatform)

Swagger


### Build & Run

1. instaleaza .NetCore (Open Source/Free/Multiplatform) de [aici](https://www.microsoft.com/net/core#windows)

2. ruleaza din consola, in folderul app:
    ```sh
    private-api\app> dotnet restore
    ```
  
3. ruleaza din folderul VotingIrregularities.Api:
    ```sh
    anabi-gestiune-api> dotnet run
    ```
  
4. browse to indicated address: <http://localhost:5000/swagger>

# Contributing

Branch -> Commit -> Pull request cu Code Review
