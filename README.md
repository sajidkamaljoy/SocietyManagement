# SocietyManagement
[![CI](https://github.com/sajidkamaljoy/SocietyManagement/actions/workflows/ci.yml/badge.svg)](https://github.com/sajidkamaljoy/SocietyManagement/actions/workflows/ci.yml)

> **Note:** this project was originally developed under my earlier GitHub account, [sajid43677/SocietyManagement](https://github.com/sajid43677/SocietyManagement), and was moved to this account in October 2026.

A REST API for managing a residential society (apartment building): flats, tenants, repairs, services, security staff, gate passes, announcements and rules. It is the ASP.NET final project, built as a layered ASP.NET Web API 2 solution on .NET Framework 4.7.2.

## Solution layout

| Project | Responsibility |
|---|---|
| `SocietyManagement` | Web API layer with controllers and routes |
| `bll` | Business logic: services and DTOs |
| `dal` | Data access: Entity Framework 6 code-first models (`SMContext`), repositories and data-access factories |

## What it covers

- **Manager side:** flats (including by category), tenants and the services they use, repair requests and society services.
- **Security side:** security staff, gate passes (including the flat they are for) and visitor verification.
- **Community:** announcements with comments, rules, and reports.

## API overview

Every resource follows the same pattern:

```
GET    api/{resource}/{id}
POST   api/{resource}/add
PUT    api/{resource}/update
DELETE api/{resource}/delete/{id}
```

| Resource | Extra routes |
|---|---|
| `flat` | `api/allflat`, `api/flat/category/{category}` |
| `tenant` | `api/alltenant`, `api/tenant/service/{id}` |
| `repair`, `service` | `api/allrepair`, `api/allservice` |
| `security` | `api/allsecurity`, `api/security/{id}/gatepass` |
| `gatepass` | `api/allgatepassdetails`, `api/gatepass/{id}/flat` |
| `verification` | `api/verification/add`, `api/allverificationsdetails` |
| `announcement` | `api/announcements`, `api/announcement/{id}/comments` |
| `comment`, `report`, `rule` | `api/comments`, `api/reports`, `api/rules` |

## Tech stack

ASP.NET Web API 2, C#, Entity Framework 6 (code-first), SQL Server, layered architecture with repository and DTO patterns.

## Run it

1. Open `SocietyManagement.sln` in Visual Studio and restore NuGet packages.
2. In `SocietyManagement/Web.config`, set the `connectionStrings` entry to your own SQL Server instance. The EF context is `dal/models/SMContext.cs`.
3. Set `SocietyManagement` as the startup project and press F5.
4. Call the endpoints with Postman or a similar tool.

An earlier iteration of this project (tenants, repairs and security shifts only) is in the repo `asp.net-final-project`.
