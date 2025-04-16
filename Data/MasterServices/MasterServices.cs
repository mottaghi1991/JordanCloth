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
using MySqlConnector;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Domain;
using EventId = Domain.EventId;
using Domain.Exam;



namespace Data.MasterServices
{
    public class MasterServices<T> : IMaster<T> where T : class
    {

        protected MyContext _ctx;
        protected IDbConnection cnnsql;
        protected readonly string cnn;
        private readonly IHttpContextAccessor _accessor;

        private readonly ILogger _logger;

        public MasterServices(MyContext ctx, ILoggerFactory factory, IHttpContextAccessor accessor)
        {
            _ctx = ctx;
            cnn = ctx.Database.GetConnectionString();
            cnnsql = new SqlConnection(cnn);
            _logger = factory.CreateLogger("NoorMehr");
            _accessor = accessor;
            //cnnsql = new MySql.Data.MySqlClient.MySqlConnection(cnn);mysql
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                var obj = cnnsql.Query<T>($"Select * FROM {typeof(T).Name}").ToList();
                return obj;
            }
            catch (Exception ex) {
                _logger.LogError( EventId.Error,ex, "(Data Error) User Run GetAll and Get Error  ObjectName= {ObjectName}   and UserId = {UserId}", typeof(T).Name, GetUserId());
                return Enumerable.Empty<T>();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter)
        {
            try
            {
                var obj = cnnsql.Query<T>($"Select * FROM {typeof(T).Name}").AsQueryable().Where(Filter).ToList();
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(EventId.Error, ex, "(Data error) User Run GetAll Dapper ObjectName= {ObjectName} With Expression and UserId = {UserId}", typeof(T).Name, GetUserId());
                return Enumerable.Empty<T>();
            }
            
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
                _logger.LogError(EventId.Error, ex, "(Data Error) User Run GetAll With sp and Get Error  ObjectName= {ObjectName}  and parameter and UserId = {UserId}", typeof(T).Name, GetUserId());
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
                _logger.LogError(EventId.Error, ex, "(Data Error) User Run GetAllVm ObjectName= {ObjectName} and UserId = {UserId}", typeof(T).Name, GetUserId());
                return obj;
            }
        }

        public IEnumerable<T> GetPaging(int page, int pageSize)
        {
           
            int skipRows = (page - 1) * pageSize;
            var obj = cnnsql.Query<T>($"Select * FROM {typeof(T).Name}").Skip(skipRows).Take(pageSize).ToList();
            return obj;
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
            try
            {
                _ctx.Add(Obj);
                _ctx.SaveChanges();
                return Obj;
            }
            catch (Exception e ) {
                _logger.LogError(eventId: (int)EventId.InsertId, e, "(Data Error) User Run Insert and Get Error  ObjectName= {ObjectName} and userId = {userId} and return null", typeof(T).Name, GetUserId());
                return null;
            }

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
                _logger.LogError(eventId: (int)EventId.DeleteId, e, "(Data Error) User Run Delete and Get Error  ObjectName= {ObjectName} and userId = {userId} and return False", typeof(T).Name, GetUserId());

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
                _logger.LogError(eventId: (int)EventId.UpdateId, e, "(Data Error) User Run Update and Get Error  ObjectName= {ObjectName} and userId = {userId} and return null", typeof(T).Name, GetUserId());

                return null;
            }
        
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
                _logger.LogError(eventId: (int)EventId.BulkInsertId, e, "(Data Error) User Run BulkInsert and Get Error  ObjectName= {ObjectName} and userId = {userId} and return false", typeof(T).Name, GetUserId());
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
                _logger.LogError(eventId: (int)EventId.BulkeDelete, e, "(Data Error) User Run BulkDelete and Get Error  ObjectName= {ObjectName} and userId = {userId} and return false", typeof(T).Name, GetUserId());
                return false;
            }
        }

        public IEnumerable<T> GetAllEf()
        {
            try
            {
                return _ctx.Set<T>().ToList();

            }
            catch (Exception ex) {
                _logger.LogError(EventId.Error, ex, "(Data Error) User Run GetAllEf ObjectName= {ObjectName}  UserId = {UserId}", typeof(T).Name, GetUserId());

                return null;
            }
        }
        public IEnumerable<T> GetAllEf(Expression<Func<T, bool>> Filter)
        {
            try
            {
              
              
                var obj = _ctx.Set<T>().AsQueryable();
                if (Filter != null)
                {
                    obj = obj.Where(Filter);
                }
              

                return obj.ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError(EventId.Error, ex, "(Data Error) User Run GetAllEf ObjectName= {ObjectName} With expression and UserId = {UserId}", typeof(T).Name, GetUserId());
                                return null;
            }


        }
        private int GetUserId()
        {
            var c = _accessor.HttpContext.User.Identities;
            var a = _accessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (a == null)
            {
                return 0;
            }
            var b = Convert.ToInt32(_accessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value);
            return b;
        }
    }
}
