using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;

namespace Data.MasterInterface
{
    public interface IMaster<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter);
        IEnumerable<T> GetAll(string spName, DynamicParameters parameters);
        IEnumerable<T> GetAll(string spName);
        int GetNumberFromDatabase(string spName, object[] parameters);
        string GetStringFromDatabase(string spName, DynamicParameters parameters);
        T Insert(T Obj);
        bool Delete(T Obj);
        T Update(T Obj);
        bool BulkeInsert(List<T> ListOfbulk);
        bool BulkeDelete(IEnumerable<T> ListOfbulk);
    }
}