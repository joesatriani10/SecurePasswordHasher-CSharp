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

## Usage Example

Below is an example of how to use the `PasswordHasher` class in a C# Console Application:

```csharp
using System;

class Program
{
    static void Main()
    {
        const string password = "Test";
        string hashed = PasswordHasher.HashPassword(password);
        Console.WriteLine($"Generated hash: {hashed}");

        bool isValid = PasswordHasher.VerifyPassword(password, hashed);
        Console.WriteLine($"Password valid: {isValid}");
    }
}
```

## Security Recommendations

- **High Iteration Count:**  
  Use a high number of iterations (e.g., 100,000 or more) to increase the computational cost of brute-force attacks. Regularly review and adjust this parameter based on current hardware capabilities.

- **Unique, Random Salt:**  
  Generate a new random salt for each password. Storing the salt with the hash ensures that even if two users have the same password, their hashes will differ.

- **Secure Storage Format:**  
  Store the iteration count, salt (Base64 encoded), and hash (Base64 encoded) together in a well-defined format. This ensures that all parameters needed for verification are available.

- **Constant-Time Comparison:**  
  Use constant-time methods (e.g., `CryptographicOperations.FixedTimeEquals` in C#) for comparing hashes to prevent timing attacks.

- **Utilize Established Libraries:**  
  For production applications, consider using well-established libraries and frameworks that have undergone extensive security audits.

- **Secure Data Handling:**  
  Ensure that all sensitive data, including hashed passwords, are stored securely. Use encryption for data at rest and secure channels (e.g., HTTPS) for data in transit.

- **Regular Security Audits:**  
  Periodically review and update your security practices and parameters to align with current best practices and emerging threats.

