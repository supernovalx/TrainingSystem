using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingSystem
{
    public class Authorizer
    {
        public static bool CheckRole(string role, HttpSessionStateBase session)
        {
            return session["role"] != null && role.Split(',').Any(r => r == session["role"].ToString());
        }
    }
}