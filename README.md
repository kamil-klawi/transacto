# Transacto

---

### Author

Kamil Klawikowski
[GitHub](https://github.com/kamil-klawi)

### License

This project is available under the **MIT** license.
See [LICENSE](LICENSE) for more information.

### Version

1.0.0 - No Earlier Than December 2025

---

## Table of Contents

- [Description](#description)
- [Monorepo Structure](#monorepo-structure)
- [Technologies](#technologies)
- [Local Setup](#local-setup)
- [Deployment](#deployment)
- [Documentation](#documentation)

---

## Description

Transacto is a banking transaction system that enables management of bank accounts, execution of transfers, review of transaction history, and verification of data accuracy. The system ensures operation security, automatic validation, and full control over the flow of funds.

---

## Monorepo Structure

```
/transacto
├── .github
│   └── workflows
├── apps
│   ├── frontend
│   │   ├── public
│   │   ├── src
│   │   │   ├── app
│   │   │   ├── components
│   │   │   ├── features
│   │   │   ├── hooks
│   │   │   ├── lib
│   │   │   ├── styles
│   │   │   └── types
│   │   └── next.config.js
│   └── backend
│       ├── Transacto.API
│       ├── Transacto.Application
│       ├── Transacto.Domain
│       ├── Transacto.Infrastructure
│       ├── Transacto.Identity
│       ├── Transacto.Tests 
│       ├── Transacto.sln
│       └── global.json
├── database
│   ├── migrations
│   └── seed
├── docs
│   ├── index.mdx
│   ├── architecture.mdx
│   ├── api-reference.mdx
│   ├── changelog.md
│   ├── data-model.mdx
│   └── testings.mdx
├── docker
│   ├── .env
│   ├── .dockerignore
│   ├── compose.yaml
│   ├── Dockerfile.backend
│   ├── Dockerfile.frontend
│   └── README.Docker.md
├── scripts
│   ├── deploy.sh
│   ├── migrate.sh
│   ├── import_exchange_rates.py
│   ├── import_csv.py
│   └── backup_db.py
├── .gitattributes
├── .gitignore
├── LICENSE
└── README.md
```

---

## Technologies

1. **Frontend**
    - Typescript
    - Next.js
    - Auth.js
    - shadcn/ui
    - TailwindCSS
    - Chart.js
2. **Backend**
    - C#
    - ASP.NET Core
    - Entity Framework Core
    - xUnit
    - ASP.NET Identity
    - MediatR
    - AutoMapper
    - FluentValidation
    - Serilog
    - Quart.NET
3. **Database**
    - PostgreSQL
4. **DevOps**
    - Bash
    - Python
    - Docker
    - GitHub Actions

---

## Local Setup

---

## Deployment

---

## Documentation
