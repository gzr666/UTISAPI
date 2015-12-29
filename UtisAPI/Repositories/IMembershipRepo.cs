using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtisAPI.Models;
using UtisAPI.ViewModels;

namespace UtisAPI.Repositories
{
    public interface IMembershipRepo
    {
        IQueryable<Year> GetMembershipsYears();

        IQueryable<VrstaUplate> GetMembershipTypes();

        MembershipTotal GetTotal(int UserID, int YearID);

        YearlyMembership InsertMembership(Uplata uplata);

        bool SaveAll();

        


    }
}
