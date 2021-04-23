using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceMonitoring.Models
{
    public class Employee
    {
        dbcontrol s = new dbcontrol();
        public int      ID          { get; set; }
        public string   EmpID       { get; set; }
        public string   Fname       { get; set; }
        public string   Mname       { get; set; }
        public string   Lname       { get; set; }
        public string   Department  { get; set; }
        public string   Position    { get; set; }

        public Employee()
        {

        }

        public Employee(int ID, string EmpID, string Fname, string Mname, string Lname, string Department, string Position)
        {
            this.ID = ID;
            this.EmpID = EmpID;
            this.Fname = Fname;
            this.Mname = Mname;
            this.Lname = Lname;
            this.Department = Department;
            this.Position = Position;
        }

        public Employee(string EmpID, string Fname, string Mname, string Lname, string Department, string Position)
        {
            this.EmpID = EmpID;
            this.Fname = Fname;
            this.Mname = Mname;
            this.Lname = Lname;
            this.Department = Department;
            this.Position = Position;
        }

        public Employee(DataRow r)
        {
            this.ID = (int)r["ID"];
            this.EmpID = r["EmpID"].ToString();
            this.Fname = r["Fname"].ToString();
            this.Mname = r["Mname"].ToString();
            this.Lname = r["Lname"].ToString();
            this.Department = r["Department"].ToString();
            this.Position = r["Position"].ToString();
        }

        public Employee FindEmployee(string EmpID)
        {
            var emp = new Employee();
            s.Query("select * from tbl_employee where EmpID = @EmpID", p => p.Add("@EmpID", EmpID)).ForEach(r =>
            {
                emp = new Employee(r);
            });
            return emp;
        }
    }
}