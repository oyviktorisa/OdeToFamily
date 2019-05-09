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
        private readonly IPeopleData PeopleData;

        public People PeopleEntity { get; set; }
        public IEnumerable<Relations> RelationsList { get; set; }

        public DetailModel(IPeopleData peopleData)
        {
            this.PeopleData = peopleData;
        }
        public void OnGet(int peopleId)
        {
            PeopleEntity = PeopleData.GetById(peopleId);
        }
    }
}