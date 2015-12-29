using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtisAPI.ModelHelpers;
using UtisAPI.Models;

namespace UtisAPI.Repositories
{
    public interface IUsersRepo
    {
        PagedResult GetPagedUsers(int page, int pageSize);


    }
}
