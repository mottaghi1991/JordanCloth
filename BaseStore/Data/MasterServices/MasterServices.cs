using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.MasterInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.MasterServices
{
    public class MasterServices<T>:IMaster<T> where T:class
    {

        protected MyContext _ctx;
        protected IDbConnection cnnsql;
        protected readonly string cnn;

        public MasterServices(MyContext ctx)
        {
            _ctx = ctx;
            cnn = ctx.Database.GetConnectionString();
            cnnsql = new SqlConnection(cnn);

        }
        public IEnumerable<T> GetAll()
        {
            var obj = cnnsql.Query<T>($"Select * FROM {typeof(T).Name}").ToList();
            return obj;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter)
        {
            var obj = cnnsql.Query<T>($"Select * FROM {typeof(T).Name}").AsQueryable().Where(Filter).ToList();
            return obj;
        }

        public IEnumerable<T> GetAll(string spName, DynamicParameters parameters)
        {
            IEnumerable<T> obj = null;

            try
            {

                using (IDbConnection connection = new SqlConnection(cnn))
                {
                    obj = cnnsql.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return obj;
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return obj;
            }
        }

        public IEnumerable<T> GetAll(string spName)
        {
            IEnumerable<T> obj = null;

            try
            {

                using (IDbConnection connection = new SqlConnection(cnn))
                {
                    obj = cnnsql.Query<T>(spName, null, commandType: CommandType.StoredProcedure).ToList();
                }
                return obj;
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return obj;
            }
        }

        public int GetNumberFromDatabase(string spName, object[] parameters)
        {
            if (parameters == null)
            {
                return _ctx.Database.ExecuteSqlRaw(spName);
            }
            else
            {
                return _ctx.Database.ExecuteSqlRaw(spName, parameters);
            }
        }

        public string GetStringFromDatabase(string spName, DynamicParameters parameters)
        {
            return cnnsql.ExecuteScalar<string>(spName, parameters);
        }

        public T Insert(T Obj)
        {
            _ctx.Add(Obj);
            _ctx.SaveChanges();
            return Obj;
        }

        public bool Delete(T Obj)
        {
            try
            {
                _ctx.Remove(Obj);
                _ctx.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T Update(T Obj)
        {
            try
            {
                _ctx.Set<T>().Update(Obj);
                _ctx.SaveChanges();
                return Obj;

            }
            catch (Exception e)
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public bool BulkeInsert(List<T> ListOfbulk)
        {
            try
            {

                _ctx.Set<T>().AddRange(ListOfbulk);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool BulkeDelete(IEnumerable<T> ListOfbulk)
        {
            try
            {

                _ctx.Set<T>().RemoveRange(ListOfbulk);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
