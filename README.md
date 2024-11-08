# Demo Application With EF Migration Bundle in Docker Compose

## Requirements

- [.NET 8](https://dot.net)
- [Docker Engine](https://docs.docker.com/engine) or Docker Desktop

## Usage

From the `MigrationBundleDemo` directory where `MigrationBundleDemo.csproj` exixts:

- Create your migrations

  ```sh
  dotnet ef migrations add <YourMigrationTitle> -o ./Database/Migrations
  ```

- Create EF Migrations Bundle

  ```sh
  dotnet ef migrations bundle --force
  ```

- Create `.env` file with the following fields

  ```plaintext
  POSTGRES_USER=<username>
  POSTGRES_PASSWORD=<password>
  CONNECTION_STRING=<connection string>
  ConnectionStrings__PostgresDb=$CONNECTION_STRING # LEAVE AS IS OR CHANGE IF NECESSARY
  ```

- Adjust Dockerfile.migration if necessary

- Adjust docker-compose.yml if necessary

- Start docker compose

  ```sh
  docker compose up --build
  ```

- Observe the logs for `migrations` service, you will see that migrations were applied

- Visit [http://localhost:8080/people](http://localhost:8080/people) to see the default seeded person from migrations
