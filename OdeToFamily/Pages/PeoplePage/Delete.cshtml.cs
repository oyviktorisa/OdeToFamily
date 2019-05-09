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
    public class DeleteModel : PageModel
    {
        private readonly IPeopleData peopleData;

        public People PeopleEntity { get; set; }

        public DeleteModel(IPeopleData peopleData)
        {
            this.peopleData = peopleData;
        }
        public IActionResult OnGet(int peopleId)
        {
            PeopleEntity = peopleData.GetById(peopleId);
            return Page();
        }

        public IActionResult OnPost(int peopleId)
        {
            peopleData.DeletePeople(peopleId);
            peopleData.Commit();
            return RedirectToPage("./List");
        }
    }
}