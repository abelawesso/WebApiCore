# WebAPICRUD

Une application Web API ASP.NET Core moderne pour démontrer les opérations CRUD (Create, Read, Update, Delete) sur la gestion des pays avec une architecture en couches suivant le Domain-Driven Design.

## 📋 Table des matières

- [À propos](#à-propos)
- [Architecture du projet](#architecture-du-projet)
- [Technologies](#technologies)
- [Prérequis](#prérequis)
- [Installation](#installation)
- [Configuration de la base de données](#configuration-de-la-base-de-données)
- [Utilisation](#utilisation)
- [Endpoints disponibles](#endpoints-disponibles)
- [Structure du projet](#structure-du-projet)
- [Configuration Docker](#configuration-docker)
- [Développement](#développement)
- [Déploiement](#déploiement)
- [Contribuer](#contribuer)
- [Support](#support)
- [Remerciements](#remerciements)
- [Licence](#licence)

## À propos

WebAPICRUD est une application Web API ASP.NET Core complète qui démontre :
- Les opérations CRUD complètes (Create, Read, Update, Delete) avec suppression logique
- Une architecture en couches avec séparation des préoccupations (Domain, Application, Infrastructure)
- Domain-Driven Design avec validation métier
- Gestion de la base de données via Entity Framework Core et PostgreSQL
- Configuration multi-environnement avec support Docker/Compose

Le projet gère des **Pays** avec les propriétés : nom, date d'indépendance, devise, population, devise, etc.

## Architecture du projet

Le projet suit une architecture en couches bien définie :

```
┌─────────────────────────────────────────┐
│      API Layer (Program.cs)             │
├─────────────────────────────────────────┤
│  Application Layer (DTOs & Contracts)   │
├─────────────────────────────────────────┤
│  Infrastructure Layer (Services)        │
├─────────────────────────────────────────┤
│  Domain Layer (Models & Business Logic) │
├─────────────────────────────────────────┤
│  Persistence Layer (DbContext)          │
├─────────────────────────────────────────┤
│     PostgreSQL Database                 │
└─────────────────────────────────────────┘
```

### Couches du projet

- **Domain** : Modèles métier (`Country`), entité de base (`EntityBase`), logique métier et validations
- **Application** : DTOs (`CountryDto`, `CreateCountry`, `UpdateCountry`) pour la communication API
- **Infrastructure** : Services métier (`ICountryService`, `CountryService`) et implémentation des opérations
- **Persistence** : `AppDbContext` pour la gestion de la base de données via EF Core

## Technologies

- **Framework** : ASP.NET Core 10.0
- **.NET Target** : .NET 10.0
- **Base de données** : PostgreSQL 17 (Alpine)
- **ORM** : Entity Framework Core 10.0.0
- **Driver PostgreSQL** : Npgsql.EntityFrameworkCore.PostgreSQL 10.0.0
- **Architecture** : Web API RESTful avec Domain-Driven Design
- **Documentation API** : OpenAPI avec Scalar API Reference
- **Conteneurisation** : Docker & Docker Compose
- **IDE** : Visual Studio Professional 2026

## Prérequis

### Configuration locale
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) ou version ultérieure
- [Visual Studio 2026](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [PostgreSQL 13+](https://www.postgresql.org/download/) (optionnel si utilisation de Docker)
- [Git](https://git-scm.com/)

### Configuration Docker
- [Docker Desktop](https://www.docker.com/products/docker-desktop) ou Docker Engine
- [Docker Compose](https://docs.docker.com/compose/)

## Installation

### 1. Cloner le dépôt

```bash
git clone https://github.com/abelawesso/WebApiCore.git
cd WebAPICRUD
```

### 2. Restaurer les dépendances

```bash
dotnet restore
```

### 3. Construire le projet

```bash
dotnet build
```

## Configuration de la base de données

### Option 1 : Utiliser Docker Compose (Recommandé)

Docker Compose fournit PostgreSQL, pgAdmin et l'API préconfigurés :

```bash
docker-compose up -d
```

Cela lance :
- **PostgreSQL** : `localhost:5432` (user: admin, password: secret)
- **pgAdmin** : `http://localhost:5050` (admin@admin.com / secret)
- **API** : `http://localhost:7066` (HTTP) / `https://localhost:5020` (HTTPS)

### Option 2 : Configuration locale avec PostgreSQL

1. **Mettre à jour la chaîne de connexion** dans `appsettings.Development.json` :

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Host=localhost;Port=5432;Database=webapi;Username=votre_user;Password=votre_password"
  }
}
```

2. **Appliquer les migrations** :

```bash
dotnet ef database update
```

### Commandes Entity Framework Core utiles

```bash
# Voir la chaîne de connexion en cours
dotnet ef database connection

# Créer une nouvelle migration
dotnet ef migrations add NomDeLaMigration

# Supprimer la dernière migration (si non appliquée)
dotnet ef migrations remove

# Mettre à jour la base de données
dotnet ef database update

# Afficher le SQL généré
dotnet ef migrations script
```

## Utilisation

### Exécution locale

#### Avec Visual Studio
1. Ouvrir `WebAPICRUD.slnx` dans Visual Studio
2. S'assurer que la chaîne de connexion dans `appsettings.Development.json` est correcte
3. Cliquer sur le bouton **Démarrer** ou appuyer sur **F5**
4. L'application se lancera sur `https://localhost:5001` ou `http://localhost:5000`

#### Avec la ligne de commande
```bash
dotnet run
```

L'application sera disponible sur `https://localhost:5001`

### Accéder à la documentation API

L'application inclut Scalar API Reference (interface interactive) :

```
https://localhost:5001/scalar/v1
```

ou accéder au JSON OpenAPI :

```
https://localhost:5001/openapi/v1.json
```

## Endpoints disponibles

### Accueil

```http
GET / HTTP/1.1
Host: localhost:5001
```

**Réponse** (200 OK) :
```
Hello World!
```

### Pays - Créer

```http
POST /countries HTTP/1.1
Host: localhost:5001
Content-Type: application/json

{
  "name": "France",
  "dateOfIndependence": "1804-01-01",
  "motto": "Liberté, Égalité, Fraternité",
  "population": 67750000,
  "currencyCode": "EUR"
}
```

**Réponse** (201 Created) :
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "France",
  "dateOfIndependence": "1804-01-01",
  "motto": "Liberté, Égalité, Fraternité",
  "population": 67750000,
  "currencyCode": "EUR",
  "createdOn": "2025-01-01T12:00:00Z",
  "lastModifiedOn": "2025-01-01T12:00:00Z",
  "isDeleted": false,
  "deletedOn": null
}
```

### Pays - Obtenir par ID

```http
GET /countries/{id} HTTP/1.1
Host: localhost:5001
```

### Pays - Lister tous

```http
GET /countries HTTP/1.1
Host: localhost:5001
```

**Réponse** (200 OK) :
```json
[
  {
	"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
	"name": "France",
	"dateOfIndependence": "1804-01-01",
	"motto": "Liberté, Égalité, Fraternité",
	"population": 67750000,
	"currencyCode": "EUR",
	"createdOn": "2025-01-01T12:00:00Z",
	"lastModifiedOn": "2025-01-01T12:00:00Z",
	"isDeleted": false,
	"deletedOn": null
  }
]
```

### Pays - Mettre à jour

```http
PUT /countries/{id} HTTP/1.1
Host: localhost:5001
Content-Type: application/json

{
  "name": "France",
  "dateOfIndependence": "1804-01-01",
  "motto": "Liberté, Égalité, Fraternité",
  "population": 68000000,
  "currencyCode": "EUR"
}
```

### Pays - Supprimer (Suppression logique)

```http
DELETE /countries/{id} HTTP/1.1
Host: localhost:5001
```

**Note** : La suppression est logique (soft delete). L'enregistrement est marqué comme supprimé mais conservé en base.

## Structure du projet

```
WebAPICRUD/
│
├── Domain/                           # Couche métier
│   ├── BaseEntity/
│   │   └── EntityBase.cs            # Classe de base pour toutes les entités
│   ├── Country.cs                   # Modèle métier Country
│   ├── Persistence/
│   │   ├── AppDbContext.cs          # Contexte Entity Framework
│   │   └── Migrations/              # Migrations de base de données
│   │       ├── 20260613170729_InitialMigration.cs
│   │       ├── 20260613170729_InitialMigration.Designer.cs
│   │       └── AppDbContextModelSnapshot.cs
│
├── Application/                      # Couche application
│   └── Dtos/
│       ├── CountryDto.cs            # DTO pour les réponses
│       ├── CreateCountry.cs         # DTO pour créer un pays
│       └── UpdateCountry.cs         # DTO pour mettre à jour un pays
│
├── Infrastructure/                   # Couche infrastructure
│   ├── CountryService.cs            # Service métier
│   └── Interfaces/
│       └── ICountryService.cs       # Interface du service
│
├── Program.cs                        # Point d'entrée et configuration
├── appsettings.json                 # Configuration par défaut
├── appsettings.Development.json     # Configuration de développement
├── WebAPICRUD.csproj                # Fichier de projet
├── Dockerfile                        # Configuration Docker
├── docker-compose.yml                # Configuration Docker Compose
├── .dockerignore                     # Fichiers à exclure de l'image Docker
├── .gitignore                        # Fichiers à exclure du contrôle de version
├── Properties/
│   └── launchSettings.json          # Configuration de lancement
└── README.md                         # Ce fichier
```

### Modèle de données

#### EntityBase (Classe de base abstraite)
```csharp
public abstract class EntityBase
{
	public Guid Id { get; private set; }
	public DateTimeOffset CreatedOn { get; private set; }
	public DateTimeOffset LastModifiedOn { get; set; }
	public bool IsDeleted { get; private set; }
	public DateTimeOffset DeletedOn { get; private set; }
}
```

#### Country (Entité métier)
```csharp
public sealed class Country : EntityBase
{
	public string Name { get; set; }
	public DateTime DateOfIndependence { get; set; }
	public string Motto { get; set; }
	public long Population { get; set; }
	public string CurrencyCode { get; set; }
}
```

## Configuration

### appsettings.json

Configuration par défaut pour tous les environnements :

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning"
	}
  },
  "AllowedHosts": "*"
}
```

### appsettings.Development.json

Configuration spécifique au développement avec chaîne de connexion PostgreSQL :

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning"
	}
  },
  "ConnectionStrings": {
	"DefaultConnection": "Host=localhost;Port=5432;Database=webapi;Username=admin;Password=secret"
  }
}
```

## Configuration Docker

### Architecture multi-stage du Dockerfile

Le Dockerfile utilise une approche multi-stage pour optimiser la taille finale de l'image :

1. **base** : Image de runtime ASP.NET Core 10.0
2. **build** : SDK .NET 10.0 pour la compilation
3. **publish** : Phase de publication avec optimisations
4. **final** : Image de production minimale basée sur l'image de runtime

### Docker Compose Services

#### PostgreSQL
- Image: `postgres:17-alpine`
- Conteneur: `postgres`
- Port: `5432`
- Variables d'environnement :
  - `POSTGRES_USER`: admin
  - `POSTGRES_PASSWORD`: secret
  - `POSTGRES_DB`: webapi
- Volume: `postgres_data:/var/lib/postgresql/data`

#### pgAdmin (Gestionnaire PostgreSQL)
- Image: `dpage/pgadmin4`
- Conteneur: `pgadmin`
- Port: `5050`
- Email: `admin@admin.com`
- Mot de passe: `secret`

#### API WebAPICRUD
- Construite à partir du Dockerfile local
- Conteneur: `webapicrud`
- Ports: `7066` (HTTP), `5020` (HTTPS)
- Dépend de PostgreSQL (condition: service_healthy)

### Construire et exécuter avec Docker Compose

```bash
# Lancer tous les services
docker-compose up -d

# Vérifier l'état des services
docker-compose ps

# Voir les logs de l'API
docker-compose logs -f api

# Arrêter tous les services
docker-compose down

# Arrêter et supprimer les volumes
docker-compose down -v
```

### Construire l'image Docker manuellement

```bash
docker build -t webapicrud:latest .
```

### Exécuter le conteneur individuellement

```bash
docker run -p 8080:8080 -p 8081:8081 \
  -e ConnectionStrings__DefaultConnection="Host=votre_host;Port=5432;Database=webapi;Username=admin;Password=secret" \
  webapicrud:latest
```

## Développement

### Mode de débogage

L'application s'exécute automatiquement en mode de débogage lors du lancement depuis Visual Studio avec `F5`.

### Hot Reload

Lors du développement, les modifications du code sont rechargées automatiquement sans redémarrer l'application :

```bash
dotnet watch run
```

### Outils de développement

#### Entity Framework Core CLI

```bash
# Installer l'outil global
dotnet tool install --global dotnet-ef

# Vérifier la version
dotnet ef --version
```

#### Scalar API Reference

Interface interactive pour tester les endpoints :
- URL de développement : `https://localhost:5001/scalar/v1`

### Conventions de codage

- Suivre les [conventions de codage C#](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Utiliser les implicit usings et nullable reference types
- Nommer les interfaces avec le préfixe `I` (`ICountryService`)
- Utiliser les records pour les DTOs
- Ajouter des commentaires XML pour les méthodes publiques

## Déploiement

### Préparation pour la production

1. Vérifiez que `appsettings.json` contient les configurations appropriées
2. Créez un fichier `appsettings.Production.json` :

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Error",
	  "Microsoft.AspNetCore": "Error"
	}
  },
  "AllowedHosts": "*"
}
```

3. Définissez les variables d'environnement sensibles (chaîne de connexion, secrets, etc.)
4. Testez l'application en mode Release :

```bash
dotnet build -c Release
dotnet run --configuration Release
```

### Déploiement Docker

L'application est prête à être déployée en tant que conteneur Docker. Options :

- **Azure Container Instances** : Déployer l'image Docker directement
- **Kubernetes** : Créer des manifests YAML pour orchestration
- **Docker Swarm** : Déployer en cluster
- **AWS ECS** : Utiliser ECR pour l'hébergement d'images
- **DigitalOcean App Platform** : Déploiement simplifié

### Exemple de déploiement Azure

```bash
# Créer un registre Azure Container Registry
az acr create --resource-group MyResourceGroup --name myregistry --sku Basic

# Construire et pousser l'image
az acr build --registry myregistry --image webapicrud:latest .

# Déployer dans Azure Container Instances
az container create --resource-group MyResourceGroup \
  --name webapicrud-container \
  --image myregistry.azurecr.io/webapicrud:latest \
  --cpu 1 --memory 1.5 \
  --registry-login-server myregistry.azurecr.io \
  --registry-username <username> \
  --registry-password <password> \
  --ports 8080 8081 \
  --ip-address public
```

## Contribuer

Les contributions sont les bienvenues ! Pour contribuer à ce projet :

1. **Fork** le dépôt
2. Créez une **branche** pour votre fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. **Committez** vos modifications (`git commit -m 'Add some AmazingFeature'`)
4. **Poussez** vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrez une **Pull Request**

### Directives de contribution

- Suivez les conventions de codage C# existantes
- Ajoutez des tests pour les nouvelles fonctionnalités
- Mettez à jour la documentation en cas de changements
- Assurez-vous que le code compile sans avertissements
- Incluez des commentaires XML pour les méthodes publiques

## Support

Pour toute question ou problème :

- Ouvrez une [issue](https://github.com/abelawesso/WebApiCore/issues) sur GitHub
- Consultez la [documentation ASP.NET Core](https://learn.microsoft.com/fr-fr/dotnet/core/)
- Consultez la [documentation Entity Framework Core](https://learn.microsoft.com/fr-fr/ef/core/)

## Ressources utiles

- [Documentation officielle ASP.NET Core](https://learn.microsoft.com/fr-fr/dotnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Npgsql Documentation](https://www.npgsql.org/)
- [Guide OpenAPI/Scalar](https://scalar.com/)
- [Documentation Docker](https://docs.docker.com/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Guide des conventions C#](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Domain-Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design)

## Changelog

### Version 1.0.0 (2025-01-13)

#### Ajouté
- Architecture en couches avec Domain-Driven Design
- Modèle `Country` avec validation métier complète
- Service `ICountryService` avec CRUD complet
- DTOs (`CountryDto`, `CreateCountry`, `UpdateCountry`)
- Entity Framework Core avec PostgreSQL
- Support de la suppression logique (soft delete)
- Support des migrations de base de données
- Configuration Docker & Docker Compose
- Documentation API avec Scalar API Reference
- Support OpenAPI

## Licence

Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus de détails.

## Remerciements

Ce projet s'inspire des meilleures pratiques et des tutoriels proposés par [CodeWithMukesh.com](https://codewithmukesh.com/). Un grand merci à Mukesh Murugan pour ses excellents contenus sur l'architecture d'applications ASP.NET Core professionnelles.

---

**Maintenu par** : [abelawesso](https://github.com/abelawesso)  
**Repository** : [WebApiCore](https://github.com/abelawesso/WebApiCore)  
**Branch** : feat/webapi
