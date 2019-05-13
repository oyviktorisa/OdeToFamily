using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFamily.Core;

namespace OdeToFamily.Data
{
    public class SqlRelationsData : IRelationsData
    {
        private readonly OdeToFamilyDbContext dbContext;

        public SqlRelationsData(OdeToFamilyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Relations AddRelation(Relations relation)
        {
            dbContext.Add(relation);
            return relation;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Relations DeleteRelation(int id)
        {
            var relation = GetById(id);
            if(relation != null)
            {
                dbContext.Remove(relation);
            }
            return relation;
        }

        public IEnumerable<Relations> GetAll()
        {
            var query = from r in dbContext.Relations
                        orderby r.Id
                        select r;

            return query;
        }

        public Relations GetById(int id)
        {
            return dbContext.Relations.Find(id);
        }

        public IEnumerable<Relations> GetByPeopleId(int peopleId)
        {
            var query = from r in dbContext.Relations
                        where r.PeopleId == peopleId || r.PeopleRelateToId == peopleId
                        select r;

            return query;
        }

        public Relations UpdateRelation(Relations relation)
        {
            var entity = dbContext.Attach(relation);
            entity.State = EntityState.Modified;

            return relation;
        }
    }
}
