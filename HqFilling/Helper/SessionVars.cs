using System.Web;
using HqFilling.Model;

namespace HqFilling.Helper
{
    public static class SessionVars
    {
        public static UserModel CurrentLoggedInUser
        {
            get
            {
                return HttpContext.Current.Session["CurrentLoggedInUser"] as UserModel;
            }
            set
            {
                HttpContext.Current.Session["CurrentLoggedInUser"] = value;
            }
        }
    }
}