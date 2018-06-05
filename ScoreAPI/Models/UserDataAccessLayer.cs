using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace ScoreAPI.Models    
{    
    public class UserDataAccessLayer    
    {    
        string connectionString=
        @"Data Source=WIN-P0SSMM7BKA\SQLEXPRESS;Initial Catalog=ProfilingSystem;Integrated Security=True;Pooling=False";    
    
        //To View all  details      
        public IEnumerable<User> GetAllUsers()    
        {    
            List<User> lstemployee = new List<User>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllUsers", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    User employee = new User();    
                    employee.UserId = Convert.ToInt32(rdr["UserId"]);    
                    employee.Name = rdr["Name"].ToString();    
                    employee.Answer1 = Convert.ToInt32(rdr["Answer1"]);     
                    employee.Answer2 = Convert.ToInt32(rdr["Answer2"]);   
                    lstemployee.Add(employee);    
                }    
                con.Close();    
            }    
            return lstemployee;    
        }    
    
        //To Add new  record      
        public void AddUser(User employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddUserInfo", con);    
                cmd.CommandType = CommandType.StoredProcedure;    

                cmd.Parameters.AddWithValue("@Name", employee.Name);    
                cmd.Parameters.AddWithValue("@ans1", employee.Answer1);    
                cmd.Parameters.AddWithValue("@ans2", employee.Answer2);       
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
 
        public User GetUserData(int? id)    
        {    
            User employee = new User();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM tblUser WHERE UserId= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {       
                    employee.UserId = Convert.ToInt32(rdr["UserId"]);    
                    employee.Name = rdr["Name"].ToString();    
                    employee.Answer1 = Convert.ToInt32(rdr["Answer1"]);     
                    employee.Answer2 = Convert.ToInt32(rdr["Answer2"]);  
                    employee.Score = rdr["Score"].ToString();   
                }    
            }    
            return employee;    
        }    
    
        
    }    
} 