using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFamily.Core;
using OdeToFamily.Data;

namespace OdeToFamily.Pages.PeoplePage
{
    public class DetailModel : PageModel
    {
        private readonly IPeopleData peopleData;
        private readonly IRelationsData relationsData;

        public People PeopleEntity { get; set; }
        public IEnumerable<Relations> RelationsList { get; set; }

        public DetailModel(IPeopleData peopleData,
                           IRelationsData relationsData)
        {
            this.peopleData = peopleData;
            this.relationsData = relationsData;
        }
        public void OnGet(int peopleId)
        {
            PeopleEntity = peopleData.GetById(peopleId);
            RelationsList = relationsData.GetByPeopleId(peopleId);

            foreach(var relations in RelationsList)
            {
                relations.People = peopleData.GetById(relations.PeopleId);
                relations.PeopleRelateTo = peopleData.GetById(relations.PeopleRelateToId);
            }
        }
    }
}