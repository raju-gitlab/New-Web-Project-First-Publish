using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Business.IBusiness
{
    public interface IMembershipBusiness
    {
        #region Get

        #region GetMembershipById
        List<MembershipModel> GetByMemershipId(string membershipGuid);
        #endregion

        #endregion

        #region Post

        #region AddNewSubscription
        string AddSubscription(MembershipModel Addmembership);
        #endregion

        #endregion

        #region Put

        #region UpdateSubscription
        bool UpdateSubscription(MembershipModel Addmembership);
        #endregion

        #endregion
    }
}
