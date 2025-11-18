# 🛑 Windows Update Blocker

## 💡 Overview

`Windows Update Blocker` is a lightweight utility application designed to give users quick and reliable control over the **Windows Update Service**. The primary goal is to provide a simple graphical interface (GUI) to **enable (start)** or **disable (stop)** the core Windows Update service (`wuauserv`), offering enhanced control over system updates.

This tool is particularly useful for scenarios requiring stable performance without interruptions from background updates, such as during gaming, presentations, or running specialized industrial applications.

## ✨ Key Features

* **Service Toggle:** Instantly start or stop the Windows Update service with a single click.
* **Service Status Display:** Clearly displays the current operational status of the Windows Update service (e.g., Running, Stopped, Paused).
* **Administrative Privilege Check:** Ensures the application is run with necessary permissions (Administrator rights) to modify system services.
* **Simple GUI:** A minimalistic form design focusing purely on the core function.

## 🛠️ Technical Details

This utility interacts directly with the Windows **Service Control Manager (SCM)** to modify the state of the service named **`wuauserv`** (Windows Update).

### Service Control Functions

| Action | Result on `wuauserv` |
| :--- | :--- |
| **Disable/Stop** | Stops the running service. |
| **Enable/Start** | Starts the service. |
| **Get Status** | Retrieves the current state (e.g., Running, Stopped). |

> **IMPORTANT:** The application **must** be run as an **Administrator** to successfully modify the state of system services.

## 🚀 Usage Guide

### 1. Launch the Application

Double-click the `Windows Update Blocker.exe` file. You will be prompted by the User Account Control (UAC) to grant administrative permissions.

### 2. Check Current Status

Upon launch, the status indicator will show the current state:

* 🟢 **Running:** Windows Update is active and can check for updates.
* 🔴 **Stopped:** Windows Update is disabled and cannot perform checks or downloads.

### 3. Toggling the Service

* **To Stop Updates:** Click the **`Disable Updates`** button. The service status will change to `Stopped`.
* **To Enable Updates:** Click the **`Enable Updates`** button. The service status will change to `Running`.

## 📄 License

This project is licensed under the **[MIT License**. See the [LICENSE](LICENSE) file for details.
