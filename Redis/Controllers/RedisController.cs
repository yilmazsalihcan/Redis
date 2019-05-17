using Newtonsoft.Json;
using Redis.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redis.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToRedis(string username,string password)
        {
            RedisEndpoint redisEndpoint = new RedisEndpoint("127.0.0.1", 6379);
            redisEndpoint.Db =12; //Farklı database adreslerinde işlem yapabiliriz. Max 16 tane
            RedisClient client = new RedisClient(redisEndpoint);
            UserModel userModel = new UserModel()
            {
                Username =username,
                Email = "aaa@aa.com",
                Password = password
            };
            var serialized = JsonConvert.SerializeObject(userModel);
            client.SetValue("UserInfo", serialized);
            var getUserInfo = JsonConvert.DeserializeObject<UserModel>(client.GetValue("UserInfo"));
            Session["UserInfo"] = client.GetValue("UserInfo");
            return Redirect("Index");
        }



    }
}