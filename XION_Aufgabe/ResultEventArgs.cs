using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XION_Aufgabe.Models;

namespace XION_Aufgabe
{
    public class ResultEventArgs<T> : EventArgs
    {
        public T Result;
        public ResultEventArgs(T result)
        {
            Result = result;
        }
    }
}
