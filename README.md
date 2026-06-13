# WebAPICRUD

Un projet Web API ASP.NET Core moderne pour démontrer les opérations CRUD (Create, Read, Update, Delete) avec une architecture RESTful.

## 📋 Table des matières

- [À propos](#à-propos)
- [Technologies](#technologies)
- [Prérequis](#prérequis)
- [Installation](#installation)
- [Utilisation](#utilisation)
- [Endpoints disponibles](#endpoints-disponibles)
- [Configuration Docker](#configuration-docker)
- [Contribuer](#contribuer)
- [Licence](#licence)

## À propos

WebAPICRUD est une application Web API ASP.NET Core conçue pour servir de point de départ pour les développeurs souhaitant apprendre ou mettre en œuvre des opérations CRUD dans une architecture RESTful. Le projet inclut des configurations modernes pour le développement et le déploiement en conteneur.

## Technologies

- **Framework** : ASP.NET Core 10.0
- **.NET Target** : .NET 10.0
- **Architecture** : Web API RESTful
- **Outils de conteneurisation** : Docker
- **Documentation API** : ScalarAPI (Scalar)

## Prérequis

### Configuration locale
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) ou version ultérieure
- [Visual Studio 2026](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### Configuration Docker
- [Docker Desktop](https://www.docker.com/products/docker-desktop) ou Docker Engine
- [Docker Compose](https://docs.docker.com/compose/) (optionnel)

## Installation

### Cloner le dépôt

```bash
git clone https://github.com/abelawesso/WebApiCore.git
cd WebAPICRUD
```

### Restaurer les dépendances

```bash
dotnet restore
```

### Construire le projet

```bash
dotnet build
```

## Utilisation

### Exécution locale

#### Avec Visual Studio
1. Ouvrir `WebAPICRUD.slnx` dans Visual Studio
2. Cliquer sur le bouton **Démarrer** ou appuyer sur **F5**
3. L'application se lancera sur `https://localhost:7000` ou `http://localhost:5000`

#### Avec la ligne de commande
```bash
dotnet run
```

### Accéder à la documentation API

L'application inclut OpenAPI (Swagger) pour la documentation interactive :

- **Développement** : `https://localhost:7000/openapi/v1.json`
- **Documentation UI** : Disponible via la configuration OpenAPI

## Endpoints disponibles

### WeatherForecast



## Configuration Docker

### Construire l'image Docker

```bash
docker build -t webapicrud:latest .
```

### Exécuter le conteneur

```bash
docker run -p 8080:8080 -p 8081:8081 webapicrud:latest
```

L'application sera accessible sur :
- HTTP : `http://localhost:8080`
- HTTPS : `https://localhost:8081`

### Architecture multi-stage du Dockerfile

Le Dockerfile utilise une approche multi-stage pour optimiser la taille finale de l'image :

1. **base** : Image de runtime ASP.NET Core
2. **build** : SDK .NET pour la compilation
3. **publish** : Phase de publication
4. **final** : Image de production minimale

## Structure du projet

```
WebAPICRUD/
├── Program.cs              # Point d'entrée de l'application
├── appsettings.json        # Configuration par défaut
├── appsettings.Development.json # Configuration de développement
├── WebAPICRUD.csproj       # Fichier de projet
├── Dockerfile              # Configuration Docker
├── .dockerignore            # Fichiers à exclure de l'image Docker
├── .gitignore              # Fichiers à exclure du contrôle de version
├── Properties/
│   └── launchSettings.json # Configuration de lancement
└── README.md               # Ce fichier
```

## Configuration

### appsettings.json

Fichier de configuration principal pour les paramètres de l'application :

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information"
	}
  },
  "AllowedHosts": "*"
}
```

### appsettings.Development.json

Configuration spécifique au développement, notamment avec OpenAPI activé.

## Développement

### Mode de débogage

L'application s'exécute automatiquement en mode de débogage lors du lancement depuis Visual Studio avec `F5`.

### Authentification et autorisation

Le projet est configuré avec les services d'authentification et d'autorisation ASP.NET Core. Vous pouvez les étendre selon vos besoins.

## Déploiement

### Préparation pour la production

1. Vérifiez que `appsettings.json` contient les configurations appropriées
2. Assurez-vous que les variables d'environnement sensibles sont définies
3. Testez l'application en mode Release

```bash
dotnet build -c Release
dotnet run --configuration Release
```

### Déploiement Docker

L'application est prête à être déployée en tant que conteneur Docker. Consultez votre plateforme d'hébergement (Azure Container Instances, Kubernetes, Docker Swarm, etc.) pour les instructions spécifiques.

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

## Licence

Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus de détails.

## Support

Pour toute question ou problème, veuillez ouvrir une [issue](https://github.com/abelawesso/WebApiCore/issues) sur le dépôt GitHub.

## Liens utiles

- [Documentation officielle ASP.NET Core](https://learn.microsoft.com/fr-fr/dotnet/core/)
- [Guide OpenAPI/Swagger](https://swagger.io/)
- [Documentation Docker](https://docs.docker.com/)
- [Guide des conventions C#](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/coding-conventions)

---

**Maintenu par** : [abelawesso](https://github.com/abelawesso)
