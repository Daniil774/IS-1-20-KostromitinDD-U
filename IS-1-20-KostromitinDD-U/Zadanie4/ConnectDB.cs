using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    internal class ConnectDB
    {
    }
    public class Connection
    {
        //public string host = "10.90.12.110"; 
        public string Host = "chuc.caseum.ru";
        public string Port = "33333";
        public string User = "st_1_20_17";
        public string Data = "is_1_20_st17_KURS";
        public string Password = "32424167";
        public string ConnStr;
        public string connect()// строка подключения
        {
            return ConnStr = $"server={Host};port={Port};user={User};database={Data};password={Password};";
        }
    }
}
