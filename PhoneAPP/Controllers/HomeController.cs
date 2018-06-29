using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneAPP.Models;
using System.Text.RegularExpressions;

namespace PhoneAPP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      

      
            PhoneBookDBC DB = new PhoneBookDBC();
            // GET: Home
            public ActionResult MainPage()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddUser(PhoneBook newUser)
            {
                if (correctValues(newUser) == true)
                {
                    if (sameValueInDB(newUser) == false)
                    {
                        DB.clientsList.Add(newUser);
                        DB.SaveChanges();
                    }
                }
              return View("Add");
                
            }
        [HttpPost]
        public ActionResult EditUser (PhoneBook editedUser)
        {
            var entity = DB.clientsList.Find(editedUser.clientID);
            if (entity == null)
            {
                return View("Edit");
            }
            else
            {
                if (correctValues(editedUser) == true)
                {
                    if (sameValueInDBToEdit(editedUser) == false)
                    {
                        DB.Entry(entity).CurrentValues.SetValues(editedUser);
                        DB.SaveChanges();
                       
                    }
                }
             
            }
            return View("MainPage");
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Show()
        {
            var usersList = DB.clientsList.ToList();
            return View("Show",usersList);
        }

        [HttpGet]
        public ActionResult Manage(string id)
        {

            if (id != null)
            {
                DB.clientsList.Remove(DB.clientsList.Find(int.Parse(id)));
                DB.SaveChanges();
            }
        
        
            var usersList = DB.clientsList.ToList();
            return View("Manage",usersList);
        }

        public bool correctValues(PhoneBook user)
        {
            int n;
            if (user.clientPhoneNumber.ToString().Length<9 || user.clientPID.Length<11)
            {

                return false;
            }

    
            return true;
        }



        public bool sameValueInDB (PhoneBook user)
        {

            foreach (var dbUser in DB.clientsList)
            {
                if (user.clientPID==dbUser.clientPID || user.clientPhoneNumber == dbUser.clientPhoneNumber)
                {
                    
                    return true;
                    
                }
            }

            return false;
        }
        public bool sameValueInDBToEdit(PhoneBook user)
        {

            foreach (var dbUser in DB.clientsList)
            {
                if (user.clientPID != dbUser.clientPID && (user.clientPhoneNumber == dbUser.clientPhoneNumber || user.clientPID == dbUser.clientPID))
                {

                    return true;

                }
            }

            return false;
        }



    }
   
}

