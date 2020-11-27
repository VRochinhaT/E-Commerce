using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Config : IConfig
    {
        public string StrCon { get; set; }
    }

    public interface IConfig
    {
        public string StrCon { get; set; }
    }
}
