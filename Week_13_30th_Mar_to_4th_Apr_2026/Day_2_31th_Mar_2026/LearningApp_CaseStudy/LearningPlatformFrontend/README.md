# 🎓 LearnHub — Frontend for LearningPlatformAPI

Frontend for the Online Learning Platform API built with plain HTML + CSS + JavaScript.
No frameworks, no build tools — just open and go.

---

## 📁 File Structure

```
LearningPlatformFrontend/
├── index.html          ← Single HTML file (all 4 pages)
├── css/
│   └── style.css       ← All styles
├── js/
│   ├── api.js          ← All API calls (Auth, Courses, Enroll)
│   └── app.js          ← UI logic, routing, role enforcement
└── README.md
```

---

## ✅ Prerequisites

- **LearningPlatformAPI** must be running on `http://localhost:5221`
- A modern browser (Chrome, Edge, Firefox)

---

## 🚀 Steps to Run

### Step 1 — Start the Backend API

Open a terminal and run:
```bash
cd LearningPlatformAPI
dotnet run
```
Confirm it says: `Now listening on: http://localhost:5221`

---

### Step 2 — Open the Frontend in VS Code

Open VS Code → `File → Open Folder` → select `LearningPlatformFrontend`

---

### Step 3 — Install Live Server Extension

In VS Code Extensions panel (`Ctrl+Shift+X`), search for:
```
Live Server
```
Install **Live Server** by Ritwick Dey.

---

### Step 4 — Launch the Frontend

Right-click `index.html` in the Explorer panel → **"Open with Live Server"**

The app opens at: `http://127.0.0.1:5500`

> **Alternative (no extension):** Just double-click `index.html` to open in browser directly.
> However, Live Server is recommended so the page auto-reloads on changes.

---

## 🧭 How the App Works

### Pages
| Page | Route | Description |
|------|-------|-------------|
| Login/Register | Default | Auth page with tab switch |
| All Courses | Courses nav | Browse all courses, search, filter |
| Course Detail | Click "View Details" | See lessons, enroll button |
| Create Course | Nav → "Create Course" | Instructor/Admin only |

### Role-Based Access
| Feature | Student | Instructor | Admin |
|---------|---------|------------|-------|
| View courses | ✅ | ✅ | ✅ |
| Enroll in course | ✅ | ❌ | ❌ |
| Create course | ❌ | ✅ | ✅ |
| Add lesson | ❌ | ✅ | ✅ |

> Instructors and Admins **cannot** enroll — the Enroll button is hidden for them.
> Students **cannot** see Create Course in the navbar.

---

## 🧪 Quick Test Flow

1. **Register** as `Instructor` → Login → Create a course
2. **Register** as `Student` → Login → View courses → Enroll

---

## ⚙️ Configuration

The API base URL is in `js/api.js`:
```javascript
const API_BASE = 'http://localhost:5221';
```
Change this if your API runs on a different port.

---

## 💡 Notes

- JWT token is stored in `localStorage` after login.
- The enroll endpoint (`POST /api/v1/enroll`) requires a `userId` — since the login API returns the username but not the userId, the app will prompt you to enter your User ID the first time you enroll (you can check it in the DB or Swagger).
- After first entry, the userId is saved in localStorage for convenience.
