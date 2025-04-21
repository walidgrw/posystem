# 🍽️ POSystem – Restaurant Point of Sale System

**POSystem** is a full-featured, modern Point of Sale (POS) system built with ASP.NET Core MVC and Entity Framework Core. It’s designed specifically for restaurants to handle orders, manage menus, split bills, generate receipts, collect customer feedback, and analyze daily performance through reports.

---

## 🚀 Features

- ✅ **Menu Management**
  - Add/edit/delete categorized menu items (Main Dishes, Pizzas, Burgers, etc.)
  - Set item availability

- 🧾 **Order Handling**
  - Step-by-step order placement
  - Live search & category filters
  - Order review before confirmation
  - Multiple payment methods (split bills: Cash, Card, QR, Other)

- 💳 **Professional Receipt**
  - Beautiful printed receipts with VAT breakdown
  - QR code linking to customer feedback form
  - PDF export and print support

- 📝 **Customer Feedback**
  - QR code on receipts leads to a live feedback form
  - Rate food, service, and cleanliness (0–5 stars)
  - Optional comment field
  - Feedback saved in the database for later review

- 📊 **Dashboard & Reports**
  - Real-time sales overview
  - Daily best sellers
  - Order history with date filtering
  - CSV export for accounting
  - Shift closing report (sales summary by user, payments, totals)

- 👥 **Role-Based Access**
  - Staff, Supervisor, and Manager access levels
  - Managers can void orders, close shifts, and export data

---

## 🧰 Tech Stack

- **Frontend:** Razor Pages + Bootstrap 5
- **Backend:** ASP.NET Core MVC
- **Database:** SQL Server (LocalDB or full instance)
- **ORM:** Entity Framework Core
- **Authentication:** Session-based login with role management
- **Others:**
  - `QRCoder` for generating receipt QR codes
  - `jsPDF` for PDF export

---

## 📸 Screenshots

> You can add actual images here using:  
> `![Screenshot](screenshots/order-page.png)`  
> Create a `screenshots/` folder in the repo and upload your images.

---

## ⚙️ Installation & Setup

### 🔧 Prerequisites

- [.NET SDK 8+](https://dotnet.microsoft.com/)
- Visual Studio or VS Code
- SQL Server LocalDB (or update connection string for full SQL)

### 🖥️ Run Locally

```bash
git clone https://github.com/walidgrw/posystem.git
cd posystem
dotnet restore
dotnet ef database update
dotnet run

