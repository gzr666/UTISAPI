using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UtisAPI.Models;
using UtisAPI.Repositories;

namespace UtisAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersRepo repo;
       


        public UsersController(IUsersRepo repo)
        {
            this.repo = repo;

        }

        // GET api/Users
        public IHttpActionResult GetUsers(int page = 1, int pageSize = 4)
        {
            var pager = repo.GetPagedUsers(page, pageSize);

            
            return Ok(pager);





        }
    }
        
}