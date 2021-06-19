/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Net.BusinessLayer.user
{
   public class users
    {
       public static int CreateUser(Common.user.UsersInfo u,Common.Staff.Roles role)
       {

           SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RoleId",role.RoleId),
                new SqlParameter("@UserName",u.UserName),
                new SqlParameter("@Password",u.Password),
                new SqlParameter("@RetypePassword",role.RetypePassword)
                //new SqlParameter("@Picture",student.Picture)

            };
           return DataBaseLayer.DbOperations.ExecProc("[user].[spCreateUser]", param, true);

       }

       public static List<Common.user.UsersInfo> GetSystemUsers()
       {
           List<Common.user.UsersInfo> listSystemUsers = new List<Common.user.UsersInfo>();
           DataTable dt=DataBaseLayer.DbOperations.GetDataTable("[user].spSysteUsers", null, true);
           foreach(DataRow dr in dt.Rows)
           {
               Common.user.UsersInfo ui = new Common.user.UsersInfo();
               ui.UserId = int.Parse(dr["UserId"].ToString());
               ui.RoleId = int.Parse(dr["RoleId"].ToString());
               ui.UserName = dr["UserName"].ToString();
               ui.RoleName = dr["RoleName"].ToString();
               ui.Password =dr["Password"].ToString();
               ui.Status = dr["Status"].ToString();
               listSystemUsers.Add(ui);
           }
           return listSystemUsers;
           
       }
    }
}
