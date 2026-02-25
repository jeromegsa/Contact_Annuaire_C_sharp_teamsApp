# 📒 Contact Annuaire — Blazor Web App

> 🇫🇷 Français | 🇬🇧 [English below](#-contact-annuaire--blazor-web-app-1)

---

## 🇫🇷 Description du projet

**Contact Annuaire** est une application web professionnelle développée avec **Blazor Web App (.NET 8)** et intégrée à **Microsoft Teams** via le **Teams Toolkit**. Elle permet de gérer un annuaire de contacts de manière simple et intuitive.

### Fonctionnalités
- ✅ Affichage de la liste des contacts sous forme de cartes
- ✅ Ajout d'un nouveau contact via un formulaire
- ✅ Suppression d'un contact
- ✅ Recherche et filtrage en temps réel
- ✅ Interface responsive et moderne avec **Tailwind CSS**
- ✅ Intégration Microsoft Teams

---

## 🛠️ Prérequis & Installation

### Prérequis
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) avec le workload **ASP.NET et développement web**
- [Node.js](https://nodejs.org/) (v16 ou supérieur)
- [Teams Toolkit](https://marketplace.visualstudio.com/items?itemName=TeamsDevApp.ms-teams-vscode-extension) pour Visual Studio
- Un compte **Microsoft 365** avec accès à Teams

### Installation

**1. Cloner le dépôt**
```bash
git clone https://github.com/jeromegsa/Contact_Annuaire_C_sharp_teamsApp.git
cd contact_annuaire
```

**2. Installer les dépendances npm**
```bash
npm install
```

**3. Compiler le CSS Tailwind**
```bash
npm run css:build
```

**4. Restaurer les packages .NET**
```bash
cd contact_annuaire
dotnet restore
```

**5. Lancer l'application**
- Dans Visual Studio 2022, appuie sur **F5** via le profil **Teams Toolkit**
- Ou lance manuellement :
```bash
dotnet run
```

---

## 📁 Architecture du projet

```
contact_annuaire/                  ← Racine de la solution
  ├── package.json                 ← Scripts npm (Tailwind)
  ├── tailwind.config.js           ← Configuration Tailwind CSS
  ├── node_modules/                ← Dépendances npm
  └── contact_annuaire/            ← Projet Blazor
        ├── Components/
        │     ├── Pages/
        │     │     ├── Annuaire.razor          ← Page principale
        │     │     ├── Annuaire.razor.css       ← CSS isolé
        │     │     └── Tab.razor               ← Point d'entrée Teams
        │     ├── Shared/
        │     │     ├── CarteContact.razor       ← Carte d'un contact
        │     │     ├── CarteContact.razor.css   ← CSS isolé
        │     │     ├── FormulaireContact.razor  ← Formulaire d'ajout
        │     │     ├── FormulaireContact.razor.css
        │     │     └── FilterContact.razor      ← Barre de recherche
        │     ├── App.razor                      ← Composant racine
        │     ├── Routes.razor                   ← Gestion des routes
        │     └── _Imports.razor                 ← @using globaux
        ├── Models/
        │     └── Contact.cs                     ← Modèle de données
        ├── Services/
        │     └── ContactService.cs              ← Logique métier
        ├── wwwroot/
        │     └── css/
        │           ├── tailwind.css             ← Source Tailwind
        │           ├── app.css                  ← CSS généré par Tailwind
        │           └── site.css                 ← CSS global
        └── Program.cs                           ← Point d'entrée .NET
```

### Technologies utilisées
| Technologie | Version | Rôle |
|---|---|---|
| Blazor Web App | .NET 8 | Framework principal |
| Tailwind CSS | v3 | Styles de l'interface |
| Teams Toolkit | Latest | Intégration Microsoft Teams |
| Microsoft Graph | Latest | Données utilisateur Teams |
| FluentUI | Latest | Composants UI Teams |

---

## 📖 Comment utiliser l'app

### Lancer le build Tailwind

En développement, lance le watcher pour que le CSS se mette à jour automatiquement :
```bash
npm run css:watch
```

Pour un build unique :
```bash
npm run css:build
```

### Utiliser l'annuaire

**Ajouter un contact**
1. Remplis les champs Prénom, Nom, Email et Téléphone
2. Clique sur le bouton **Ajouter**
3. Le contact apparaît dans la grille

**Rechercher un contact**
1. Tape dans la barre de recherche
2. La liste se filtre en temps réel sur le prénom ou le nom

**Supprimer un contact**
1. Clique sur le bouton **Supprimer** dans la carte du contact
2. Le contact est retiré de la liste

---

## 🤝 Comment contribuer

### Workflow Git

**1. Crée une branche pour ta fonctionnalité**
```bash
git checkout -b feature/nom-de-la-fonctionnalite
```

**2. Fais tes modifications et commite**
```bash
git add .
git commit -m "feat: description de la fonctionnalité"
```

**3. Pousse ta branche**
```bash
git push origin feature/nom-de-la-fonctionnalite
```

**4. Ouvre une Pull Request** sur GitHub

### Conventions de commits
| Préfixe | Usage |
|---|---|
| `feat:` | Nouvelle fonctionnalité |
| `fix:` | Correction de bug |
| `style:` | Modification CSS/UI |
| `refactor:` | Refactorisation du code |
| `docs:` | Mise à jour documentation |

---
---

# 📒 Contact Annuaire — Blazor Web App

> 🇬🇧 English | 🇫🇷 [Français ci-dessus](#-contact-annuaire--blazor-web-app)

---

## 🇬🇧 Project Description

**Contact Annuaire** is a professional web application built with **Blazor Web App (.NET 8)** and integrated with **Microsoft Teams** via the **Teams Toolkit**. It allows users to manage a contact directory in a simple and intuitive way.

### Features
- ✅ Display contacts as cards
- ✅ Add a new contact via a form
- ✅ Delete a contact
- ✅ Real-time search and filtering
- ✅ Responsive and modern UI with **Tailwind CSS**
- ✅ Microsoft Teams integration

---

## 🛠️ Prerequisites & Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with **ASP.NET and web development** workload
- [Node.js](https://nodejs.org/) (v16 or higher)
- [Teams Toolkit](https://marketplace.visualstudio.com/items?itemName=TeamsDevApp.ms-teams-vscode-extension) for Visual Studio
- A **Microsoft 365** account with Teams access

### Installation

**1. Clone the repository**
```bash
git clone https://github.com/your-username/contact_annuaire.git
cd contact_annuaire
```

**2. Install npm dependencies**
```bash
npm install
```

**3. Build Tailwind CSS**
```bash
npm run css:build
```

**4. Restore .NET packages**
```bash
cd contact_annuaire
dotnet restore
```

**5. Run the application**
- In Visual Studio 2022, press **F5** using the **Teams Toolkit** profile
- Or run manually:
```bash
dotnet run
```

---

## 📁 Project Architecture

```
contact_annuaire/                  ← Solution root
  ├── package.json                 ← npm scripts (Tailwind)
  ├── tailwind.config.js           ← Tailwind CSS configuration
  ├── node_modules/                ← npm dependencies
  └── contact_annuaire/            ← Blazor project
        ├── Components/
        │     ├── Pages/
        │     │     ├── Annuaire.razor          ← Main page
        │     │     ├── Annuaire.razor.css       ← Scoped CSS
        │     │     └── Tab.razor               ← Teams entry point
        │     ├── Shared/
        │     │     ├── CarteContact.razor       ← Contact card
        │     │     ├── CarteContact.razor.css   ← Scoped CSS
        │     │     ├── FormulaireContact.razor  ← Add form
        │     │     ├── FormulaireContact.razor.css
        │     │     └── FilterContact.razor      ← Search bar
        │     ├── App.razor                      ← Root component
        │     ├── Routes.razor                   ← Route management
        │     └── _Imports.razor                 ← Global @using
        ├── Models/
        │     └── Contact.cs                     ← Data model
        ├── Services/
        │     └── ContactService.cs              ← Business logic
        ├── wwwroot/
        │     └── css/
        │           ├── tailwind.css             ← Tailwind source
        │           ├── app.css                  ← Tailwind output
        │           └── site.css                 ← Global CSS
        └── Program.cs                           ← .NET entry point
```

### Tech Stack
| Technology | Version | Role |
|---|---|---|
| Blazor Web App | .NET 8 | Main framework |
| Tailwind CSS | v3 | UI styling |
| Teams Toolkit | Latest | Microsoft Teams integration |
| Microsoft Graph | Latest | Teams user data |
| FluentUI | Latest | Teams UI components |

---

## 📖 How to Use

### Running the Tailwind Build

In development, run the watcher for automatic CSS updates:
```bash
npm run css:watch
```

For a single build:
```bash
npm run css:build
```

### Using the Directory

**Add a contact**
1. Fill in the First Name, Last Name, Email and Phone fields
2. Click the **Ajouter** button
3. The contact appears in the grid

**Search for a contact**
1. Type in the search bar
2. The list filters in real-time by first or last name

**Delete a contact**
1. Click the **Supprimer** button on the contact card
2. The contact is removed from the list

---

## 🤝 How to Contribute

### Git Workflow

**1. Create a feature branch**
```bash
git checkout -b feature/feature-name
```

**2. Make your changes and commit**
```bash
git add .
git commit -m "feat: description of the feature"
```

**3. Push your branch**
```bash
git push origin feature/feature-name
```

**4. Open a Pull Request** on GitHub

### Commit Conventions
| Prefix | Usage |
|---|---|
| `feat:` | New feature |
| `fix:` | Bug fix |
| `style:` | CSS/UI changes |
| `refactor:` | Code refactoring |
| `docs:` | Documentation update |
