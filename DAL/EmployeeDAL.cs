using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment.DAL
{
    public class EmployeeDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["conau"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {

            List<Employee> empList = new List<Employee>();


            //SqlConnection con = new SqlConnection(cs);
            //String query = "select * from tblEmployee";
            //SqlDataAdapter adp = new SqlDataAdapter("spGetAllEmployees", con);
            //adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlConnection con = new SqlConnection(cs);
            String query = "select *,tblDepartment.DeptName from tblEmployee inner join tblDepartment on tblEmployee.Department = tblDepartment.DID";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(row[0].ToString());
                emp.FirstName = row[1].ToString();
                emp.LastName = row[2].ToString();
                emp.Designation = row[3].ToString();
                emp.Department = Convert.ToInt32(row[4].ToString());
                emp.Knowledge = row[5].ToString();
                emp.Salary = Convert.ToDecimal(row[6].ToString());
                emp.JoinDate = row[7].ToString();  //Convert.ToDateTime(row[7].ToString());
                emp.Report_person = row[8].ToString();
                emp.joindept = row["DeptName"].ToString();
                
                empList.Add(emp);

            }

            con.Close();

            return empList;
        }


        public bool AddEmployee(Employee p)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "insert into tblEmployee values(@fname,@lname,@designation,@department,@knowledge,@salary,@joindate,@reportperson)";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", p.FirstName);
            cmd.Parameters.AddWithValue("@lname", p.LastName);
            cmd.Parameters.AddWithValue("@designation", p.Designation);
            cmd.Parameters.AddWithValue("@department", p.Department);
            cmd.Parameters.AddWithValue("@knowledge", p.Knowledge);
            cmd.Parameters.AddWithValue("@salary", p.Salary);
            cmd.Parameters.AddWithValue("@joindate", p.JoinDate);
            cmd.Parameters.AddWithValue("@reportperson", p.Report_person);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
                return true;
            else
                return false;
        }



        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "delete from tblEmployee where EmployeeID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
                return true;
            else
                return false;
        }



        public bool UpdateEmployee(Employee p)
        {
            SqlConnection con = new SqlConnection(cs);
            String upt_query = "update tblEmployee set FirstName = @firstname, LastName = @lastname, Designation = @designation, Department = @department, Knowledge = @knowledge, Salary = @salary, JoinDate = @joindate, Report_person = @reportperson where EmployeeID = @id";
            SqlCommand cmd = new SqlCommand(upt_query, con);
           // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", p.EmployeeID);
            cmd.Parameters.AddWithValue("@firstname", p.FirstName);
            cmd.Parameters.AddWithValue("@lastname", p.LastName);
            cmd.Parameters.AddWithValue("@designation", p.Designation);
            cmd.Parameters.AddWithValue("@department", p.Department);
            cmd.Parameters.AddWithValue("@knowledge", p.Knowledge);
            cmd.Parameters.AddWithValue("@salary", p.Salary);
            cmd.Parameters.AddWithValue("@joindate", p.JoinDate);
            cmd.Parameters.AddWithValue("@reportperson", p.Report_person);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
                return true;
            else
                return false;
        }



        public List<Department> GetDepartmentList()
        {

            List<Department> deptlist = new List<Department>();

            SqlConnection con = new SqlConnection(cs);
            String query = "select * from tblDepartment";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adp.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Department d = new Department();
                d.DID = Convert.ToInt32(row[0].ToString());
                d.DeptName = row[1].ToString();

                deptlist.Add(d);

            }

            con.Close();

            return deptlist;

        }


        public List<Employee> GetEmployeeList()
        {

            List<Employee> emplist = new List<Employee>();

            SqlConnection con = new SqlConnection(cs);
            String query = "select * from tblEmployee";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adp.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee d = new Employee();
               d.EmployeeID = Convert.ToInt32(row[0].ToString());
                d.FirstName = row[1].ToString();

                emplist.Add(d);

            }

            con.Close();

            return emplist;

        }
    }
}