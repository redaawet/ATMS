using System;
using System.Collections.Generic;
using System.Text;
using ATMSData.Models;

namespace ATMSData
{
    public interface IAccidentRecord
    {
        IEnumerable<AccidentRecord> GetAll();
        AccidentRecord GetByID(String RID);
        void Add(AccidentRecord Record);
        String GetCity(String RID);
        String GetSubCity(String RID);
        String Getlatitude(String RID);
        String Getlongitude(String RID);

    }
}
