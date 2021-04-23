using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AttendanceMonitoring.Models
{
    public class Attendance
    {
        dbcontrol s = new dbcontrol();
        public int      ID		 { get; set; }
        public string   AttDate	 { get; set; }
        public string   EmpID	 { get; set; }
        public string   ATime	 { get; set; }

        public Attendance()
        {

        }

        public Attendance(int ID, string AttDate, string EmpID, string ATime)
        {
            this.ID         = ID		;
            this.AttDate    = AttDate	;
            this.EmpID      = EmpID	    ;
            this.ATime      = ATime     ;
        }

        public Attendance(string AttDate, string EmpID, string ATime)
        {
            this.AttDate = AttDate;
            this.EmpID = EmpID;
            this.ATime = ATime;
        }

        public Attendance(DataRow r)
        {
            ID         = (int)r["ID      "]  ;
            AttDate    = r["AttDate "].ToString()  ;
            EmpID      = r["EmpID   "].ToString()  ;
            ATime      = r["ATime   "].ToString()  ;
        }

        public List<Attendance> ListAttendance(string EmpID = "")
        {
            var list = new List<Attendance>();
            s.Query("select * from tbl_attendance where EmpID like @search", p => p.Add("@search", $"%{EmpID}%")).ForEach(r =>
            {
                list.Add(new Attendance(r));
            });
            return list;
        }

        public void AddAttendance(Attendance att)
        {
            s.Insert("tbl_Attendance", p =>
            {
                p.Add("AttDate", DateTime.Parse(att.AttDate));
                p.Add("EmpID", att.EmpID);
                p.Add("ATime", att.ATime);
            });
        }
    }
}