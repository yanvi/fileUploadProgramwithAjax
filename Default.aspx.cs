using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        public enum Role
        {
            Admin =1 , User=0
        }
        public Role role;
        protected void Page_Load(object sender, EventArgs e)
        {
            role = Role.Admin;
        }

        [WebMethod]
        public static string UploadFile()
        {
            return string.Empty;
        }
    }
}