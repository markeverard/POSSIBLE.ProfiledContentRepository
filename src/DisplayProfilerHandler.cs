﻿using System.Web;

namespace POSSIBLE.ProfiledContentRepository
{
    public delegate bool ShouldStartProfiler(HttpContextBase httpContext);
    public delegate bool ShowProfilerToAuthenticatedUser(HttpContextBase httpContext);
    
    public static class DisplayProfilerHandler
    {
        public static ShouldStartProfiler ShouldStart;
        public static ShowProfilerToAuthenticatedUser ShowToUser;
        
        public static void SetDefaultBehaviour()
        {
            ShouldStart = DefaultStartBehavior;
            ShowToUser = DefaultUserAuthenticatedBehavior;
        }

        private static bool DefaultStartBehavior(HttpContextBase httpContext)
        {
            return true;
        }

        private static bool DefaultUserAuthenticatedBehavior(HttpContextBase httpContext)
        {
            if (httpContext.User == null)
                return false;

            return httpContext.User.IsInRole("WebAdmins") || httpContext.User.IsInRole("Administrators");
        }
    }
}