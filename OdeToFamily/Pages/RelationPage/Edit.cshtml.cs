using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFamily.Core;
using OdeToFamily.Data;

namespace OdeToFamily.Pages.RelationPage
{
    public class EditModel : PageModel
    {
        private readonly IRelationsData relationsData;
        private readonly IPeopleData peopleData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty(SupportsGet =true)]
        public Relations RelationEntity { get; set; }
        public IEnumerable<SelectListItem> RelationTypes { get; set; }

        public EditModel(IRelationsData relationsData,
                         IPeopleData peopleData,
                         IHtmlHelper htmlHelper)
        {
            this.relationsData = relationsData;
            this.peopleData = peopleData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int peopleId)
        {
            RelationTypes = htmlHelper.GetEnumSelectList<RelationType>();
            RelationEntity = new Relations();
            RelationEntity.PeopleId = peopleId;
            return Page();
        }

        public IActionResult OnPost()
        {
            RelationTypes = htmlHelper.GetEnumSelectList<RelationType>();
            if (ModelState.IsValid)
            {
                relationsData.AddRelation(RelationEntity);
                relationsData.Commit();
                return RedirectToPage("../PeoplePage/Detail", new { peopleId = RelationEntity.PeopleId});
            }
            return Page();
        }
    }
}