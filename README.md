# Cepedi.CleanArch

Executar o projeto `src\Cepedi.CleanArch.Api` para abrir o swagger

## Características do projeto

- .NET 7.0

- Projeto base para a trilha avançada de .net da residência TIC18. A Residência TIC18 é um projeto oferecido pela parceria entre a Uesc e o Cepedi, localizado em Ilhéus-BA.

## Aplicar migrations
 dotnet ef migrations add Init --project .\src\Cepedi.CleanArch.Dados\ -s .\src\Cepedi.CleanArch.Api\

# Remove a última migration aplicada
 dotnet ef migrations remove --project .\src\Cepedi.CleanArch.Dados\ -s .\src\Cepedi.CleanArch.Api\

# Gera o script de migração
 dotnet ef migrations script --project .\src\Cepedi.CleanArch.Dados\ -s .\src\Cepedi.CleanArch.Api\

# Coloca o banco para o estado inicial zero
 dotnet ef migrations update 0 --project .\src\Cepedi.CleanArch.Dados\ -s .\src\Cepedi.CleanArch.Api\
