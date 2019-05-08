﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFamily.Core;
using OdeToFamily.Data;

namespace OdeToFamily.Pages.PeoplePage
{
    public class EditModel : PageModel
    {
        private readonly IPeopleData peopleData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public People PeopleEntity { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }

        public EditModel(IPeopleData peopleData,
                         IHtmlHelper htmlHelper)
        {
            this.peopleData = peopleData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? peopleId)
        {
            Genders = htmlHelper.GetEnumSelectList<GenderType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            Genders = htmlHelper.GetEnumSelectList<GenderType>();
            if (ModelState.IsValid)
            {
                peopleData.AddPeople(PeopleEntity);
                peopleData.Commit();
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}