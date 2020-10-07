using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness;
using WP.Model;
using WP.Repository.IRepository;

namespace WP.Business.Business
{
    public class CheckUserSubscriptionBusiness : ICheckUserSubscriptionBusiness
    {
        #region Variable Declaration
        private readonly ICheckUserSubscriptionRepository _checkUserSubscriptionRepository;
        #endregion

        #region Parameterized Constructor
        public CheckUserSubscriptionBusiness(ICheckUserSubscriptionRepository checkUserSubscriptionRepository)
        {
            this._checkUserSubscriptionRepository = checkUserSubscriptionRepository;
        }
        #endregion

        #region Get

        #region CheckSubscriptionByUserId
        public int CheckByUserId(string UserGuid)
        {
            return this._checkUserSubscriptionRepository.CheckByUserId(UserGuid);
        }
        #endregion

        #endregion

        #region Post

        #region AddNewSubscription
        public int NewSubscription(CheckUserSubscriptionModel AddSubscription)
        {
            return this._checkUserSubscriptionRepository.NewSubscription(AddSubscription);
        }
        #endregion

        #endregion
    }
}
