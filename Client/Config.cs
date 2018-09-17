using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Client
{
    public static class Config
    {

        public static string ISAddress => ConfigurationManager.AppSettings["IS.Ip"]; 
        public static string ISPort => ConfigurationManager.AppSettings["IS.Port"];

        public static string ApiId => ConfigurationManager.AppSettings["Api.Identifier"];
        public static string ClientId => ConfigurationManager.AppSettings["Client.Identifier"];
        public static string ClientSecret => ConfigurationManager.AppSettings["Client.Secret"];
    }
}
