# CRUD WITH MESSAGE BROKER RABBITMQ (TECHNICAL TEST BE FAUZ PRATAMA)

## Getting Started

### Using Docker
* Install Docker
* Run Docker Compose

```shell
docker compose -f "docker-compose.yml" up -d --build
```

#### Access Apps
* Open Link : http://localhost:5011/swagger

#### Access RabbitMq
* Open Link : http://localhost:15672/
* Login with :
    * Username : guest
    * Password : guest

#### Access Db
db otomatic migration from apps, to open remote db use this credentials : 
* Host : Localhost
* Port : 3306
* Username : root
* Password : Admin_123

### Using Debug

#### Setup Enviroment
Open Apps/appsettings.json for setup configuration : 
* MariaDbConnectionString -> for connection string db
* TotalShowPage -> for total data show in get list
* RabbiHost -> for connection string rabbitmq
* RabbitQueue -> for queue rabbit mq

#### Run Program
* Klik Debug/Run 
* Access to link http://localhost:5011/swagger