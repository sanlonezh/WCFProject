using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZM.DAL;

namespace ZM.BLL
{
   public  abstract class BaseBLL<T> where T: class,new()
    {
       protected BaseDAL<T> dal = null;
       public BaseBLL()
       { SetDAL();}
       /// <summary>
       /// 必须重载的抽象方法，用来实例化 idal
       /// </summary>
       public abstract void SetDAL();
        #region Add
       /// <summary>
       ///增加一条实体数据 
       /// </summary>
       /// <param name="enrity"></param>
       /// <returns></returns>
       public T AddEntity(T enrity)
       {
           return dal.AddEntity(enrity);
       }
   
        #endregion

        #region Select
       public List<T> GetEntitysByWhere(string where, params object[] obj)
       {
           return dal.GetEntitysByWhere(where, obj);
       }
        #endregion

        #region Modify
       public bool UpdateEntitys(List<T> entitys)
       {
           return dal.UpdateEntitys(entitys);
       }
        #endregion

        #region Delete
       public bool DeleteEntity(T entity)
       {
           return dal.DeleteEntity(entity);
       }
       public bool DeleteEntitys(List<T> entitys)
       {
           return dal.DeleteEntitys(entitys);
       }
        #endregion
    }

}
