using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson.Manager
{
    public class Managers
    {
        public static Managers Instance 
        { 
            get 
            { 
                if (_instance == null)
                {
                    _instance = new Managers();
                    Init();
                }

                return _instance; 
            } 
        }

        private static Managers _instance;

        public static InIManager InI => _instance._ini;

        private InIManager _ini;

        private static void Init()
        {
            _instance._ini = new InIManager();
            _instance._ini.Init();
        }
    }
}
