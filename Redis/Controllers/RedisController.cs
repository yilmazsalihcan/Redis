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
            RedisEndpoint redisEndpoint = new RedisEndpoint("127.0.0.1",6379);
            RedisClient client = new RedisClient(redisEndpoint);
            UserModel userModel = new UserModel()
            {
                Username="Salih Can",
                Email="aaa@aa.com",
                Password="12345"
            };
            var serialized = JsonConvert.SerializeObject(userModel);
            client.SetValue("UserInfo", serialized);
            var getUserInfo =JsonConvert.DeserializeObject<UserModel>(client.GetValue("UserInfo"));
            return View(getUserInfo);
        }




    }
}