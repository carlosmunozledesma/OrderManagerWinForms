# Order Manager - WinForms Demo Project

This is a multi-threaded WinForms desktop application built with .NET 9. It simulates a simple order management system with dynamic UI updates, status tracking, and asynchronous operations — inspired by requirements in fintech and real-time trading platforms.

## ✨ Features

- Add and process simulated "orders" with predefined durations.
- Asynchronous task execution using `async/await`.
- Thread-safe UI updates using `Invoke` pattern.
- Color-coded order statuses (`Pending`, `Processing`, `Completed`, `Cancelled`).
- Progress bar that visually tracks order completion.
- Real-time UI updates without flickering (`DoubleBuffered` ListView).
- Order selection highlighting for better visibility.
- Clean and readable code with English naming and comments.

## 🧰 Technologies Used

- **.NET 9**
- **C#**
- **Windows Forms (WinForms)**
- **Task-based Asynchronous Programming**
- **System.Drawing & UI customization**

## 📷 Screenshots

> *(Insert a couple of screenshots of the app running — main window, progress, colored list, etc.)*
> ![image](https://github.com/user-attachments/assets/b05b5d49-16d1-47a7-8140-bdb304cb5065)
![image](https://github.com/user-attachments/assets/760f36be-1335-4437-8b67-e44334c4230c)
![image](https://github.com/user-attachments/assets/45834637-a34b-4dfd-a792-c04d175bff0d)


## 🗃️ Project Structure

- `MainForm.cs` – Core logic and UI interactions
- `Order.cs` – Order model

## 🧠 Learning Objectives

This project was built as part of a preparation for a remote fintech developer role. It showcases:

- Real-time UI updates in WinForms.
- Multi-threaded logic applied to simulated business logic.
- Clean code, structured design, and modular expansion.

## 🚀 Future Improvements

- Persisting orders with SQL Server Compact or LiteDB.
- Add cancellation confirmation dialog.
- Export completed orders as CSV or JSON.
- Unit tests for order lifecycle logic.
- Add random duration in "orders"

## 👨‍💻 Author

Carlos Munoz Ledesma
www.linkedin.com/in/carlos-munoz-ledesma  
📍 Based in Ireland
