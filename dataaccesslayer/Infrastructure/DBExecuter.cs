using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using DTO;
using System.Reflection;
using DTO.DataAnnotations;
using System.Xml.Serialization;

namespace DataAccessLayer.Infrastructure
{
    public class DBExecuter
    {
        private ConnectionHelper helper =
            new ConnectionHelper();

        public int Execute(SqlCommand command)
        {
            using (helper)
            {
                try
                {
                    helper.Setup(command);
                    return command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao conectar-se com o banco de dados.");
                }
            }
        }
        public DataTable GetData(SqlCommand command)
        {
            using (helper)
            {
                try
                {
                    helper.Setup(command);
                    DataTable table = new DataTable();
                    table.Load(command.ExecuteReader());
                    return table;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao buscar valores no banco de dados.");
                }
            }
        }
    }
}
