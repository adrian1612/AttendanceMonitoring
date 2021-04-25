using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace AttendanceMonitoring.Models
{
    public class Employee
    {
        dbcontrol s = new dbcontrol();
        [Key]
        public int      ID          { get; set; }

        [Display(Name = "Employee ID")]
        [Required]
        public string   EmpID       { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string   Fname       { get; set; }

        [Display(Name = "Middle name")]
        [Required]
        public string   Mname       { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string   Lname       { get; set; }

        [Display(Name = "Department")]
        [Required]
        public string   Department  { get; set; }

        [Display(Name = "Position")]
        [Required]
        public string   Position    { get; set; }
        public string Picture { get; set; }

        [Required]
        public HttpPostedFileBase Upload { get; set; }
        public byte[] PicByte
        {
            get
            {
                var ms = new MemoryStream();
                if (Upload != null)
                {
                    Upload.InputStream.CopyTo(ms);
                }
                return ms.ToArray();
            }
        }

        public Employee()
        {

        }

        public Employee(int ID, string EmpID, string Fname, string Mname, string Lname, string Department, string Position, HttpPostedFileBase Upload)
        {
            this.ID = ID;
            this.EmpID = EmpID;
            this.Fname = Fname;
            this.Mname = Mname;
            this.Lname = Lname;
            this.Department = Department;
            this.Position = Position;
            this.Upload = Upload;
        }

        public Employee(string EmpID, string Fname, string Mname, string Lname, string Department, string Position, HttpPostedFileBase Upload)
        {
            this.EmpID          = EmpID;
            this.Fname          = Fname;
            this.Mname          = Mname;
            this.Lname          = Lname;
            this.Department     = Department;
            this.Position       = Position;
            this.Upload         = Upload;
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
            this.Picture = $"data:image/jpeg;base64,{Convert.ToBase64String((byte[])r["Picture"])}";
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

        public void Insert(Employee emp)
        {
            s.Query("INSERT INTO tbl_employee (EmpID, Fname, Mname,Lname, Department, Position, Picture) VALUES (@EmpID, @Fname, @Mname,@Lname,@Department, @Position,@Picture)", p =>
            {
                p.Add("@EmpID", emp.EmpID);
                p.Add("@Fname", emp.Fname);
                p.Add("@Mname", emp.Mname);
                p.Add("@Lname", emp.Lname);
                p.Add("@Department", emp.Department);
                p.Add("@Position", emp.Position);
                var ms = new MemoryStream();
                emp.Upload.InputStream.CopyTo(ms);
                p.Add("@Picture", ms.ToArray());
            });
        }
    }
}