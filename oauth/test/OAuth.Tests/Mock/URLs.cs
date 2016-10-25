using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHubApi.Sdk.OAuth.Tests.Mock
{
    public static class URLs
    {
        public static string REPONSE_OK 
        { 
            get 
            { 
                return "Http://ok.com"; 
            } 
        }

        public static string REPONSE_UNATHORIZED_FIRST_TIME
        { 
            get 
            { 
                return "Http://unathorized1.com"; 
            } 
        } 
    }
}
