# design-patterns-solid

# 🧠 Design Patterns & SOLID Principles

This repository contains practical implementations of **SOLID principles** and **object-oriented design patterns**, written in multiple programming languages:

- **Java**
- **C#**
- **TypeScript**
- **Go**

The goal is to provide a clear, multi-language reference for understanding and applying best practices in software design.

---

## 📁 Repository Structure

---

## 🔑 SOLID Principles

**SOLID** is an acronym for five fundamental object-oriented design principles:

### 1. **S — Single Responsibility Principle (SRP)**
A class should have **only one reason to change**.  
➡️ Each class should focus on a single responsibility.

### 2. **O — Open/Closed Principle (OCP)**
Software entities should be **open for extension but closed for modification**.  
➡️ You can extend behavior without altering existing code.

### 3. **L — Liskov Substitution Principle (LSP)**
Subtypes must be **substitutable** for their base types without breaking the application.  
➡️ Derived classes should honor the contracts of their base classes.

### 4. **I — Interface Segregation Principle (ISP)**
Clients should not be forced to depend on interfaces they don't use.  
➡️ Prefer small, specific interfaces over large, general ones.

### 5. **D — Dependency Inversion Principle (DIP)**
High-level modules should not depend on low-level modules; both should depend on **abstractions**.  
➡️ Rely on interfaces, not concrete implementations.

---

## 🧩 Design Patterns

Design patterns are **general solutions to common software design problems**. They are typically categorized into three types:

### 🔧 1. **Creational Patterns**
Concerned with object creation mechanisms:
- **Singleton**: Ensures a class has only one instance.
- **Factory Method**: Delegates object creation to subclasses.
- **Abstract Factory**: Produces families of related objects.
- **Builder**: Constructs complex objects step by step.
- **Prototype**: Clones existing objects.

### 🧱 2. **Structural Patterns**
Deal with object composition and relationships:
- **Adapter**: Converts one interface into another.
- **Decorator**: Adds behavior without modifying the object.
- **Composite**: Treats individual objects and compositions uniformly.
- **Facade**: Provides a simplified interface to a complex subsystem.
- **Proxy**: Controls access to another object.

### 🤝 3. **Behavioral Patterns**
Focus on communication between objects:
- **Observer**: Notifies multiple objects of state changes.
- **Strategy**: Enables dynamic selection of algorithms.
- **Command**: Encapsulates requests as objects.
- **State**: Changes object behavior based on internal state.
- **Template Method**: Defines the program skeleton in a base class.

---

## 🚀 Getting Started

1. Clone the repository:
```bash
git clone git@github.com:your-username/design-patterns-solid.git


## 🔁 Example: Strategy + OCP + DIP in C#

📂 File: `/examples/strategy-ocp-dip.cs`

This example demonstrates how to apply three key software design principles and patterns together:

---

### 🧠 1. Strategy Pattern

**Definition**: Define a family of algorithms, encapsulate each one, and make them interchangeable at runtime.

In this example:

- `IPaymentStrategy` defines a common interface.
- `CreditCardPayment`, `CashPayment`, and `CryptoPayment` implement the strategy.
- `PaymentService` uses a strategy without knowing which one.

✅ This allows changing the behavior (payment method) without modifying the service logic.

---

### 🧠 2. Open/Closed Principle (OCP)

**Definition**: Software should be open for extension but closed for modification.

In this example:

- You can add new payment strategies like `PayPalPayment` without changing `PaymentService`.
- No need to edit existing code to support new behavior.

✅ This supports safe and scalable code extension.

---

### 🧠 3. Dependency Inversion Principle (DIP)

**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.

In this example:

- `PaymentService` (high-level) depends on `IPaymentStrategy` (abstraction).
- `CreditCardPayment`, `CashPayment`, etc., also depend on the same abstraction.
- `PaymentService` does **not** depend on concrete implementations.

✅ This decouples components, improves flexibility, and allows for easier testing.

---

### 🧪 Sample usage in `Main()`:

```csharp
var payment = new PaymentService(new CryptoPayment());
payment.ProcessPayment(150.00m);