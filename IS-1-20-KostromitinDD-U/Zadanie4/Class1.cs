﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadanie4
{
    public class Connection
    {
        //public string host = "10.90.12.110";// делал это в чюки поэтому и две строки подключения 
        public string host = "chuc.caseum.ru";
        public string port = "33333";
        public string user = "st_1_20_17";
        public string data = "is_1_20_st17_KURS";
        public string passwprd = "32424167";
        public string connStr;
        public string con()// строка подключения
        {
            return connStr = $"server={host};port={port};user={user};database={data};password={passwprd};";
        }
    }

}
