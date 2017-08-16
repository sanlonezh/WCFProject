
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZM.DAL;

namespace  IMS.DAL
{
     /// <summary>
    /// 数据访问工厂
    /// </summary>
	public partial class DBSession
    {
	    private DBSession()
		{
		}
	    
		public static readonly GradeDAL GradeDAL=new GradeDAL();
	    
		public static readonly UserDAL UserDAL=new UserDAL();
    }

}