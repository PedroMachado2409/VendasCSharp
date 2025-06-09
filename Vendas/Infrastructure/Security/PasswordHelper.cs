﻿namespace Vendas.Infrastructure.Security
{
    public static class PasswordHelper
    {
        public static string HashPassword(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool VerifyPassword(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
