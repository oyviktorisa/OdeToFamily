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
    public class ListModel : PageModel
    {
        private readonly IPeopleData peopleData;

        public IEnumerable<People> People { get; set; }

        public ListModel(IPeopleData peopleData)
        {
            this.peopleData = peopleData;
        }
        public void OnGet()
        {
            People = peopleData.GetAll();
        }
    }
}