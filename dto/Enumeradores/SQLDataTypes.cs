using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Enumeradores
{
    public static class SQLDataTypes
    {
        public const string INT = " INT ";
        public const string NVARCHAR_MAX = " NVARCHAR (MAX) ";
        public static string NVARCHAR(int tamanho)
        {
            return " NVARCHAR(" + tamanho + ") ";
        }
        public const string BIT = " BIT ";
        public const string MONEY = " MONEY ";
        public static string FLOAT(int tamanho)
        {
            return " FLOAT (" + tamanho + ") ";
        }
        public const string DATETIME = " DATETIME ";
        public const string DATETIME2 = " DATETIME2 (7) ";
    }
}
