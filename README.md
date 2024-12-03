# Thermo

## Summary

This microservice listens for temperature measurements and writes them to
InfluxDB.

# Overview

## Thermal Processor

Listens for temperature measurements, writes them to InfluxDB. 

See [ThermalProcessor](Application/Processors/ThermalProcessor) for message info.

## Required Infrastructure
|Product|Details|Database Install Link|
|-|-|-|
|InfluxDB| You will need a bucket called node_data, change the ThermalContext value in [appsettings.json](Application/appsettings.json).| Docker installation guide for influxdb [here](https://hub.docker.com/_/influxdb).|
|RabbitMQ| The code will create the exchanges, queues, and bindings for you, just update the Rabbit:ClientDeclarations:Connections:0 details in [appsettings.json](Application/appsettings.json). Note that this will not give you access to the incoming data stream, please reach out to me if interested.  To trigger the Plane Compiler, send a message to the Clock exchange following the binding as described by the appsettings.json file.| Docker installation guide for RabbitMQ [here](https://hub.docker.com/_/rabbitmq).|

