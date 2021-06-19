/***********************************************************************************
Copyright (C) 
***********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace SMS.Net.DataBaseLayer
{
    public class DbOperations
    {
        public static bool IsServerAvailable()
        {
            try
            {   
                using (var con = new SqlConnection(DBConnection.connectionString()))
                {
                    con.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
               //
            }
            return false;
        }

        private static SqlConnection connection()
        {
            try
            {
                SqlConnection con = new SqlConnection(DBConnection.connectionString());
                con.Open();
                return con;
            }
            catch( SqlException)
            {
            }
            return null;
      
        }

        public static DataView GetDataView(SqlCommand cmd)
        {
            if (cmd != null)
            {
                try
                {
                    using (DataView dataView = new DataView(GetDataTable(cmd)))
                    {
                        return dataView;
                    }
                }
                catch (SqlException ex)
                {
                    return null;
                }
            }

            return null;
        }

        public static int ExecProc(string QueryOrProc, SqlParameter[] param, bool IsProc)
        {
            using(SqlConnection con = connection())
            {
                //using(SqlTransaction tran=con.BeginTransaction())
                //{
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = QueryOrProc;
                        if (IsProc)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                        }
                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }
                        try
                        {
                            return cmd.ExecuteNonQuery();//for insert/update/delete

                        }

                        catch(Exception )
                        {
                            //tran.Rollback();
                            throw;
                        }
                        //tran.Commit(); 
                    //}
                
                }
             
            }
          

        }
        public static int ExecProc(SqlCommand cmd)
        {
            if (cmd != null)
            {


                using (SqlConnection con = connection())
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    return 1;
                  
                }
            }

            return 0;
        }

        //public static Common.Staff.Staffs AddStaff(string QueryOrProc,SqlParameter[] param,bool IsProc)
        //{
        //    using(SqlConnection con=connection())
        //    {
        //        //using(SqlTransaction tran=con.BeginTransaction())
        //        //{
        //        using (SqlCommand cmd = con.CreateCommand())
        //        {
        //            cmd.CommandText = QueryOrProc;
        //            if (IsProc)
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //            }
        //            if (param != null)
        //            {
        //                cmd.Parameters.AddRange(param);
        //            }
        //            try
        //            {
        //                return cmd.ExecuteNonQuery();//for insert/update/delete

        //            }

        //            catch (Exception)
        //            {
        //                //tran.Rollback();
        //                throw;
        //            }
        //            //tran.Commit(); 
        //            //}

        //        }

        //    }
          

        //}
        public static SqlDataAdapter GetDataAdapter(SqlCommand cmd)
        {   
            if(cmd!=null)
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                return sda;
            }
           return null;
           
        }

        private static DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            return ds;
        }

        public static DataTable GetDataTable(string QueryOrProc, SqlParameter[] param, bool IsProc)
        {



            try
            {

                DataTable dt = null;
                SqlConnection con = connection();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = QueryOrProc;
                    if (IsProc)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                    }
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter da = GetDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                    }

                    return dt;
                }

            }
            catch(SqlException ex)
            {
                ex.GetBaseException();
                return null;
            }
        }

        public static DataTable GetDataTable(SqlCommand cmd)
        {
            if (cmd != null)
            {
                
                
                using (SqlConnection con=connection())
                {
                    cmd.Connection =con;
                    using (SqlDataAdapter sda= GetDataAdapter(cmd))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            try
                            {
                                dataTable.Locale = CultureInfo.InvariantCulture;
                                sda.Fill(dataTable);
                                return dataTable;
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                }
            }

            return null;
        }


        public static DataSet GetDataSet(string QueryOrProc,SqlParameter[] param,bool IsProc)
        {
            SqlConnection con = connection();
            using(SqlCommand cmd=con.CreateCommand())
            {
                cmd.CommandText = QueryOrProc;
                if(IsProc)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                if(param!=null)
                {
                    cmd.Parameters.AddRange(param);
                }
                using(SqlDataAdapter sda=GetDataAdapter(cmd))
                {
                    using(DataSet ds=GetDataSet())
                    {
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }
        
        public static SqlDataReader GetDataReader(string QueryOrProc,SqlParameter[] param,bool IsProc)
        {
            SqlConnection con = connection();//new SqlConnection(DBConnection.connectionString());
            using(SqlCommand cmd=con.CreateCommand())
            {
                    cmd.CommandText = QueryOrProc;
                    if (IsProc)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //sdr.Read();
                    return sdr;
             
              
            }
        }

        public static object GetScalarValue(string QueryOrProc,SqlParameter[] param,bool IsProc)
        {
            SqlConnection con = connection();
            using (SqlCommand cmd = con.CreateCommand())
            {
                //con.Open();
                cmd.CommandText = QueryOrProc;
                if (IsProc)
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                }
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteScalar();

            }
        }
        public static object GetScalarValue(SqlCommand cmd)
        {
            if(cmd!=null)
            {
                using(SqlConnection con=connection())
                {
                    cmd.Connection=con;
                    cmd.ExecuteScalar();
                }
            }
            return null;
        }
        
        public static byte[] ReadFile(string spath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(spath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(spath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }


        public static global::System.Data.DataTable GetDataTabble(global::System.Data.SqlClient.SqlCommand cmd)
        {
            throw new global::System.NotImplementedException();
        }
    }
}
