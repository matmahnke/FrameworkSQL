﻿using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Impl
{
    public class DAL<T> : IDisposable, IEntityCRUD<T> where T : Entity
    {
        TransactionScope transaction;
        public DAL()
        {
            transaction = new TransactionScope();
        }
        public int Delete(T item)
        {
            return new DBExecuter().Execute(SqlGenerator<T>.BuildDeleteCommand(item));
        }

        public void Dispose()
        {
            transaction.Complete();
            transaction.Dispose();
        }

        public void Insert(T item)
        {
            new DBExecuter().Execute(SqlGenerator<T>.BuildInsertCommand(item));
        }

        public List<T> Select(T item)
        {
            DataTable table = new DBExecuter().GetData(SqlGenerator<T>.BuildSelectCommand(item));
            if (table.Rows.Count == 0)
                return null;
            return table.ToObjectCollection<T>();
        }

        public int Update(T item)
        {
            return new DBExecuter().Execute(SqlGenerator<T>.BuildUpdateCommand(item));
        }
    }
}
