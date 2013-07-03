using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using Facebook;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace MvcApplication1.Controllers
{
    public class FBFriendsController : Controller
    {
        //
        // GET: /FBFriends/

        public ActionResult Index()
        {
            
             if (Session["facebooktoken"] != null)
            {
                string myAccessToken = Session["facebooktoken"].ToString();         
                FacebookClient client = new FacebookClient(myAccessToken);         

                // Friends List
               // var friendListData = client.Get("/me/friends");

                // Likes List
                var friendListData = client.Get("/me/likes");

                JObject friendListJson = JObject.Parse(friendListData.ToString());

                ArrayList fbUsers = new ArrayList();
                foreach (var friend in friendListJson["data"].Children())             
                {   
                    FbUser fbUser = new FbUser();
                    fbUser.Id = friend["category"].ToString().Replace("\"", "");
                    fbUser.Name = friend["name"].ToString().Replace("\"", "");

                    fbUsers.Add(fbUser);
                }

                ViewData["FBFriends"] = fbUsers;
             }



             return View(ViewData["FBFriends"]);
        }

        //
        // GET: /FBFriends/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /FBFriends/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FBFriends/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FBFriends/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /FBFriends/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FBFriends/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FBFriends/Delete/5

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
    }
}
