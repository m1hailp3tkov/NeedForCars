using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.UserCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NeedForCars.Web.ViewModels.Profile
{
    public class UserInfoModel : IMapFrom<NeedForCarsUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public IPagedList<DisplayUserCarModel> DisplayUserCars { get; set; }
    }
}
