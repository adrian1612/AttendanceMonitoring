using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAJdbController;
using System.Configuration;

namespace AttendanceMonitoring
{
    public class dbcontrol : AAJControl
    {
        public dbcontrol() : base(DatabaseType.SQLServer, ConfigurationManager.ConnectionStrings["AttM"].ConnectionString)
        {

        }
    }
}