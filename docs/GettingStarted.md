add-migration Initial-commit-Application -Context ApplicationDbContext -o Migrations/Application
PM> add-migration Identity-commit -Context IdentityContext -o Migrations/Identity

PM> update-database -Context ApplicationDbContext