# Installation

## Docker

Un docker compose est disponible et permet d'avoir en quelques clics une application fonctionnelle.

Il crée un conteneur pour la base de données (postgresql) et pour la solution.

### Prérequis :
- docker
- docker-compose

Simplement faire `docker-compose up` dans le dossier de la solution

Un fois lancé, le server est accessible depuis l'ip `http://localhost:5286`

Un swagger est disponible à l'adresse `http://localhost:5286/swagger/`

## Natif

Pour facilement lancer les tests et voir les resultats, une installation native de dotnet est recommandée.

### Prérequis :
- .NET SDK 8.0 ou plus 
- ASP.NET Runtime 8.0 ou plus

Dans le dossier de la solution (la où le fichier ProjetFlashcard.sln réside) exécuter :

### Commandes utiles (depuis le dossier où le fichier ProjetFlashcard.sln réside) :
- `dotnet restore` pour installer les dépendances
- `dotnet run --project .\WebApi\WebApi.csproj` pour lancer le serveur web (Une base de données Postgres est requise)
- `dotnet test` pour exécuter les tests

Un fois lancé, le server est accessible depuis l'ip `http://localhost:5285`

Un swagger est disponible à l'adresse `http://localhost:5285/swagger/`

### Pour visualiser la couverture de tests sans IDE (depuis le dossier où le fichier ProjetFlashcard.sln réside) :
- `dotnet test --collect:"XPlat Code Coverage"` pour générer le fichier de la couverture de tests
- `dotnet tool install --global dotnet-reportgenerator-globaltool` pour installer l'outil de génération de report
- `reportgenerator -reports:.\ProjetFlashcardTest\TestResults\[Le guid du dossier généré]\coverage.cobertura.xml -targetdir:.\report` pour générer le report
- `.\report\index.html` pour ouvrir le report

# Misc

Des données sont automatiquement insérées dans la bdd si aucune donnée n'existe dans la table `Flashcard`.

Le dataset peut-être trouvé dans `Infrastructure\ExternalServices\DataInitializer.cs`

Le dataset utilisé pour les tests peut-être trouvé dans `ProjetFlashcardTest\Dataset.cs`

Il est possible de changer l'adresse de la base de données Postgres :
- Pour le conteneur docker : modifier la ligne `WebApiDatabase` dans le fichier `appsettings.docker.json`
- Pour l'installation native : modifier la ligne `WebApiDatabase` dans le fichier `WebApi\appsettings.json`

Par défaut, la version docker et native utilisent toutes les deux la base de données du docker compose. 

Il est possible d'avoir les deux version lancées en parallèle car les ports exploités sont différents.

# Informations supplémentaires

Projet majoritairement réalisé en pair programming, donc les commits ne sont pas représentatifs du travail fourni.