# LaboratorieAPI

Small coding assignment: a lab sample tracker. Samples have a name, a temperature (°C), and a timestamp; the frontend lists existing samples and lets you add new ones.

## Tech stack

- Backend: .NET 10 Web API (`LaboratorieAPI/`), Swagger/OpenAPI via Swashbuckle, in-memory repository (singleton, thread-safe).
- Frontend: Vue 3 + Vite (`LaboratorieFrontEnd/`).

## Running it

### Backend

```
cd LaboratorieAPI
dotnet run
```

Serves on `http://localhost:5287` (see `Properties/launchSettings.json`). Swagger UI is available at `/swagger` in Development.

### Frontend

```
cd LaboratorieFrontEnd
npm install
npm run dev
```

Serves on `http://localhost:5173` and calls the API at `http://localhost:5287/api/Sample`. The backend's CORS policy only allows this origin.

## Arch Linux note

```
Arch's `dotnet-sdk` package is built from source and ships without the prune package data,
which causes a build error. The `.csproj` sets `AllowMissingPrunePackageData=true` to work
around this; it has no effect on other systems. Alternatively, install Microsoft's build
from the AUR with `yay -S dotnet-sdk-bin`.
```
