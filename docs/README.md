# dhanman-purchase


## Docker command
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
docker-compose -f docker-compose.yml -f docker-compose.override.yml down

## Docker push
(Temp)
docker tag e16 amitpnk/purchase
docker push amitpnk/purchase:latest




docker rmi --force amitpnk/purchase:latest
docker build -t amitpnk/purchase:latest . --no-cache
docker push amitpnk/purchase:latest


## Database migration

PM> add-migration Initial-commit-Application -Context ApplicationDbContext -o Migrations/Application

PM> update-database -Context ApplicationDbContext 

# dhanman-purchase Swagger link
[dhanman.money.Api](https://api-dhanman-purchase-nonprod.azurewebsites.net/swagger/index.html)
