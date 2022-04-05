using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XION_Aufgabe.Models;

namespace XION_Aufgabe
{
    public interface IPatientResult
    {
        event EventHandler<ResultEventArgs<Patient>> GetResult;
        Action<Patient> GetPatient { get; set; }
    }
}
