<div align="center">

# BYTEQON Technologies


<a href="https://git.io/typing-svg">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=700&size=24&duration=3200&pause=1000&color=512BD4&center=true&vCenter=true&repeat=true&width=1000&height=80&lines=Building+Modern+Software+Solutions;Clean+Architecture+%7C+Modular+Monolith;ASP.NET+Core+%7C+PostgreSQL+%7C+Angular;AI-Powered+Customer+Experiences;Build+Clearly.+Scale+Intentionally.+Deliver+Confidently." alt="BYTEQON animated typing introduction" />
</a>

### Intelligent Digital Platform for Software Services, Content, Project Requests, and AI-Assisted Customer Experiences

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/aspnet/core/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Angular](https://img.shields.io/badge/Angular-Frontend-DD0031?style=for-the-badge&logo=angular&logoColor=white)](https://angular.dev/)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-16A085?style=for-the-badge)](#architecture)
[![License](https://img.shields.io/badge/License-To_Be_Defined-lightgrey?style=for-the-badge)](#license)

**Modular Monolith • Clean Architecture • Vertical Slices • PostgreSQL • Angular • AI Integration • Automated Testing • Docker • CI/CD**

[Overview](#overview) • [Features](#core-features) • [Architecture](#architecture) • [Tech Stack](#technology-stack) • [Getting Started](#getting-started) • [Roadmap](#development-roadmap)

</div>

---

## Overview

**BYTEQON Technologies** is a production-oriented digital platform for a modern software and technology company.

The platform is designed to present the BYTEQON brand, showcase software services and portfolio projects, publish technical content, receive customer messages and project requests, and provide a secure administration dashboard for managing the entire experience.

BYTEQON goes beyond a traditional company website by introducing responsible AI-powered capabilities. A website assistant helps visitors understand the available services and identify the most suitable solution, while an internal project-request analyzer supports the team by summarizing customer requirements, identifying missing information, suggesting follow-up questions, and estimating the general complexity of a proposed project.

The first release is intentionally designed as a **Clean Architecture-Based Modular Monolith**. This approach provides strong module boundaries and maintainability without introducing the operational complexity of premature microservices.

> The goal is not to build the largest possible system. The goal is to build the clearest, safest, fastest, and most maintainable version of the right system.

---

## Project Vision

BYTEQON aims to create a trusted digital gateway between the company and potential customers.

The platform should:

- Communicate BYTEQON's technical capabilities clearly.
- Convert visitors into qualified project leads.
- Build customer confidence through professional presentation and transparent workflows.
- Organize services, projects, articles, team members, and customer requests.
- Assist visitors without allowing AI to make binding commercial decisions.
- Give the internal team useful AI-supported analysis while preserving human review.
- Provide a strong technical foundation for continuous growth.

---

## Core Features

### Public Website

- Professional home page.
- About BYTEQON.
- Services listing and service details.
- Portfolio and case studies.
- Technology showcase.
- Team members.
- Technical blog and categories.
- Contact form.
- Start-your-project form.
- Privacy policy and terms.
- Custom 404 experience.
- Arabic RTL and English LTR support.
- Responsive and accessible user experience.
- Search-engine-friendly public pages.

### Administration Dashboard

- Secure administrator authentication.
- Dashboard overview and operational statistics.
- Service and service-feature management.
- Portfolio, image, and technology management.
- Blog post and category management.
- Team-member management.
- Project-request review and status tracking.
- Contact-message review and archiving.
- Website settings management.
- User, role, and permission management.
- AI usage and latency visibility.
- Audit logging for sensitive administrative operations.

### AI Website Assistant

- Explains BYTEQON services.
- Helps visitors identify a suitable service.
- Answers using approved company knowledge.
- Collects initial project information conversationally.
- Directs users to the project-request form.
- Does not provide binding prices or delivery dates.
- Does not perform sensitive administrative actions.
- Applies message limits, timeouts, quotas, and rate limiting.

### AI Project Request Analyzer

- Generates a concise project summary.
- Identifies the expected project type.
- Extracts requested core features.
- Detects missing information.
- Suggests follow-up questions.
- Estimates request clarity.
- Estimates general complexity.
- Suggests matching BYTEQON services.
- Tracks model usage, execution time, success, and failure.
- Keeps all important outcomes subject to human review.

---

## V1 Scope

The first release focuses on the capabilities required to launch a fast, secure, maintainable company platform.

### Included

- Public company website.
- Content management system.
- Administration dashboard.
- Services.
- Portfolio and technologies.
- Technical blog.
- Team members.
- Project requests.
- Contact messages.
- Authentication and permission-based authorization.
- AI website assistant.
- AI-assisted project-request analysis.
- Automated testing.
- Docker-based environments.
- Continuous integration and deployment foundations.
- Monitoring and health checks.

### Intentionally Excluded from V1

- Full ERP.
- Full CRM.
- Advanced internal task management.
- Electronic contracts.
- Online payments and invoices.
- Monthly subscription system.
- Multi-tenancy.
- Native mobile application.
- Full customer portal.
- Advanced support-ticket system.
- Microservices.

These capabilities may be considered after V1 based on actual product and business needs.

---

<a id="architecture"></a>
## Architecture

BYTEQON follows a:

```text
Clean Architecture-Based Modular Monolith
```

Features are implemented using **Vertical Slices** while respecting Clean Architecture dependency boundaries.

### Backend Projects

```text
Byteqon.Domain
Byteqon.Application
Byteqon.Infrastructure
Byteqon.Api
```

### Dependency Direction

```text
API ------------------------> Application ------------------------> Domain
 |                                  ^
 +----------> Infrastructure -------+
                    |
                    +---------------------------------------------> Domain
```

### Layer Responsibilities

#### `Byteqon.Domain`

The heart of the system:

- Entities.
- Aggregate roots.
- Value objects.
- Enumerations.
- Domain events.
- Domain exceptions.
- Business rules.
- Domain invariants.

The Domain layer does not depend on ASP.NET Core, EF Core, PostgreSQL, HTTP, external AI providers, or infrastructure SDKs.

#### `Byteqon.Application`

The use-case layer:

- Commands and queries.
- Handlers.
- DTOs.
- Validators.
- Application interfaces.
- Result pattern.
- Authorization requirements.
- Application behaviors.
- Persistence abstractions.

The Application layer depends only on the Domain layer.

#### `Byteqon.Infrastructure`

The technical implementation layer:

- Entity Framework Core.
- PostgreSQL.
- Application database context.
- Entity configurations.
- ASP.NET Core Identity implementation.
- AI provider implementation.
- Email delivery.
- File and object storage.
- Caching implementations.
- Background processing.
- Logging and observability integrations.

#### `Byteqon.Api`

The HTTP delivery layer:

- Controllers.
- Request and response contracts.
- Middleware.
- Filters.
- Authentication and authorization configuration.
- OpenAPI documentation.
- Health checks.
- Rate limiting.
- HTTP result mapping.
- Application composition.

---

## Architectural Rules

- Domain never depends on Application, Infrastructure, or API.
- Application never depends on Infrastructure or API.
- Controllers contain no business logic.
- Controllers never access `DbContext` directly.
- Domain entities are never returned directly from API endpoints.
- Infrastructure details are hidden behind Application interfaces.
- All I/O operations are asynchronous.
- `CancellationToken` flows through every asynchronous request path.
- Architecture tests protect dependency rules automatically.
- Features are completed vertically with tests before moving to the next feature.
- No pattern or package is introduced without a real problem to solve.

---

## Vertical Slice Organization

A feature is implemented end to end before moving to another feature.

```text
Domain/
└── ProjectRequests/
    ├── ProjectRequest.cs
    ├── ProjectRequestStatus.cs
    └── Events/

Application/
└── ProjectRequests/
    ├── Commands/
    │   └── SubmitProjectRequest/
    └── Queries/
        └── GetProjectRequests/

Infrastructure/
└── Persistence/
    └── Configurations/
        └── ProjectRequestConfiguration.cs

Api/
└── Controllers/
    └── ProjectRequestsController.cs
```

Each slice includes its domain rules, use case, validation, persistence mapping, HTTP endpoint, documentation, and automated tests.

---

## Error Handling Strategy

BYTEQON separates expected business outcomes from unexpected technical failures.

```text
Expected business outcome  -> Result Pattern
Unexpected technical error -> Exception
```

### Expected Failures

Examples:

- Resource not found.
- Duplicate slug.
- Invalid expected business operation.
- Validation failure.
- Unauthorized or forbidden business action.

These cases return a typed `Result` and are mapped centrally to HTTP responses.

### Unexpected Failures

Examples:

- Unhandled programming error.
- Unexpected infrastructure failure.
- Broken invariant that should not be reachable.
- Provider timeout or exceptional failure.

These cases flow to the global exception-handling middleware, are logged internally, and return safe `ProblemDetails` responses.

### HTTP Error Mapping

```text
Validation   -> 400 Bad Request
Unauthorized -> 401 Unauthorized
Forbidden    -> 403 Forbidden
Not Found    -> 404 Not Found
Conflict     -> 409 Conflict
Domain Rule  -> 422 Unprocessable Content
Failure      -> 500 Internal Server Error
```

### Standard Error Contract

```json
{
  "type": "https://api.byteqon.com/errors/not-found",
  "title": "Resource not found",
  "status": 404,
  "detail": "The requested resource was not found.",
  "instance": "/api/services/example",
  "errorCode": "Services.NotFound",
  "traceId": "request-trace-id"
}
```

This contract gives frontend applications a stable `errorCode`, gives operators a searchable `traceId`, and prevents internal stack traces or technical data from reaching clients.

---

## Validation Strategy

Validation is applied at three distinct levels.

### API Validation

Handled by `ValidateModelAttribute`:

- JSON parsing.
- Model binding.
- Request-contract shape.
- Type conversion.
- Simple data annotations.

Returns a standardized `400 ValidationProblemDetails` response.

### Application Validation

Handled using FluentValidation:

- Use-case-specific input rules.
- Length and format requirements.
- Conditional validation.
- Cross-property validation.
- Rules required before executing a command or query.

### Domain Validation

Handled by aggregates and entities:

- Protects invariants.
- Prevents invalid state transitions.
- Ensures entities cannot exist in invalid states.

---

## Persistence Strategy

BYTEQON uses Entity Framework Core with PostgreSQL.

### Decisions

- `ApplicationDbContext` is the persistence session and Unit of Work.
- `IApplicationDbContext` is defined inside Application.
- `ApplicationDbContext` implements the abstraction inside Infrastructure.
- No custom `IUnitOfWork` wrapper is added initially.
- No generic repository is added without a demonstrated need.
- `DbSet<TEntity>` and focused feature queries are preferred.
- Transactions are introduced explicitly only when a use case requires them.
- PostgreSQL integration tests use a real PostgreSQL-compatible environment.

---

<a id="technology-stack"></a>
## Technology Stack

### Backend

- .NET 10.
- C#.
- ASP.NET Core Web API.
- Controller-based APIs.
- Entity Framework Core.
- Npgsql provider for PostgreSQL.
- FluentValidation.
- ASP.NET Core Identity.
- JWT access tokens.
- Refresh-token rotation.
- Policy and permission-based authorization.
- Problem Details.
- OpenAPI.
- Health Checks.
- Rate Limiting.
- Output Caching.
- Microsoft.Extensions.AI.

### Frontend

- Angular.
- TypeScript.
- SCSS.
- Angular Signals.
- RxJS.
- Angular Router.
- Reactive Forms.
- HTTP Interceptors.
- Feature-based architecture.
- Arabic RTL and English LTR.
- SSR and hydration when justified.
- Accessibility and SEO.

### Data and Storage

- PostgreSQL.
- Entity Framework Core migrations.
- Object storage for media and uploaded files.
- Redis only when a measured requirement appears.

### Testing

- xUnit.
- ASP.NET Core `WebApplicationFactory`.
- Domain tests.
- Application tests.
- Integration tests.
- Architecture tests.
- PostgreSQL-backed persistence tests.
- Code coverage.
- Security and performance testing before production.

### DevOps

- Git and GitHub.
- GitHub Actions.
- Docker.
- Docker Compose.
- Container registry.
- Linux VPS or Azure deployment target.
- Nginx when required by the hosting model.
- Environment variables and external secret storage.

### Observability

- Structured logging.
- Trace identifiers.
- Health checks.
- Application and dependency metrics.
- OpenTelemetry when required.
- AI usage, cost, success, failure, and latency tracking.

---

## Main Domain Modules

```text
Identity
Services
Portfolio
Technologies
Blog
Team
Project Requests
Contact Messages
AI
Site Settings
```

### Project Request Statuses

```text
New
Contacted
MeetingScheduled
UnderReview
ProposalPreparing
ProposalSent
Approved
Rejected
Archived
```

---

## Initial Database Model

The initial model is expected to include entities represented by tables such as:

```text
Users
Roles
UserRoles
Permissions
RolePermissions
RefreshTokens
Services
ServiceFeatures
Technologies
PortfolioProjects
PortfolioImages
PortfolioTechnologies
BlogCategories
BlogPosts
TeamMembers
ProjectRequests
ContactMessages
AiConversations
AiMessages
AiUsageLogs
SiteSettings
```

Potential future tables include:

```text
ProjectRequestNotes
Testimonials
Files
AiPromptTemplates
AiKnowledgeDocuments
AiKnowledgeChunks
AuditLogs
OutboxMessages
```

Database design principles include UTC timestamps, intentional indexes, unique constraints, explicit delete behavior, safe migrations, optimistic concurrency where needed, and auditing only for entities that require it.

---

## API Overview

### Authentication

```http
POST /api/auth/login
POST /api/auth/refresh
POST /api/auth/logout
POST /api/auth/logout-all
GET  /api/auth/me
```

### Public Services

```http
GET /api/services
GET /api/services/{slug}
```

### Public Portfolio

```http
GET /api/portfolio
GET /api/portfolio/{slug}
```

### Public Blog

```http
GET /api/blog
GET /api/blog/{slug}
```

### Public Project Requests

```http
POST /api/project-requests
```

### Public Contact Messages

```http
POST /api/contact-messages
```

### AI Assistant

```http
POST   /api/ai/conversations
POST   /api/ai/conversations/{id}/messages
GET    /api/ai/conversations/{id}
DELETE /api/ai/conversations/{id}
```

Administrative endpoints are protected by authentication and permission policies and use an `/api/admin` route boundary where appropriate.

---

## Authentication and Authorization

BYTEQON uses authentication to establish identity and authorization to control operations.

### Roles

```text
SuperAdmin
ContentManager
Sales
Viewer
```

### Example Permissions

```text
services.read
services.create
services.update
services.delete
portfolio.read
portfolio.create
portfolio.update
portfolio.delete
blog.read
blog.create
blog.update
blog.publish
blog.delete
projectRequests.read
projectRequests.update
contactMessages.read
contactMessages.update
ai.use
ai.usage.read
users.manage
settings.manage
```

The backend enforces all permissions. Hiding an action in the frontend is a usability feature, not a security boundary.

---

## Security Principles

- HTTPS-only production traffic.
- Restricted CORS policy.
- Server-side validation for every external input.
- Secure authentication and permission enforcement.
- Short-lived access tokens.
- Refresh-token rotation and revocation.
- Account lockout and brute-force protection.
- External secret management.
- No credentials, tokens, or API keys in Git.
- No sensitive fields in logs.
- Safe file names and strict upload validation.
- Request and file-size limits.
- Security headers.
- Rate limiting for public forms, AI, and authentication.
- Safe `ProblemDetails` without internal stack traces.
- Dependency and secret scanning in CI.
- Human review for important AI output.
- AI tool allowlists and prompt-injection defenses.
- Backup and restore testing.

---

## Performance Principles

- Async I/O from HTTP endpoint to storage provider.
- Cancellation tokens throughout the request path.
- No `.Result` or `.Wait()` calls.
- No unnecessary `Task.Run()` for I/O.
- `AsNoTracking()` for read-only queries.
- Projection directly to response DTOs.
- Pagination for collection endpoints.
- Explicit prevention of N+1 queries.
- Database indexes based on actual query patterns.
- Output caching for suitable public content.
- Response compression when justified.
- Performance measurement before complex optimization.
- Redis only when application measurements justify it.

---

## Health and Operational Readiness

BYTEQON exposes separate health probes:

```http
GET /health/live
GET /health/ready
```

### Liveness

Confirms that the API process is running and able to process a health request. It does not depend on external systems.

### Readiness

Confirms that the application is ready to receive traffic. It will include critical dependencies such as PostgreSQL when persistence is connected.

Expected behavior after adding PostgreSQL:

```text
API alive, database unavailable:
/health/live  -> 200 Healthy
/health/ready -> 503 Unhealthy
```

---

## Testing Strategy

### Domain Tests

- Entity creation.
- Default states.
- Allowed and forbidden state transitions.
- Domain invariants.
- Value-object behavior.

### Application Tests

- Commands and queries.
- Handlers.
- Validators.
- Result success and failure.
- Authorization requirements.

### Integration Tests

- Routing.
- Middleware ordering.
- Model validation.
- Serialization.
- Problem Details.
- Result-to-HTTP mapping.
- Exception handling.
- Health checks.
- OpenAPI availability.
- Persistence against PostgreSQL.
- Authentication and authorization.

### Architecture Tests

- Domain has no outward dependency.
- Application does not depend on Infrastructure or API.
- Infrastructure does not depend on API.
- Controllers do not access `DbContext` directly.

### Current Foundation Coverage

The foundation integration suite verifies:

```text
Unknown route       -> 404 ProblemDetails
Invalid request     -> 400 ValidationProblemDetails
Domain exception    -> 422 ProblemDetails
Unexpected error    -> Safe 500 ProblemDetails
Not-found Result    -> 404 ProblemDetails
Liveness endpoint   -> 200 Healthy
Readiness endpoint  -> 200 Healthy
OpenAPI document    -> Available in Development
```

---

## Quality Assurance and Quality Control

### Quality Assurance

BYTEQON prevents defects through:

- Architecture rules.
- Coding conventions.
- Pull-request reviews.
- Definition of Done.
- Automated CI quality gates.
- API contract standards.
- Security checklists.
- Documentation requirements.

### Quality Control

BYTEQON detects defects through:

- Unit tests.
- Integration tests.
- Manual API testing.
- Database testing.
- Security testing.
- Performance testing.
- Frontend and browser testing.
- Production smoke testing.

---

<a id="getting-started"></a>
## Getting Started

### Prerequisites

Before persistence is connected, the backend requires:

- .NET 10 SDK.
- Git.
- A development IDE such as Visual Studio, Visual Studio Code, or Rider.

After PostgreSQL and Docker tasks are completed, development will additionally require:

- Docker Desktop or a compatible Docker Engine.
- PostgreSQL, preferably through Docker Compose.

### Clone the Repository

```bash
git clone https://github.com/3Abedalqader15/Byteqon-Technologies.git
cd Byteqon-Technologies
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Solution

```bash
dotnet build
```

### Run All Tests

```bash
dotnet test
```

### Run Integration Tests Only

Use the path matching the repository structure:

```bash
dotnet test Byteqon.IntegrationTests/Byteqon.IntegrationTests.csproj
```

### Run the API

```bash
dotnet run --project Byteqon.Api/Byteqon.Api.csproj
```

Depending on the final folder layout, projects may later be placed under `src` and `tests`. Use the existing `.csproj` path shown in the repository.

---

## Development Endpoints

When running in the Development environment:

```text
OpenAPI JSON:  /openapi/v1.json
Liveness:      /health/live
Readiness:     /health/ready
```

OpenAPI exposure is restricted to Development unless an explicit production documentation strategy is approved.

---

## Configuration and Secrets

Configuration sources may include:

```text
appsettings.json
appsettings.Development.json
User Secrets
Environment Variables
Production Secret Store
```

Never commit:

```text
Database passwords
JWT signing secrets
Refresh tokens
AI provider API keys
Email credentials
Storage credentials
Production connection strings
```

An `.env.example` file may document required variable names without containing actual secrets.

---

## Dependency Management

NuGet package versions are managed centrally using:

```text
Directory.Packages.props
```

Shared build settings are managed through:

```text
Directory.Build.props
```

The .NET SDK version is pinned using:

```text
global.json
```

Each `.csproj` references only the packages required by that project, while version numbers remain centralized.

---

## Docker Strategy

### Development

Docker Compose will provide:

- PostgreSQL.
- Persistent storage.
- Health checks.
- Internal service networking.
- Configurable environment variables.

### API Image

The API Dockerfile will use:

- Multi-stage build.
- Restore-layer caching.
- Separate build and publish stages.
- Lightweight ASP.NET runtime image.
- Non-root execution when supported.
- No development secrets inside the image.

### Production

The production deployment will include:

- Immutable image tags.
- Container registry.
- Health-based deployment verification.
- Controlled database migrations.
- Restart policies.
- Central log collection.
- Backup and rollback procedures.

---

## CI/CD Strategy

### Continuous Integration

Every relevant push and pull request will run:

```text
Restore
Build
Domain Tests
Application Tests
Architecture Tests
Integration Tests
Code Coverage
Dependency Scan
Secret Scan
Docker Build Verification
```

### Continuous Delivery and Deployment

The deployment workflow will perform:

```text
Run all CI checks
Build and tag the Docker image
Push to the container registry
Deploy to staging
Apply migrations using a controlled strategy
Run readiness and smoke checks
Require approval when appropriate
Deploy to production
Run post-deployment checks
Rollback on failure
```

---

<a id="development-roadmap"></a>
## Development Roadmap

### Phase 1: Backend Foundation

- [x] Clean Architecture solution.
- [x] Project references.
- [x] Central build and package configuration.
- [x] Architecture tests foundation.
- [x] Result pattern.
- [x] Problem Details.
- [x] Global exception handling.
- [x] Custom exception mapping.
- [x] Unified model validation.
- [x] Result-to-HTTP mapping.
- [x] OpenAPI configuration.
- [x] Liveness and readiness health checks.
- [x] Dependency-injection organization.
- [x] Foundation integration-test structure.
- [ ] Ensure the complete foundation suite passes without warnings.
- [ ] Basic GitHub Actions CI.

### Phase 2: Persistence and PostgreSQL

- [x] Define `IApplicationDbContext`.
- [ ] Create `ApplicationDbContext`.
- [ ] Configure EF Core and Npgsql.
- [ ] Add entity configuration discovery.
- [ ] Define auditing strategy.
- [ ] Define domain-event foundation.
- [ ] Add PostgreSQL Docker Compose service.
- [ ] Add design-time context factory.
- [ ] Create and apply the first migration.
- [ ] Add PostgreSQL persistence tests.

### Phase 3: Project Requests

- [ ] Domain model and statuses.
- [ ] Submission command and validation.
- [ ] EF Core configuration.
- [ ] Public submission endpoint.
- [ ] Administrative list and details.
- [ ] Status transitions.
- [ ] Rate limiting.
- [ ] Unit and integration tests.
- [ ] OpenAPI documentation.

### Phase 4: Contact Messages

- [ ] Domain and persistence.
- [ ] Public submission.
- [ ] Anti-spam controls.
- [ ] Administrative review and archive.
- [ ] Tests and documentation.

### Phase 5: Services

- [ ] Service domain model.
- [ ] Service features.
- [ ] Slug and publishing rules.
- [ ] Administrative CRUD.
- [ ] Public queries.
- [ ] Ordering, SEO, caching, and tests.

### Phase 6: Portfolio and Technologies

- [ ] Technology catalog.
- [ ] Portfolio domain model.
- [ ] Many-to-many mapping.
- [ ] Images and file-storage abstraction.
- [ ] Administrative CRUD.
- [ ] Public portfolio.
- [ ] File-security and integration tests.

### Phase 7: Blog

- [ ] Categories.
- [ ] Draft and publishing workflow.
- [ ] SEO metadata.
- [ ] Reading-time calculation.
- [ ] Administrative CRUD.
- [ ] Public pagination and caching.
- [ ] Tests.

### Phase 8: Team and Settings

- [ ] Team management.
- [ ] Public team query.
- [ ] Site settings.
- [ ] Tests.

### Phase 9: Identity and Administrative Security

- [ ] ASP.NET Core Identity.
- [ ] Login and token generation.
- [ ] Refresh-token rotation.
- [ ] Logout and revocation.
- [ ] Roles and permissions.
- [ ] Policy-based authorization.
- [ ] Initial SuperAdmin seeding.
- [ ] Brute-force protection.
- [ ] Audit logs.
- [ ] Security and integration tests.

### Phase 10: AI Integration

- [ ] AI requirements and guardrails.
- [ ] `Microsoft.Extensions.AI` setup.
- [ ] Provider abstraction and implementation.
- [ ] Conversations and messages.
- [ ] Streaming.
- [ ] Structured outputs.
- [ ] Project-request analyzer.
- [ ] Usage and latency tracking.
- [ ] Quotas and rate limits.
- [ ] Prompt-injection defenses.
- [ ] Knowledge grounding.
- [ ] AI evaluation dataset and QA.

### Phase 11: Production Readiness

- [ ] Pagination standard.
- [ ] Index and query review.
- [ ] Output caching.
- [ ] Response compression.
- [ ] Advanced rate limiting.
- [ ] Structured logging.
- [ ] OpenTelemetry.
- [ ] Advanced health checks.
- [ ] Security headers and CORS.
- [ ] Load testing.
- [ ] Backup and restore verification.

### Phase 12: Angular Application

- [ ] Angular foundation.
- [ ] Design system.
- [ ] Public pages.
- [ ] API integration.
- [ ] RTL and LTR localization.
- [ ] AI assistant interface.
- [ ] Authentication flow.
- [ ] Administration dashboard.
- [ ] Accessibility, SSR, SEO, and tests.

### Phase 13: Docker, CI/CD, Launch, and Monitoring

- [ ] API Dockerfile.
- [ ] Full Docker Compose environment.
- [ ] Backend and frontend CI.
- [ ] Container build pipeline.
- [ ] Staging deployment.
- [ ] Production deployment.
- [ ] Migration strategy.
- [ ] Rollback procedure.
- [ ] Final QA.
- [ ] Production launch.
- [ ] Post-launch monitoring.

---

## Current Project Status

```text
Current focus: Backend and Persistence Foundation
Current milestone: Create ApplicationDbContext inside Infrastructure
Frontend status: Planned, not started
Microservices: Not planned for V1
```

The backend error-handling, validation, OpenAPI, health-check, and dependency-injection foundations have been established. Persistence work has started with the Application-level database-context abstraction.

---

## Definition of Done

A feature is complete only when:

- Domain rules are defined.
- The Application use case is implemented.
- Validation is included.
- Infrastructure is implemented where required.
- The HTTP endpoint exists.
- Success and failure responses are documented.
- Expected failures use the Result pattern.
- Unexpected failures are handled safely.
- Appropriate unit tests exist.
- The main path has an integration test.
- The solution builds without unexplained warnings.
- All automated tests pass.
- No secret or sensitive data is committed.
- OpenAPI documentation is updated.
- The change has been reviewed.
- The commit message is clear.

---

## Git Workflow

Suggested branches:

```text
main
develop
feature/project-requests
feature/services
feature/ai-assistant
fix/validation-response
chore/ci-pipeline
```

Example commits:

```text
chore: initialize clean architecture solution
feat: add application result pattern
feat: add global exception handling
feat: add unified model validation
feat: map application results to HTTP responses
test: add foundation integration tests
feat: add application database context abstraction
ci: add backend build and test workflow
```

A pull request should not be merged unless the build and tests succeed, no secrets are present, database changes include the appropriate migration, and API documentation is updated.

---

## Engineering Principles

```text
Clarity over cleverness.
Measured performance over premature optimization.
Explicit boundaries over hidden coupling.
Secure defaults over convenient shortcuts.
Complete vertical features over disconnected layers.
Human-reviewed AI over automatic high-impact decisions.
```

---

## Contributing

The project is currently under active development. Contribution guidance will be formalized as the repository evolves.

Before contributing:

1. Read the architecture and engineering rules.
2. Keep changes focused on one feature or concern.
3. Add or update tests.
4. Run the complete test suite.
5. Update documentation where necessary.
6. Use a clear conventional commit message.

---

<a id="license"></a>
## License

A public license has not yet been selected. Until a license is added, all rights remain reserved by the project owner.

---

## Author

**AbedalQader Alfaqeh**

- GitHub: [3Abedalqader15](https://github.com/3Abedalqader15)
- Project: [Byteqon-Technologies](https://github.com/3Abedalqader15/Byteqon-Technologies)

---

<div align="center">

### Built with strong architecture, disciplined engineering, and a product-first mindset.

**BYTEQON Technologies**

`Build clearly. Scale intentionally. Deliver confidently.`

</div>
