using Microsoft.AspNetCore.Mvc;
using Calendar.Framework;
using Calendar.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : CoreController
    {
        #region constructor
        public HomeController(Config config) : base(config)
        {
        }
        #endregion

        public bool Index()
        {
            string connectionstring = Config.DBConnection.SQLConnection;

            base.SetSessionString("User", "Excel soft");
            base.SetSessionInt("UserCount", 20);
            base.SetSession<DBConnection>("Connection", Config.DBConnection);

            return true;
        }


    }
}
