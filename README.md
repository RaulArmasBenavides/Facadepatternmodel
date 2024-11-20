
# Quadratic Equation Solver with Strategy Pattern

This project demonstrates the implementation of the **Strategy Design Pattern** for solving quadratic equations. The focus is on showcasing how different strategies can be applied for discriminant calculation, making this an excellent example of **structural design patterns**.

## Overview

A quadratic equation is a second-order polynomial equation in a single variable \( ax^2 + bx + c = 0 \). The solutions are computed using the quadratic formula:

\[
x = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a}
\]

Here, the discriminant \( b^2 - 4ac \) plays a critical role in determining the nature of the roots.

### Strategies Implemented

1. **Ordinary Discriminant Strategy**:
   - Computes the discriminant as-is, even if it is negative.
   - This is suitable for applications where solutions as **complex numbers** are acceptable.

2. **Real Discriminant Strategy**:
   - Returns `NaN` (Not a Number) if the discriminant is negative.
   - Ensures that only real roots are considered valid.

### Quadratic Equation Solver
The solver is implemented to work with any discriminant strategy, allowing flexible usage depending on the requirements.

---

## Features

- **Extensible Design**:
  - Easy to add more discriminant calculation strategies.
- **Real and Complex Number Support**:
  - Uses .NET's `System.Numerics.Complex` to handle complex roots.
- **Educational Value**:
  - Demonstrates a practical use of the Strategy Pattern in C#.

---

## Requirements

- **.NET SDK** (version 5.0 or higher)
- A text editor or IDE, such as **Visual Studio** or **Visual Studio Code**.

---

## How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/your-repository/quadratic-solver.git
   ```

2. Navigate to the project folder:
   ```bash
   cd quadratic-solver
   ```

3. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```

---

## Code Structure

- **`IDiscriminantStrategy`**: Defines the interface for different discriminant strategies.
- **`OrdinaryDiscriminantStrategy`**: A strategy that computes the discriminant directly.
- **`RealDiscriminantStrategy`**: A strategy that ensures only real discriminants are returned.
- **`QuadraticEquationSolver`**: The main class for solving quadratic equations.

---

## Example Output

For a quadratic equation \( x^2 + x + 1 = 0 \), the program outputs:

- **Ordinary Strategy**:
  - Root 1: -0.5 + 0.866i
  - Root 2: -0.5 - 0.866i
- **Real Strategy**:
  - Root 1: NaN
  - Root 2: NaN

---

## Purpose

This project is designed to help developers and students practice:

- **Structural Design Patterns**, specifically the **Strategy Pattern**.
- Writing modular and reusable code.
- Solving mathematical equations programmatically.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## Author

Developed with ❤️ by [Your Name].
