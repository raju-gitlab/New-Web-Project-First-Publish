using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Repository.IRepository
{
    public interface ICheckUserSubscriptionRepository
    {
        #region Get

        #region CheckSubscriptionByUserId
        int CheckByUserId(string UserGuid);
        #endregion

        #endregion

        #region Post

        #region AddNewSubscription
        int NewSubscription(CheckUserSubscriptionModel AddSubscription);
        #endregion

        #endregion
    }
}
