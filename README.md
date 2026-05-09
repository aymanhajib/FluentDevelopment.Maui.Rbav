
# FluentDevelopment.Maui.Rbav 🛡️

[![NuGet Version](https://img.shields.io/badge/nuget-v10.0.0-blue.svg)](https://www.nuget.org/packages/FluentDevelopment.Maui.Rbav)
[![Framework: .NET 10](https://img.shields.io/badge/Framework-.NET%2010-purple.svg)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platforms-Android%20%7C%20iOS%20%7C%20Windows%20%7C%20macOS-Set.svg)](https://dotnet.microsoft.com/en-us/apps/maui)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

**FluentDevelopment.Maui.Rbav** is a specialized, observable Role-Based Access View (RBAV) library for **.NET MAUI**. It empowers developers to build secure, reactive UIs using declarative XAML extensions that automatically update when the user's role or permissions change.

---

## ✨ Features

-   **Reactive Security:** Implements `INotifyPropertyChanged` to refresh UI visibility instantly upon `CurrentRole` changes.
-   **XAML Markup Extensions:** Clean, readable syntax for securing UI elements (`Role`, `Resource`, `Permission`).
-   **Hierarchical Parsing:** Advanced dot-notation parsing for granular permission logic (e.g., `Module.Feature.Action`).
-   **Multi-Role Validation:** Support for comma-separated role checks within a single XAML attribute.
-   **High Performance:** Optimized Value Converters and shared singleton instances to ensure minimal memory footprint.

---

## 📦 Installation

Install via NuGet Package Manager:

```bash
dotnet add package FluentDevelopment.Maui.Rbav --version 10.0.0
