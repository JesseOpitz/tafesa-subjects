using CFI_App.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;
using NUnit.Framework;

namespace CFI_Web_Application.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult ShowGrid()
        {
            return View();
        }

        public ActionResult LoadData()
        {
            //Creating instance of DatabaseContext class  
            using (DatabaseContext _context = new DatabaseContext())
            {

                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all subject data and building query 
                var subjectData = (from tempsubject in _context.Subjects
                                   join crn in _context.CRNDetail on tempsubject.CRN equals crn.CRN
                                   join subject in _context.Subject on crn.SubjectCode equals subject.SubjectCode
                                   join campus in _context.Campus on tempsubject.CampusCode equals campus.CampusCode
                                   join dow in _context.DayOfWeek on tempsubject.DayCode equals dow.DayCode
                                   join lec in _context.Lecturer on crn.LecturerID equals lec.LecturerID

                                   //Select relevant columns
                                   select new
                                   {
                                       tempsubject.CRN,
                                       subject.SubjectCode,
                                       tempsubject.Room,
                                       dow.DayLongName,
                                       tempsubject.StartTime,
                                       campus.CampusName,
                                       Name = string.Concat(lec.GivenName, " ", lec.LastName)
                                   });

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    subjectData = subjectData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {

                    subjectData = subjectData.Where(m => m.CRN.ToString().Contains(searchValue)
                        || m.SubjectCode.ToString().Contains(searchValue)
                        || m.Room.ToString().Contains(searchValue)
                        || m.DayLongName.ToString().Contains(searchValue)
                        || m.CampusName.ToString().Contains(searchValue)
                        || m.StartTime.ToString().Contains(searchValue)
                        || m.Name.ToString().Contains(searchValue));
                }

                //total number of rows count     
                recordsTotal = subjectData.Count();
                //Paging     
                var data = subjectData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data});
            }


        }

    }
}