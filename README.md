# UniBazaar Lite 🛒🎓

UniBazaar Lite is a lightweight ASP.NET Core Razor Pages & MVC hybrid application designed as a campus marketplace for university students. It allows users to list, browse, and register for events as well as post and purchase second-hand items.

---

## 🔧 Technologies Used

- **ASP.NET Core 7.0**
- **C#**
- **Razor Pages + MVC**
- **In-Memory Repository**
- **Bootstrap / Vanilla CSS**
- **JavaScript (for AJAX & UX enhancements)**

---

## ✨ Features

### 🎟️ Event Management
- Create, edit, and register for university events.
- Clean, responsive UI for event listings.
- Backend validation and custom date input.

### 🛍️ Item Listings
- Post listings for items for sale.
- Browse items with price and seller info.
- Buy functionality via simulated form post.
- AJAX-powered item creation for better UX.

### 🧠 Smart UI & Filters
- Global logging filter for tracking user actions.
- Model validation and error handling included.
- Modular Razor Pages for Events and MVC Controllers for Items.

---

## 📁 Project Structure

```plaintext
UniBazaarLite/
├── Controllers/
│   └── ItemsController.cs
├── Pages/
│   ├── Events/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Register.cshtml
│   └── Contact.cshtml
├── Models/
│   ├── Event.cs
│   └── Listing.cs
├── Services/
│   ├── IRepository.cs
│   └── InMemoryRepository.cs
├── wwwroot/
│   └── css/
│       ├── site.css
│       └── details.css
├── appsettings.json
├── Program.cs
└── README.md
