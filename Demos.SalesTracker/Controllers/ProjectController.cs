using Demos.SalesTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demos.SalesTracker.Controllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        DbContextHelper _dbContextHelper = new DbContextHelper();
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Project_Read()
        {
            var dt = _dbContext.Project.ToList();

            //   List<string>  ProjectDocuments = _dbContext.ProjectFile.Where(x=>x.ProjectId== )
            IQueryable<ProjectViewModel> pvm = _dbContext.Project.Include("Region").Include("SubRegion").Select(vm => new ProjectViewModel()
            {
                Id = vm.Id,
                Title = vm.ProjectTitle,
                ClientName = vm.ClientName,
                Created = vm.Created,
                Createdby = vm.Createdby,
                CleintIndustry = vm.ClientIndustry,
                Modified = vm.Modified,
                Modifiedby = vm.Modifiedby,
                ProjectStatus = vm.ProjectStatus,
                Region = vm.Region.Title,
                SubRegion = vm.SubRegion.Title
            });

            return Json(pvm, JsonRequestBehavior.AllowGet);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            IntializeViewdata();
            return View("ngCreate");
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project Project, int[] projectFile, int[] supportingFile)
        {
            try
            {
                try
                {
                    // TODO: Add update logic here
                    Project.Created = DateTime.Now;
                    Project.Createdby = AppSession.UserId;
                    Project.Modified = DateTime.Now;
                    Project.Modifiedby = AppSession.UserId;
                    Project.RegionId = Convert.ToInt32(Project.Region.Id);
                    Project.SubRegionId = Convert.ToInt32(Project.SubRegion.Id);
                    _dbContextHelper.AttachToContext(Project);

                    foreach (int fle in projectFile)
                    {
                        ProjectDocumentInfo pfle = new ProjectDocumentInfo();
                        pfle.ProjectId = Project.Id;
                        pfle.ProjectDocumentId = fle;
                        _dbContextHelper.AttachToContext(pfle);
                    }

                    foreach (int sfle in supportingFile)
                    {
                        SupportingDocumentInfo spfle = new SupportingDocumentInfo();
                        spfle.ProjectId = Project.Id;
                        spfle.SupportingDocumentId = sfle;
                        _dbContextHelper.AttachToContext(spfle);
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
                IntializeViewdata();
                return View("ngCreate");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateProject(int Id)
        {
            return View("UpdateProject");
        }

        public ActionResult ngCreate()
        {
            return View();
        }
        Project result;
        // GET: Project/Edit/5
        public JsonResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                result = _dbContext.Project.Where(x => x.Id == id).FirstOrDefault();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegions()
        {
            var result = _dbContext.Region.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubRegions()
        {
            var result = _dbContext.SubRegion.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSupportingDocument()
        {
            var result = _dbContext.SuportingDocument.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectDocument()
        {
            var result = _dbContext.ProjectDocument.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserInfo()
        {
            var result = _dbContext.Users.ToList();

            UserViewModel usvw = _dbContext.Users.Where(usr => usr.Id == AppSession.UserId).Select(uvm => new UserViewModel()
            {
                Id = uvm.Id,
                UserName = uvm.UserName,
                EmailId = uvm.Email,
                Designation = uvm.Designation,
                Department = uvm.Department,
                ReportingManager = _dbContext.Users.Where(usr => usr.ReportingManger.Id == uvm.Id).FirstOrDefault().UserName
            }).FirstOrDefault();
            return Json(usvw, JsonRequestBehavior.AllowGet);

        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Project Project)
        {
            try
            {
                // TODO: Add update logic here
                var result = _dbContext.Project.Where(x => x.Id == id).FirstOrDefault();
                Project.Created = result.Created;
                Project.Createdby = result.Createdby;
                _dbContextHelper.AttachToContext(Project);
                return Json(Project, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult UserInfoView()
        {
            var result = _dbContext.Users.ToList();

            UserViewModel usvw = _dbContext.Users.Where(usr => usr.Id == AppSession.UserId).Select(uvm => new UserViewModel()
            {
                Id = uvm.Id,
                UserName = uvm.UserName,
                EmailId = uvm.Email,
                Designation = uvm.Designation,
                Department = uvm.Department,
                ReportingManager = _dbContext.Users.Where(usr => usr.ReportingManger.Id == uvm.Id).FirstOrDefault().UserName
            }).FirstOrDefault();
            return PartialView("UserInfo", usvw);
        }

        public PartialViewResult ProjectDocumentsView()
        {
            IntializeViewdata();
            return PartialView("ProjectDocuments");
        }

        ProjectDocument pd; SupportingDocument spd;
        [HttpPost]
        public ActionResult SaveProjectDoc()
        {
            List<int> lstpd = new List<int>();

            string path = Server.MapPath("~/Attachments/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
                try
                {
                    pd = new ProjectDocument();
                    pd.Title = postedFile.FileName.Split('.')[0];
                    pd.FileName = postedFile.FileName;
                    pd.Created = DateTime.Now;
                    pd.Createdby = AppSession.UserId;
                    pd.Modified = DateTime.Now;
                    pd.Modifiedby = AppSession.UserId;
                    _dbContextHelper.AttachToContext(pd);
                    ViewBag.ProjectDocId = pd.Id;
                    lstpd.Add(pd.Id);
                    ViewBag.ProjectDocId = lstpd;
                }
                catch (Exception ex)
                {

                }
            }


            // Return an empty string to signify success
            IntializeViewdata();
            return View("ngCreate");
        }

        public ActionResult SaveSupooritngDoc()
        {

            // The Name of the Upload component is "files"
            //if (SupportingDocFiles != null)
            //{
            //    foreach (var file in SupportingDocFiles)
            //    {
            //        // Some browsers send file names with full path.
            //        // We are only interested in the file name.
            //        var fileName = Path.GetFileName(file.FileName);
            //        var physicalPath = Path.Combine(Server.MapPath("~/Attachments/"), fileName);

            //        // The files are not actually saved in this demo
            //        TempData["fileName"] = fileName;
            //        file.SaveAs(physicalPath);

            //        try
            //        {
            //            pd = new ProjectDocument();
            //            pd.Title = fileName.Split('.')[0];
            //            pd.FileName = fileName;
            //            pd.Created = DateTime.Now;
            //            pd.Createdby = AppSession.UserId;
            //            pd.Modified = DateTime.Now;
            //            pd.Modifiedby = AppSession.UserId;
            //            _dbContextHelper.AttachToContext(pd);
            //            ViewBag.SupportingProjectDocId = pd.Id;
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }


            //}

            List<int> lstspd = new List<int>();

            string path = Server.MapPath("~/Attachments/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                postedFile.SaveAs(path + postedFile.FileName);
                try
                {
                    spd = new SupportingDocument();
                    spd.Title = postedFile.FileName.Split('.')[0];
                    spd.FileName = postedFile.FileName;
                    spd.Created = DateTime.Now;
                    spd.Createdby = AppSession.UserId;
                    spd.Modified = DateTime.Now;
                    spd.Modifiedby = AppSession.UserId;
                    _dbContextHelper.AttachToContext(spd);
                    ViewBag.ProjectDocId = spd.Id;
                    lstspd.Add(spd.Id);
                    ViewBag.SupportingProjectDocId = lstspd;
                }
                catch (Exception ex)
                {

                }
            }

            // Return an empty string to signify success
            IntializeViewdata();
            return View("ngCreate");
        }

        

        public ActionResult FileUpload()
        {
            IntializeViewdata();
            return View("ProjectDocuments");
        }

        public void IntializeViewdata()
        {
            ViewBag.Region = new SelectList(_dbContext.Region.ToList(), "Id", "Title", _dbContext.Region.FirstOrDefault());
            ViewBag.SubRegion = new SelectList(_dbContext.SubRegion.ToList(), "Id", "Title", _dbContext.SubRegion.FirstOrDefault());
            ViewBag.ProjectDocuments = new SelectList(_dbContext.ProjectDocument.ToList(), "Id", "Title", _dbContext.ProjectDocument.FirstOrDefault());
            ViewBag.SupportingDocuments = new SelectList(_dbContext.SuportingDocument.ToList(), "Id", "Title", _dbContext.SuportingDocument.FirstOrDefault());
        }
    }
}
