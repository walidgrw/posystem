# 🍽️ POSystem – Restaurant POS System

A modern restaurant Point of Sale system built with ASP.NET Core MVC & Entity Framework. Designed to streamline orders, receipts, split payments, feedback collection, and shift reporting.

---

## 🚀 Key Features

- 🧾 Step-by-step Order Creation with Review
- 💳 Multiple Payment Methods (split bills)
- 📄 Printable Receipts with VAT breakdown
- 📲 QR Code Feedback (food, service, cleanliness)
- 📊 Dashboard & Shift Reports
- 📦 CSV Export for accounting
- 🧑‍💼 Role-based access: Staff, Supervisor, Manager

---

## 🛠️ How to Run

### 1. Clone & Build

```bash
git clone https://github.com/walidgrw/posystem.git
cd posystem
dotnet restore
dotnet ef database update
2. Start the Server with Network Access
To make the QR code link work on mobile:

bash
Copy
Edit
dotnet run --urls http://0.0.0.0:5000
🔗 This makes the app accessible from other devices on the same network.

3. Get Your IP Address
Open terminal & run:

bash
Copy
Edit
ipconfig
Copy your local IP address (e.g., 192.168.x.x) and update this line inside your Details.cshtml:

csharp
Copy
Edit
string url = $"http://192.168.x.x:5000/Feedback/Create?orderId={Model.Id}";
Now QR code will open a real page on the customer’s phone.

⚙️ Tech Stack
ASP.NET Core MVC

SQL Server / LocalDB

Entity Framework Core

Bootstrap 5

jsPDF, QRCoder

📦 Deployment Ready
Run on LAN for tablet/mobile order

Export reports for accounting

Print receipts or save as PDF

Customer can scan → give feedback instantly

🧑‍💻 Author
Walid Grawi – github.com/walidgrw

yaml
Copy
Edit

---

Want me to generate this into a real `README.md` file and add it to your repo directory?
