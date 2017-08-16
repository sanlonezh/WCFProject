using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZM.Model;

namespace ZM.DAL
{
    public class BaseDAL<T> where T : class ,new()
    {
        StudentDBEntities db = new StudentDBEntities();

        #region Select
        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="paramss"></param>
        /// <returns></returns>
        public List<T> GetEntitysByWhere(string where, params object[] paramss)
        {
            string sql = "";
            string tableName = typeof(T).Name;//获取表名
            sql = string.Format("select * from [{0}]", tableName);
            sql = sql + " where 1=1 " + where;
            if (paramss == null)
            {
                paramss = new object[1];
            }
            var temp = db.Database.SqlQuery<T>(sql, paramss).ToList<T>();
            return temp;
        }
        #endregion

        #region Add
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="entiry"></param>
        /// <returns></returns>
        public T AddEntity(T entiry)
        {
            StudentDBEntities db = new StudentDBEntities();
            db.Entry<T>(entiry).State = EntityState.Added;
            db.SaveChanges();
            return entiry;
        }
        #endregion

        #region Modify
        public bool UpdateEntitys(List<T> entitys)
        {
            StudentDBEntities db = new StudentDBEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in entitys)
            {
                db.Set<T>().Attach(item);
                db.Entry<T>(item).State = EntityState.Modified;
            }
            try
            {
                return db.SaveChanges() > 0;
            }
            finally
            {
                db.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        #endregion

        #region Delete
        public bool DeleteEntity(T enrity)
        {
            db.Set<T>().Attach(enrity);
            db.Entry<T>(enrity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }
        public bool DeleteEntitys(List<T> entirys)
        {
            StudentDBEntities db = new StudentDBEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in entirys)
            {
                db.Set<T>().Attach(item);
                db.Entry<T>(item).State = EntityState.Deleted;
            }
            try
            {
                return db.SaveChanges() > 0;
            }
            finally
            {
                db.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public int GetUnion()
        {
            StudentDBEntities db = new StudentDBEntities();
            return 0;
        }
        #endregion
    }
}
