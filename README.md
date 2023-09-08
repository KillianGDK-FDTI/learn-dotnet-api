dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING_HERE"


Créer une migration
dotnet ef migrations add <MigrationName>

Appliquer la migration à la base de donnée
dotnet ef database update


---

Générer le modèle de donnée à partir d'une base de donnée existante
dotnet ef dbcontext scaffold "Server=nom_serveur;Database=nom_base;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


