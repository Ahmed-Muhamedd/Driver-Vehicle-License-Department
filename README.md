# 🚗 Driver & Vehicle License Department System

A comprehensive desktop-based management system designed to simulate the workflow of a real-world driver and vehicle licensing department. This system includes full CRUD functionality, secure login features, application processing, and test management for license issuance.

---
## 📽️ Project Demo  
**📽️ [Click here to watch the demo video]([https://your-link.com](https://drive.google.com/file/d/1nKDc1KFhkt4ejh6Ow7Z4vUUF8mGbG8J2/view?usp=sharing))**


## 🛠 Technologies Used

- **C#**
- **.NET Framework**
- **Windows Forms**
- **SQL Server**
- **ADO.NET**
- **3-Tier Architecture**
  - Data Access Layer (DAL)
  - Business Logic Layer (BLL)
  - Presentation Layer (UI)

The project applies **Separation of Concerns** and **Divide and Conquer** principles for clean, maintainable, and scalable architecture.

---

## 📦 Core Features

### 🔐 User Authentication & Security
- **Login System** with "Remember Me" option:
  - If selected, the system securely stores the **username and password** in the Windows **Registry**.
- **Password Hashing**: Securely stores user credentials using a hashing algorithm.
- **Change Password**: Logged-in users can securely update their own passwords.
- **Registry Storage**: Used to save credentials for "Remember Me" functionality securely.

### 👥 User, People & Driver Management
- Full **CRUD operations** for:
  - **Users**
  - **People** (license applicants)
  - **Drivers**
- **Image Management**:
  - Personal images are saved in the file system.
  - Images are automatically deleted when a person record is removed.

### 🔎 Filtering & Search
- filtering in:
  - **Users**
  - **People**
  - **Drivers**
- Makes it easy to manage and quickly locate specific records.

### ✔️ Input Validation
- input validation using specific rules for each field:
  - Example: email format, ID numbers, dates, and other critical fields.
- Prevents invalid or incomplete data entry.

---

## 📄 Application Types

The system supports multiple types of driver license-related applications. Each application type has its **own requirements and processing logic**, ensuring a realistic and rule-based flow for each scenario.

### 🔸 Available Application Types:

- **🆕 New Local License**  
  Apply for a new local driver's license. Requires passing all tests (vision, written, street) and providing valid identification.

- **♻️ Renew License**  
  Extend the validity of an existing license. Requires checking expiration date, personal info.

- **🔁 Replace License (Damaged)**  
  Issue a replacement for a physically damaged license. Requires identity verification.

- **❌🔁 Replace License (Lost)**  
  Issue a new license if the original is lost.

- **🚫📤 Detained & Release License**  
  Temporarily detain licenses due to violations. Supports releasing them after fulfilling legal or administrative requirements.

- **🌍 New International License**  
  Issue international driving licenses. Requires an existing valid local license.

- **🔄 Retake Test**  
  Allows applicants who failed one or more license tests to retake only the failed components. Ensures a flexible and fair licensing process.

---

## 🛂 License Processing Features

### 🆕 New License Issuance
- Supports both **Local** and **International** licenses.

### 🔁 License Management
- **Renew Licenses**
- **Detain & Release Detained Licenses**
- **Replace Lost or Damaged Licenses**

### 🧪 License Testing  
- Applicants must pass **all required tests**:
  - **Vision Test**
  - **Written Test**
  - **Street Driving Test**
- **Scheduling System**:
  - Organize and manage test appointments for each applicant.
- Only after passing all tests is a license issued.

---

## 🧱 Architecture & Design

- **3-Tier Architecture**:
  - **Data Access Layer (DAL)**: SQL Server interactions via ADO.NET.
  - **Business Logic Layer (BLL)**: Business rules and validation logic.
  - **Presentation Layer**: Windows Forms UI for user interaction.

- **Design Principles**:
  - **Separation of Concerns** for modularity and maintainability.
  - **Divide and Conquer** approach for simplifying complex tasks.


