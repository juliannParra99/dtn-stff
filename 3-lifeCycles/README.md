# Dependency Injection and Service Lifetimes in ASP.NET Core

This application demonstrates how to implement and observe the behavior of different service lifetimes (`Transient`, `Scoped`, and `Singleton`) in ASP.NET Core using Dependency Injection (DI). The app uses these lifetimes to show how multiple instances of the same service behave depending on their registered lifetime.

## Features

- **Transient Services**: New instance created every time the service is requested.
- **Scoped Services**: Same instance used within a single request, but a new instance is created for each new request.
- **Singleton Services**: One instance used throughout the entire application lifecycle, shared across all requests.

## Technologies Used

- .NET Core
- ASP.NET Core MVC
- Dependency Injection
- Service Lifetimes

## How the Lifetimes Work

### 1. Transient Lifetime

- A new instance of the service is created each time it is requested from the dependency injection container.
- In the app, two transient services (`IExampleTransientService`) are injected into the `HomeController`, and each one receives a new GUID, demonstrating the creation of a new instance for each injection.

### 2. Scoped Lifetime

- A single instance is created per HTTP request. This means the same instance is shared across the request, but a new instance is created for each new request.
- Two scoped services (`IExampleScopedService`) are injected into the `HomeController`, but they share the same GUID within a single request, demonstrating that they use the same instance for that request.

### 3. Singleton Lifetime

- A single instance is created and shared across the entire application's lifetime. All requests and services share the same instance.
- Two singleton services (`IExampleSingletonService`) are injected into the `HomeController`, and they both share the same GUID, demonstrating that only one instance is created and used throughout the entire application.

## Sample:

```plaintext
Transient 1: d05332b5-a413-4c3f-87a9-26d410685172
Transient 2: 20e44e0d-159b-4313-a3a5-49b10f463375

Scoped 1: 7b13e9cf-87d8-4fcd-9183-87d9254910c9
Scoped 2: 7b13e9cf-87d8-4fcd-9183-87d9254910c9

Singleton 1: a46df119-4402-4e40-8ce6-5c9db0b9942d
Singleton 2: a46df119-4402-4e40-8ce6-5c9db0b9942d
```
