![](https://s3.us-west-2.amazonaws.com/secure.notion-static.com/a668e5c7-b2b4-4264-b6f5-667f680e14cb/Untitled.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20220124%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20220124T215600Z&X-Amz-Expires=86400&X-Amz-Signature=84c3472c67956dec9afc91ed4c3cd686b8db5013df3960cabaef80855310a994&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%22Untitled.png%22&x-id=GetObject)
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
