using OdeToFamily.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFamily.Data
{
    public interface IRelationsData
    {
        IEnumerable<Relations> GetAll();
        Relations GetById(int id);
        IEnumerable<Relations> GetByPeopleId(int peopleId);
        Relations AddRelation(Relations relation);
        Relations UpdateRelation(Relations relation);
        Relations DeleteRelation(int id);
        int Commit();
    }
}
