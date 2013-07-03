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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {



           //List<Object> education ;

           //var msg = "";


           //if (Session["facebooktoken"] != null)
           //{
           //    var client = new Facebook.FacebookClient(Session["facebooktoken"].ToString());

           //    dynamic response = client.Get("me", new { fields = "education" });

           //    if (response.ContainsKey("education"))
           //    {
           //        education = response["education"];

           //        int count = education.Count();

           //        for (int counter = 0; counter < count; counter++)
           //        {

           //            dynamic obj = education[counter];

           //            dynamic obj2 = obj[0];

           //            dynamic obj3 = obj2[1];

           //            msg = msg + "<BR/> " + obj3.ToString();
           //        }
           //    }

           //    msg = "Your education is  " + msg;

           //  }

           //ViewBag.Message =  msg;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
