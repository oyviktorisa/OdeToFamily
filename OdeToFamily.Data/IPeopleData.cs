using OdeToFamily.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFamily.Data
{
    public interface IPeopleData
    {
        IEnumerable<People> GetAll();
        People GetById(int id);
        People AddPeople(People people);
        People UpdatePeople(People people);
        People DeletePeople(int id);
        int Commit();
    }
}
