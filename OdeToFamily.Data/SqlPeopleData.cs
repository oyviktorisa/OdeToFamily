using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFamily.Core;

namespace OdeToFamily.Data
{
    public class SqlPeopleData : IPeopleData
    {
        private readonly OdeToFamilyDbContext dbContext;

        public SqlPeopleData(OdeToFamilyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public People AddPeople(People people)
        {
            dbContext.Add(people);
            return people;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public People DeletePeople(int id)
        {
            var people = GetById(id);
            if(people != null)
            {
                dbContext.Remove(people);
            }
            return people;
        }

        public IEnumerable<People> GetAll()
        {
            var query = from p in dbContext.People
                        orderby p.Name
                        select p;

            return query;
        }

        public People GetById(int id)
        {
            return dbContext.People.Find(id);
        }

        public People UpdatePeople(People people)
        {
            var entity = dbContext.Attach(people);
            entity.State = EntityState.Modified;

            return people;
        }
    }
}
