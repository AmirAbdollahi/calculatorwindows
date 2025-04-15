# CalculatorWindows

A simple desktop calculator built with **C#** and **Windows Forms (.NET Framework)**. This project demonstrates event-driven programming, GUI component layout, and basic logic structuring for arithmetic operations.

![image](https://github.com/user-attachments/assets/ad89ae31-9e63-4153-9ab4-aae00ae7918d)


---

## Technologies Used

- **Language**: C# (.NET Framework)
- **UI Framework**: Windows Forms
- **IDE**: Visual Studio
- **Design Pattern**: Event-driven architecture

---

## Features

- Basic arithmetic: `+`, `-`, `×`, `÷`
- Decimal input support
- `CE` (Clear Entry) and `C` (Clear All) functionality
- Support for chaining operations
- Keyboard input handling
- Prevents invalid expressions (e.g., division by zero)
- Optional form resizing behavior

---

## Project Structure

```
CalculatorWindows/
│
├── CalculatorWindows.sln              # Visual Studio solution file
└── CalculatorWindows/
    ├── Form1.cs                       # Code-behind for UI logic (event handlers)
    ├── Form1.Designer.cs              # Auto-generated UI layout and controls
    ├── Program.cs                     # Main entry point (Application.Run)
    └── Resources/                     # (Optional) Icons, fonts, or images
```

---

## Getting Started

### Prerequisites

- Windows OS
- Visual Studio 2019 or later
- .NET Framework 4.x installed

### Build & Run

1. Clone the repository:
   ```bash
   git clone https://github.com/AmirAbdollahi/calculatorwindows.git
   ```

2. Open `CalculatorWindows.sln` in Visual Studio.

3. Set `CalculatorWindows` as the startup project.

4. Press `F5` to build and run.

---

## Testing

This project currently supports manual testing. You can test it by:

- Clicking UI buttons in different sequences
- Entering decimals
- Dividing by zero
- Using both keyboard and mouse input

---

## Future Improvements

- Memory functionality (`MC`, `MR`, `M+`, `M-`)
- Parentheses handling
- Complete keyboard-only interaction
- Expression parsing engine
- History panel for past calculations
- Unit tests using MSTest, xUnit, or NUnit

---

## Author

**Amir Abdollahi**  
[GitHub Profile](https://github.com/AmirAbdollahi)

---

## License

This project is licensed under the [MIT License](LICENSE).


