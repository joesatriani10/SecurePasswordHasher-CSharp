# SecurePasswordHasher_CSharp

This is a simple C# Console Application that demonstrates secure password hashing using PBKDF2 with SHA256.

---

## Overview

The project implements secure password hashing and verification with the following key features:

- **Secure Password Hashing:** Uses PBKDF2 with SHA256 to generate a secure hash.
- **Random Salt Generation:** Generates a random salt for each password, ensuring that identical passwords result in different hashes.
- **Self-Contained Hash Format:** The generated hash string includes the iteration count, salt (Base64), and hash (Base64), separated by colons.
- **Password Verification:** Recomputes the hash using the stored salt and iteration count to verify if an entered password is correct.

---

## Features

- **PBKDF2 Implementation:** Configurable number of iterations (set to 100,000 by default) to enhance security.
- **Random Salt:** A 16-byte salt is generated for each password, ensuring uniqueness.
- **Fixed-Time Comparison:** Uses a fixed-time comparison to prevent timing attacks during password verification.
- **Example Usage:** The `Program` class demonstrates how to hash and verify a password.

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (preferably .NET 5.0 or later)
- An IDE such as [Rider](https://www.jetbrains.com/rider/) or Visual Studio

---

## Project Structure

