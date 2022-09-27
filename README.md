# ProjectCleanArch.Api

[![GitHub version](https://badge.fury.io/gh/wodsonluiz%2FProjectCleanArch.svg)](https://badge.fury.io/gh/wodsonluiz%2FProjectCleanArch)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Build status](https://ci.appveyor.com/api/projects/status/0e0qfnp2kobgakl6/branch/master?svg=true)](https://ci.appveyor.com/project/wodsonluiz/projectcleanarch)
[![codecov](https://codecov.io/gh/wodsonluiz/ProjectCleanArch/branch/master/graph/badge.svg?token=4AIRAN4GKE)](https://codecov.io/gh/wodsonluiz/ProjectCleanArch)


## Abordagens e Partners de software aplicados

| # | #Status 
| :---: | :---: | 
| Solid | :white_check_mark: |
| Onion Architecture | :white_check_mark: |
| DDD | :white_check_mark: |
| Inversion of Control | :white_check_mark: |
| Cqrs | :white_check_mark: |
| Unit of work  | :construction: |
| Identity Authentication  | :white_check_mark: |
| Bearer Authentication com JWT | :white_check_mark: |
| Logs  | :white_check_mark: |
| .  | :construction: |
| .  | :construction: |
| .  | :construction: |


# Integração Cliente X ProjectCleanArch.Api usando Autentificação

- Basicamente, queremos simular um cliente realizando uma integração com o projeto de Produto e Catalogo passando um token valido. Para isso, criamos um Auth.Api como fabrica de token. 
- Para o Auth.Api, persistimos os dados de usuário no Mongo.
- Nesse primeiro momento, estamos usando o IMemoryCache sendo a solução de cache da Microsoft. 

| # | #Status 
| :---: | :---: | 
| Integration with Auth.Api | :white_check_mark: |
| Resilience  | :construction: |
| Resilience With Circuit Breaker | :construction: |
| Logs  | :construction: |
| .  | :construction: |
| .  | :construction: |
| .  | :construction: |


![Integration with token](https://user-images.githubusercontent.com/13908258/156899781-f85ef340-8393-4e49-8d80-87d324827ad4.png)


##### Se você curtiu, deixa um star no repositório :star:

teste
