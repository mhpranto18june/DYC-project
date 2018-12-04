using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace DYC_project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        Database1Entities db = new Database1Entities();
        public ActionResult addcomplain()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult addComplain(complain com)
        {
           //insert
            db.complains.Add(com);
            var st = db.SaveChanges();
            if (st > 0)
            {
                ViewBag.msg = "Your Complain is successfully recorded!Thanks For Supporting Us.";
            }
            else
            {
                ViewBag.msg = "Complain Invailed!";
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult ComplainList()
        {
            return View(db.complains.ToList());
        }

        public ActionResult login()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult login(SocityAdmin lg)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities1 ue = new Database1Entities1())
                {
                    var log = ue.SocityAdmins.Where(a => a.UserName.Equals(lg.UserName) && a.Password.Equals(lg.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["UserName"] = log.UserName;
                        return RedirectToAction("ComplainList", "Home");
                    }

                    else
                    {
                        Response.Write("<script> alert('Invaild password')</script>");
                    }
                }
            }
            return View();
        }
     
     

        public ActionResult AssignTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AssignTask(AssignTask c)
        {
            Database1Entities2 db = new Database1Entities2();
            db.AssignTasks.Add(c);
            var st = db.SaveChanges();
            if (st > 0)
            {
                ViewBag.msg = "Task Assign.";
            }
            else
            {
                ViewBag.msg = "Task Invailed!";
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult AssigningWorklist()
        {
            Database1Entities2 db = new Database1Entities2();
            return View(db.AssignTasks.ToList());
        }

        public ActionResult WorkerAdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WorkerAdminLogin(WorkesAdmin lg)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities3 ue = new Database1Entities3())
                {
                    var log = ue.WorkesAdmins.Where(a => a.UserName.Equals(lg.UserName) && a.Password.Equals(lg.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["UserName"] = log.UserName;
                        return RedirectToAction("AssigningWorklist", "Home");
                    }

                    else
                    {
                        Response.Write("<script> alert('Invaild password')</script>");
                    }
                }
            }
            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("WorkerAdminLogin", "home");
        }

        public ActionResult logoutFromSSadmin()
        {
            Session.Clear();
            return RedirectToAction("login", "home");
        }

        public ActionResult WorkUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WorkUpdate(WorkResult s)
        {
          Database1Entities5 db = new Database1Entities5();
            db.WorkResults.Add(s);
            var st = db.SaveChanges();
            if (st > 0)
            {
                ViewBag.msg = "Workupdated.";
            }
            else
            {
                ViewBag.msg = "WorkUpdate Invailed!";
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult Workstatuslist()
        {
            Database1Entities5 db = new Database1Entities5();
            return View(db.WorkResults.ToList());
        }

        public ActionResult User_Login_or_reg_page()
        {
            return View();
        }

        public ActionResult General_User_reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult General_User_reg(GeneralUser g)
        {
          Database1Entities7 db = new Database1Entities7();
            db.GeneralUsers.Add(g);
            var st = db.SaveChanges();
            if (st > 0)
            {
                ViewBag.msg = "Registration Done Successfully";
              return  RedirectToAction("Workstatuslist");

            }
            else
            {
                ViewBag.msg = "Invailed! Email or Password";
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult ComplainerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ComplainerLogin(GeneralUser lg)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities7 ue = new Database1Entities7())
                {
                    var log = ue.GeneralUsers.Where(a => a.Email.Equals(lg.Email) && a.Password.Equals(lg.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["Email"] = log.Email;
                        return RedirectToAction("Workstatuslist", "Home");
                    }

                    else
                    {
                        Response.Write("<script> alert('Invaild password')</script>");
                    }
                }
            }
            return View();
        }



    }
}