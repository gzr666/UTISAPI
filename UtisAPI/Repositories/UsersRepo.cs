using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtisAPI.ModelHelpers;
using UtisAPI.Models;

namespace UtisAPI.Repositories
{
    public class UsersRepo:IUsersRepo
    {
        private UtisDb db;

        public UsersRepo(UtisDb db)
        {

            this.db = db;
        
        }


        public PagedResult GetPagedUsers(int page, int pageSize)
        {
            var users = db.Users.OrderBy(u => u.ID).ToList();
            var totalCount = users.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var pager = users
                        .Skip(pageSize * (page - 1))
                        .Take(pageSize)
                        .ToList();



            return new PagedResult {PageSize=pageSize,TotalCount=totalCount,TotalPages=totalPages,Users=pager };

        }
    }
}