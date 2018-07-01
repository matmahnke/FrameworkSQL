using DTO;
using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer.Infrastructure
{
    public class SqlGenerator
    {
        private static string GetTableName(Entity obj)
        {
            return obj.GetType().GetCustomAttribute<TableName>().Text;
        }
        #region Insert
        public static SqlCommand
            BuildInsertCommand(Entity item)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", GetTableName(item), GetInsertFields(false, item), GetInsertFields(true, item));
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            GenerateInsertParameters(command, item);
            return command;
        }

        private static void GenerateInsertParameters(SqlCommand command, Entity item)
        {
            foreach (PropertyInfo propriedade in item.GetType().GetProperties())
            {
                if (propriedade.Name != "ID")
                {
                    if (propriedade.GetValue(item) == "" || propriedade.GetValue(item) == null)
                        command.Parameters.AddWithValue("@" + propriedade.Name, DBNull.Value);
                    else
                        if (propriedade.GetType().BaseType == typeof(Entity))
                        command.Parameters.AddWithValue("@" + propriedade.Name, ((Entity)propriedade.GetValue(item)).ID);
                    else
                        command.Parameters.AddWithValue("@" + propriedade.Name, propriedade.GetValue(item));
                }

            }
        }

        private static string GetInsertFields(bool isParameters, Entity obj)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in obj.GetType().GetProperties())
            {
                if (item.Name != "ID")
                {
                    if (isParameters)
                    {
                        builder.Append("@" + item.Name + ",");
                    }
                    else
                    {
                        builder.Append(item.Name + ",");
                    }
                }
            }
            builder = builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        #endregion

        #region Update
        public static SqlCommand BuildUpdateCommand(Entity item)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("UPDATE {0} SET {1} WHERE ID = @ID", GetTableName(item), GetUpdateFields(item));
            SqlCommand command = new SqlCommand();
            command.CommandText = builder.ToString();
            GenerateUpdateParameters(command, item);
            return command;
        }

        private static string GetUpdateFields(Entity obj)
        {
            StringBuilder builder = new StringBuilder();
            foreach (PropertyInfo item in obj.GetType().GetProperties())
            {
                if (item.GetCustomAttribute<NonEditable>() == null)
                {
                    builder.Append(item.Name + " = @" + item.Name + ",");
                }
            }
            return builder.ToString(0, builder.Length - 1);
        }


        private static void GenerateUpdateParameters(SqlCommand command, Entity item)
        {
            foreach (PropertyInfo propriedade in item.GetType().GetProperties())
            {
                if (propriedade.GetCustomAttribute<NonEditable>() == null)
                {
                    if (propriedade.GetValue(item) == "" || propriedade.GetValue(item) == null)
                    {
                        command.Parameters.AddWithValue("@" + propriedade.Name, DBNull.Value);
                    }
                    else
                    {
                        if (propriedade.GetType().BaseType == typeof(Entity))
                            command.Parameters.AddWithValue("@" + propriedade.Name, ((Entity)propriedade.GetValue(item)).ID);
                        else
                            command.Parameters.AddWithValue
                        ("@" + propriedade.Name, propriedade.GetValue(item));
                    }


                }
            }
            command.Parameters.AddWithValue("@ID", item.ID);
        }
        #endregion

        #region Delete
        public static SqlCommand BuildDeleteCommand(Entity item)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = string.Format("DELETE FROM {0} WHERE ID = @ID", GetTableName(item));
            command.Parameters.AddWithValue("@ID", item.ID);
            return command;
        }
        #endregion

        #region Select
        public static SqlCommand BuildSelectCommand(Entity item)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat($"SELECT * FROM {GetTableName(item)} WHERE ");
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            GenerateSelectWhere(command, item);
            return command;
        }

        private static void GenerateSelectWhere(SqlCommand command, Entity item)
        {
            foreach (PropertyInfo propriedade in item.GetType().GetProperties())
            {
                try
                {
                    if (propriedade.GetValue(item) != null)
                    {
                        command.CommandText += new StringBuilder(" " + propriedade.Name + " = @" + propriedade.Name).ToString() + " AND";
                        if (propriedade.GetType().BaseType == typeof(Entity))
                            command.Parameters.AddWithValue("@" + propriedade.Name, ((Entity)propriedade.GetValue(item)).ID);
                        else
                            command.Parameters.AddWithValue("@" + propriedade.Name, propriedade.GetValue(item));
                        if (propriedade.Name == "ID")
                            return;
                    }
                }
                catch (Exception)
                {
                }
            }
            command.CommandText = command.CommandText.TrimEnd("AND".ToArray());
        }
        #endregion
    }
}
