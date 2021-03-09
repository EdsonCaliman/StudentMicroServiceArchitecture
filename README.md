# Student MicroServices

## StudentAPI

API using SQLServer with Dapper for select and insert students

Message Service producer for RabbitMQ, queue: studentQueue

Get: /students

Post: /students

## StudentWorkerConsole

RabbitMQ consumer for queue: studentQueue

After consume, the message will is persist in MongoDB

# RabbitMQ docker image

docker run -d -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

# MongoDB docker image

docker run -d -it --rm --name mongodb -p 2717:27017 -v C:/mongodatabase:/data/lib mongo:latest 