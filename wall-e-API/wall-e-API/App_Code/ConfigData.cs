using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace wall_e_API
{
    public static class ConfigData
    {
        private static string[] _serverMode = new string[] { "dev", "qas", "prd" };
        public static string ConnectionString()
        {
            string _dbName = "";
            switch (serverMode())
            {
                case "prd":
                    _dbName = "Wall-E_DB_PRD";
                    break;
                case "qas":
                    _dbName = "Wall-E_DB_QAS";
                    break;
                case "dev":
                    _dbName = "Wall-E_DB_DEV";
                    break;
            }
            var conn = ConfigurationManager.ConnectionStrings[_dbName].ConnectionString;
            return conn;
        }
        public static string serverNameTmp { set; get; }
        public static string serverName
        {
            get
            {
                try
                {
                    string _serverName = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
                    serverNameTmp = _serverName;
                    return _serverName;
                }
                catch
                {
                    return serverNameTmp;
                }
            }
        }

        public static string serverMode()
        {

            switch (serverName)
            {
                case "flextime.mahidol.ac.th": //prd
                    return _serverMode[2];
                case "flextime-qas.mahidol": //qas
                    return _serverMode[1];
                default:
                    return _serverMode[0]; //dev
            }
        }


    }
}