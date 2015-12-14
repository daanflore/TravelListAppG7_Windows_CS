using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using TravelListAppG7Service.DataObjects;
using TravelListAppG7Service.Models;
using System;
using System.Net;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Security;

namespace TravelListAppG7Service.Controllers
{
    public class UserController : TableController<User>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListAppG7Context context = new TravelListAppG7Context();
            DomainManager = new EntityDomainManager<User>(context, Request, Services);
        }

        // GET tables/User
        public IQueryable<User> GetAllUser()
        {
            IQueryable<User> users = Query();
            return Query(); 
        }

        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<User> GetUser(string id)
        {
            return Lookup(id);
        }



        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<User> PatchUser(string id, Delta<User> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/User
        public async Task<IHttpActionResult> PostUser(User item)
        {
            User userFound = Query().Where(i => i.username == item.username).FirstOrDefault();
            if (userFound!=null)
            {
                
                return Content(HttpStatusCode.Conflict, String.Format("A user with the username: {0} already exists",item.username));
            }
            item.password=CreatePasswordHash(item.password);
            User current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUser(string id)
        {
             return DeleteAsync(id);
        }

        [Route("api/tables/Users/login")]
        public SingleResult<User> Login(string userName, string Password)
        {
            String passwordControl = CreatePasswordHash(Password);
            IQueryable<User> user = Query().Where(i => i.username == userName && i.password == passwordControl);
             return SingleResult.Create<User>(user);
        }
       

        public  string CreatePasswordHash(string pwd)
        {
            
            string hashedPwd =
                FormsAuthentication.HashPasswordForStoringInConfigFile(
                pwd, "sha1");
            return hashedPwd;
        }
        [Route("api/tables/Users/user")]
        [HttpPost]
        public SingleResult<User> getFriend(string userName)
        {
            
            IQueryable<User> user = Query().Where(i => i.username == userName);
            return SingleResult.Create<User>(user);
        }


    }
}