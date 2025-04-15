using System;

namespace Concessionaria.Repository.Infra.HandledExceptions
{
    public class DbException : Exception
    {
        public DbException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}