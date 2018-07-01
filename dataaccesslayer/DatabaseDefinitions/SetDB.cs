using DataAccessLayer.Infrastructure;
using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DatabaseDefinitions
{
    public class SetDB
    {
        /// <summary>
        /// Classe que cria as tabelas no banco por reflection.
        /// Para executar, o construtor da classe deve ser chamado.
        /// O assembly DTO deve conter as classes de mapeamento com o
        /// dataAnnotation [TableName] para identificar o nome da classe,
        /// sem isto a classe não é encontrada.
        /// Chave primária criada automaticamente como ID
        /// ForeignKey com ID é feito automaticamente se o tipo da 
        /// propriedade for uma classe que segue os requisitos acima.
        /// É possível configurar usando os DataAnnotations:
        /// NotNull - Setar propriedade Nullable como NOT NULL
        /// PropertyType - Definir outro tipo de dado para o campo no banco
        /// </summary>
        public SetDB(bool DropExistingDB = false)
        {
            if(DropExistingDB)
            Create();
        }
        public void Create()
        {
            //Disney World
            Type[] ClassType = Assembly.Load("DTO").GetTypes();
            for (int i = 0; i < ClassType.Length; i++)
            {
                try
                {
                    string TableName = ClassType[i].GetCustomAttribute<TableName>().Text;
                    new DBExecuter().Execute(new SqlCommand("IF OBJECT_ID('dbo." + TableName + "', 'U') IS NOT NULL  DROP TABLE dbo." + TableName + "; "));
                    string Query = "CREATE TABLE [dbo].[" + TableName + "] (";
                    PropertyInfo[] props = ClassType[i].GetProperties();
                    for (int j = 0; j < props.Length; j++)
                    {
                        string PropertyName = props[j].Name;
                        bool Null = props[j].GetType() == typeof(Nullable);
                        string DataType = getDBType(props[j]);
                        try
                        {
                            if (props[j].GetCustomAttribute<NotNull>().Value)
                                Null = false;
                        }
                        catch { }
                        try
                        {
                            if (!string.IsNullOrEmpty(props[j].GetCustomAttribute<DTO.DataAnnotations.PropertyType>().Text))
                                DataType = props[j].GetCustomAttribute<DTO.DataAnnotations.PropertyType>().Text;
                        }
                        catch { }

                        string DbNull = (Null) ? "NULL" : "NOT NULL";
                        Query += " [" + props[j].Name + "] " + DataType + " " + DbNull + ",";
                        if (PropertyName.EndsWith("ID") && PropertyName != "ID")
                        {
                            for (int l = 0; l < ClassType.Length; l++)
                            {
                                if (ClassType[l] == props[j].PropertyType)
                                {
                                    try
                                    {
                                        string fk = ClassType[l].GetCustomAttribute<TableName>().Text;
                                        Query += $"CONSTRAINT [FK_{TableName}_To{fk}] FOREIGN KEY ([{PropertyName}]) REFERENCES [dbo].[{TableName}] ([{"ID"}]),";
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                }

                            }
                        }

                    }
                    Query += "    PRIMARY KEY CLUSTERED([Id] ASC)                " +
                        ");";
                    new DBExecuter().Execute(new SqlCommand(Query));
                }
                catch (Exception e)
                {
                }
            }
        }
        private string getDBType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return "NVARCHAR(MAX)";
            if (prop.PropertyType == typeof(bool))
                return "BIT";
            if (prop.PropertyType == typeof(DateTime))
                return "DATETIME2(7)";
            if (prop.PropertyType == typeof(int))
                return "INT";
            if (prop.PropertyType == typeof(double))
                return "MONEY";
            return string.Empty;
        }
    }
}
