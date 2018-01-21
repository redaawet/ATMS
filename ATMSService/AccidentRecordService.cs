using System;
using System.Linq;
using System.Collections.Generic;
using ATMSData;
using ATMSData.Models;
using Microsoft.EntityFrameworkCore;
namespace ATMSService
{
    public class AccidentRecordService : IAccidentRecord

    {
        private TrafficAccidentManagementContext _Context;
        public AccidentRecordService(TrafficAccidentManagementContext AccidentContext)
        {
            _Context= AccidentContext;       }
        public AccidentRecordService()
        {
            //_Context = AccidentContext;
        }
        public void Add(AccidentRecord Record)
        {
            _Context.Add(Record);
            _Context.SaveChanges();
        }

        public IEnumerable<AccidentRecord> GetAll()
        {
            return _Context.AccidentRecords
                .Include(Accident => Accident.Occurs)
                .Include(Accident => Accident.Damages)
                .Include(Accident => Accident.CausesOn)
                .Include(Accident => Accident.Involves)
                .Include(Accident => Accident.Injures)
                .Include(Accident => Accident.FactrieAccidents);
        }

        public AccidentRecord GetByID(string RID)
        {
            return GetAll().FirstOrDefault(Accident => Accident.AccidentRecordID ==RID);
        }

        public string GetCity(string RID)
        {
            return GetByID(RID).City;
        }

        public string GetSubCity(string RID)
        {
            return GetByID(RID).City;
        }
        public string Getlatitude(string RID)
        {
            throw new NotImplementedException();
        }

        public string Getlongitude(string RID)
        {
            throw new NotImplementedException();
        }
    }
}
