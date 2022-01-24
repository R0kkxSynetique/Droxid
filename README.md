# Droxid

C'est une application de communication textuel. Elle contient un système de groupe destiné à créer un espace d'échange

## Status

Ce projet est en plein développement et les releases comprendront surement des bugs. C'est pour cela que les [pull requests](https://github.com/R0kkxSynetique/Droxid/pulls) existent pour nous aider à corriger ces erreures.

## Installer Droxid

- Téléchargez le dossier `.zip` de la [dernière release](https://github.com/R0kkxSynetique/Droxid/releases)
- Puis téléchargez le fichier `.sql` de création de base de données.
  - Il y'a aussi un fichier `.sql` avec des données de test
- Créez la base de donnée avec le fichier `.sql` précédemment téléchargé
  - C'est une base de données en MySql 
- Puis exécuter le fichier `Droxid.exe`

## Développer Droxid

### Dépendences

Soyez attentif à respecter ces prérequis:

- .Net 5+
- MySQL 8.0.25+
- MySql.Data 8.0.27+
- Dapper 2.0.123+
- Newtonsoft.Json(Json.NET) 13.0.1+
- Microsoft.Toolkit.Mvvm 7.1.2+
- Windows 10+

### Télécharger le code source

Clone le repository:

```shell
git clone https://github.com/R0kkxSynetique/Droxid
```

Ouvrez ensuite la solution dans un IDE supportant le c#.
