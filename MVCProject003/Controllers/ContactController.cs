using MVCProject003.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCProject003.Controllers
{
    public class ContactController : Controller
    {
        
        // GET: Contact
        public ActionResult ContIndex()
        {
            return View();
        }
        public ActionResult DetailsIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult Savereg(ContactModel model)
        {
            try

            {
                return Json(new { Message = (new ContactModel().Savereg(model)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetDataList()
        {
            try

            {
                return Json(new { model = (new ContactModel().GetDataList()) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult DeleteContact(int Id)
        {
            try
            { 
                return Json(new { model = (new ContactModel().DeleteContact(Id)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult GetContactbyId(int Id)
        {
            try
            {
                return Json(new { model = (new ContactModel().GetContactbyId(Id)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}