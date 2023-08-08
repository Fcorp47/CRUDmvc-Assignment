using Assignment.DAL;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["conau"].ConnectionString;
        
        EmployeeDAL db = new EmployeeDAL();

        public ActionResult Index()
        {
         
         
                EmployeeDAL db = new EmployeeDAL();
                List<Employee> obj = db.GetAllEmployees();
                return View(obj);
   
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            

            EmployeeDAL db = new EmployeeDAL();

            List<Employee> mylist = null;
            if (search != null)
            {
                 mylist = db.GetAllEmployees().Where(x => x.FirstName.Contains(search)).ToList();

                if (mylist.Count() == 0)
                {

                    TempData["records"] = "No records found";

                }
            }
           
            


            return View(mylist);
          
            
        }

        public void GetSearchEmployees()
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "select * from tblEmployee where FirstName = @firstname";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

        }

        public List<Employee> GetEmployee()
        {
            
            List<Employee> obj = db.GetAllEmployees();
            return obj;
        }


         public ActionResult Create()
        {

            EmployeeDAL objdal = new EmployeeDAL();
            Department d = new Department();
           ViewBag.Model = new SelectList(objdal.GetDepartmentList(), "DID", "DeptName"); // model binding
            Employee e = new Employee();
           ViewBag.EModel = new SelectList(objdal.GetEmployeeList(), "FirstName", "FirstName"); // model binding


            return View();

           
        }

        [HttpPost]  //this method should run when my request is post
        public ActionResult Create(Employee p)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                   

                    EmployeeDAL objdal = new EmployeeDAL();
                    bool check = objdal.AddEmployee(p);

                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Employee has been Inserted";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }

                return View();
            }
            catch
            {
                return View();
            }


        }




        public ActionResult Edit(int id)
        {
            EmployeeDAL objdal = new EmployeeDAL();
            Department d = new Department();
            ViewBag.Model = new SelectList(objdal.GetDepartmentList(), "DID", "DeptName"); // model binding
            Employee e = new Employee();
            ViewBag.EModel = new SelectList(objdal.GetEmployeeList(), "FirstName", "FirstName"); // model binding


            var row = objdal.GetAllEmployees().Find(model => model.EmployeeID == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid == true)
            {

                EmployeeDAL objdal = new EmployeeDAL();
                bool check = objdal.UpdateEmployee(emp);

                if (check == true)
                {
                    TempData["UpdateMessage"] = "Employee record has been Updated";
                    ModelState.Clear();
                    return RedirectToAction("Index"); 
                }

            }
            return View();
        }



        public ActionResult Delete(int id)
        {
            EmployeeDAL objdal = new EmployeeDAL();
            var row = objdal.GetAllEmployees().Find(model => model.EmployeeID == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee p)
        {
            EmployeeDAL objdal = new EmployeeDAL();
            bool check = objdal.DeleteEmployee(id);

            if (check == true)
            {
                TempData["DeleteMessage"] = "Employee has been Deleted";
                ModelState.Clear();
                return RedirectToAction("Index"); //after update, redirect to Index action method in controller
            }
            return View();
        }


    }
}