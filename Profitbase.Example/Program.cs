using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper;

namespace Profitbase.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = new Api();
            var data = api.GetAllAsync("profitb5577@gmail.com", "qwerty147").Result;
        }
    }
}
