# DeveloperStore
<h3> This project aims to create a sales management </h3>
<p>
  <img alt="C#" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
</p>
<br/>

# Requirements
<h4>Docker: https://www.docker.com/products/docker-desktop</h4>
<h4>Node: https://nodejs.org/en/download</h4>

# You can check the full documentation navigating to 
### doc: [https://github.com/brunoo-p/DeveloperStore/tree/main/doc]
<br/>

# Starting 🚀
<h4>Clone repository</h4>
```shel
git clone https://github.com/bunoo-p/RrevCompany.git
```

## Building 🔧⚙
```shel
cd Storage [root folder] 
docker-compose up --build
```

## Stopping 🔧⚙
```shel
docker-compose down
```

- The command ``` docker-compose up -d ``` will build 4 containers:

  - Postgres: Postgres Database at
      - ``ports: 5432``
      
  - Pgadmin : Postgres interface at ```localhost:5433```
      - ``ports: 5433:80``
      ###### steps to access Postgres UI: 
      - signin -  ``email: admin@admin.com | password: av@luAt10n``
      - create server
      - add new Server
      - General > ``Name: db``
      - Connection >
          ``Host name/address: developer_evaluation``
          ``| Username: developer ``
          ``| Password: ev@luAt10n``

      
  - API: WebApi em AspNetCore version=8.0  HTTP ``localhost:8081`` 
      - ``ports: 8081:8081``
      - Swagger in  [ localhost: 8081/swagger/index.html ]

