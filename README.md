# Aubilous-Touch

# Configuração de ambiente 

1- Instalar Docker(hub)

2- Subir um container de SQL Server
docker run -it -p 1433:1433 --ACCEPT_EULA Y --SA_PASSWORD=SuaSenhaAqui --PATH /usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin 

3- Subir um container do RabbitMQ
docker run -it --hostname my-rabbit --name RabbitMQPOC -p 15672:15672 -p 5672:5672 rabbitmq:3-management

4- Rodar o Script InitialDBScript.sql
