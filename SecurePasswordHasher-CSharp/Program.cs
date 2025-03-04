using System.Security.Cryptography;

namespace SecurePasswordHasher_CSharp;

public static class PasswordHasher
{
    // Configurable parameters
    private const int Iterations = 100000;
    private const int SaltSize = 16; // 128 bits
    private const int HashSize = 32; // 256 bits

    /// <summary>
    /// Generates a secure hash for the password using PBKDF2.
    /// Output format: {iterations}:{salt (Base64)}:{hash (Base64)}
    /// </summary>
    public static string HashPassword(string password)
    {
        // Generate a random salt
        var salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Derive the key (hash) using PBKDF2 with SHA256
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            var hash = pbkdf2.GetBytes(HashSize);
            // Concatenate iterations, salt and hash into a single string
            return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }
    }

    /// <summary>
    /// Verifies if the provided password matches the stored hash.
    /// </summary>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Expected format: iterations:salt:hash
        var parts = hashedPassword.Split(':');
        if (parts.Length != 3)
            return false;

        var iterations = int.Parse(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var storedHash = Convert.FromBase64String(parts[2]);

        // Recompute the hash for the provided password using the stored salt
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        var computedHash = pbkdf2.GetBytes(storedHash.Length);
        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }
}

// Example usage
class Program
{
    static void Main()
    {
        const string password = "Test";
        var hashed = PasswordHasher.HashPassword(password);
        Console.WriteLine($"Generated hash: {hashed}");

        var valid = PasswordHasher.VerifyPassword(password, hashed);
        Console.WriteLine($"Password valid: {valid}");
    }
}