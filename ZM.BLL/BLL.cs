
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ZM.Model;
using ZM.DAL;
using IMS.DAL;

namespace  ZM.BLL
{
	public partial class GradeBLL : BaseBLL<Grade>
    {
	    private  GradeDAL  gradeDAL = null;
	    public override void SetDAL()
        {
           dal = DBSession.GradeDAL;   
           gradeDAL = dal as GradeDAL; 
        }
		public Grade AddGrade(Grade _Grade)
        {
            return AddEntity(_Grade);
        }
		public List<Grade> GetGradeByWhere(string where,params object[] paramss)
        {
            return GetEntitysByWhere(where,paramss);
        }
		public bool DeleteGrade(Grade Grade)
		{
		return DeleteEntity(Grade);
		}
		public bool DeleteGrades(List<Grade> Grades)
		{
		return DeleteEntitys(Grades);
		}
		public bool UpdateGrades(List<Grade> Grades)
		{
		return UpdateEntitys(Grades);
		}
    }

	public partial class UserBLL : BaseBLL<User>
    {
	    private  UserDAL  userDAL = null;
	    public override void SetDAL()
        {
           dal = DBSession.UserDAL;   
           userDAL = dal as UserDAL; 
        }
		public User AddUser(User _User)
        {
            return AddEntity(_User);
        }
		public List<User> GetUserByWhere(string where,params object[] paramss)
        {
            return GetEntitysByWhere(where,paramss);
        }
		public bool DeleteUser(User User)
		{
		return DeleteEntity(User);
		}
		public bool DeleteUsers(List<User> Users)
		{
		return DeleteEntitys(Users);
		}
		public bool UpdateUsers(List<User> Users)
		{
		return UpdateEntitys(Users);
		}
    }


}