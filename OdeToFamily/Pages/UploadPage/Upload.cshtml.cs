using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OdeToFamily.Core;
using OdeToFamily.Data;

namespace OdeToFamily.Pages.UploadPage
{
    public class UploadModel : PageModel
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IPeopleData peopleData;

        [BindProperty]
        public List<People> PeopleList { get; set; }

        public UploadModel(IHostingEnvironment hostingEnvironment,
                           IPeopleData peopleData)
        {
            _hostingEnvironment = hostingEnvironment;
            this.peopleData = peopleData;
        }

        public void OnGet()
        {
            PeopleList = new List<People>();
        }
        public IActionResult OnPostUpload()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        People peopleObj = new People();
                        peopleObj.Name = row.GetCell(0).ToString();
                        peopleObj.NIK = row.GetCell(1).ToString();
                        peopleObj.Gender = (GenderType) Enum.Parse(typeof(GenderType), row.GetCell(2).ToString());
                        PeopleList.Add(peopleObj);
                    }
                }
            }

            var model = new UploadModel(_hostingEnvironment, peopleData);
            model.PeopleList = PeopleList;

            return PartialView("_Preview", model);
        }

        public IActionResult OnPostSave()
        {
            foreach(var people in PeopleList)
            {
                peopleData.AddPeople(people);
            }
            peopleData.Commit();
            return RedirectToPage("../PeoplePage/List");
        }

        [NonAction]
        public virtual PartialViewResult PartialView(string viewName, object model)
        {
            ViewData.Model = model;

            return new PartialViewResult()
            {
                ViewName = viewName,
                ViewData = ViewData,
                TempData = TempData
            };
        }
    }
}