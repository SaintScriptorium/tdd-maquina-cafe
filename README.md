# TDD – Máquina de Café

!\[CI Pipeline](https://github.com/SaintScriptorium/tdd-maquina-cafe/actions/workflows/ci-pipeline.yml/badge.svg)

Máquina dispensadora de café construida con **Desarrollo Guiado por Pruebas (TDD)**, siguiendo el ciclo Rojo → Verde → Azul hasta completar 19 pruebas en verde.

**Autor:** Jean Carlos Sánchez Adón (2023-0983)
**Materia:** Introducción a la Ingeniería de Software

## Tecnología

* C# sobre .NET 8
* xUnit para las pruebas
* GitHub Actions para la integración continua (CI/CD)

## Estructura

```
MaquinaCafeTDD/
├── .github/workflows/ci-pipeline.yml   Pipeline de CI/CD
├── MaquinaCafe/                         Código de producción
│   ├── Vaso.cs
│   ├── Cafetera.cs
│   ├── Azucarero.cs
│   └── MaquinaDeCafe.cs
├── MaquinaCafe.Tests/                   Pruebas (xUnit)
└── MaquinaCafeTDD.sln
```

## Cómo ejecutar las pruebas

```bash
dotnet test MaquinaCafeTDD.sln
```

## Integración continua

Con cada `push` y cada `pull request`, GitHub Actions ejecuta el workflow `CI Pipeline`:

1. Clona el repositorio.
2. Instala .NET 8.
3. Restaura las dependencias.
4. Compila la solución en modo Release.
5. Ejecuta las 19 pruebas.
6. Empaqueta la biblioteca y la publica como artefacto descargable desde Actions.

Si alguna prueba falla, el pipeline se marca en rojo.

## Estrategia de ramas

|Rama|Propósito|
|-|-|
|`main`|Versión estable. Solo recibe cambios desde `develop` por pull request.|
|`develop`|Integra el trabajo terminado.|
|`feature/nueva-funcionalidad`|Desarrollo aislado de una funcionalidad (aquí, el pipeline de CI).|

Flujo: `feature/nueva-funcionalidad` → PR → `develop` → PR → `main`.

