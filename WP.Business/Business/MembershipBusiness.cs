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
    public class MembershipBusiness : IMembershipBusiness
    {
        #region Variable Declaration
        private readonly IMembershipRepository _membershipRepository;
        #endregion

        #region Parameterized Constructor
        public MembershipBusiness(IMembershipRepository membershipRepository)
        {
            this._membershipRepository = membershipRepository;
        }
        #endregion

        #region Get

        #region GetyMenbershipId
        public List<MembershipModel> GetByMemershipId(string membershipGuid)
        {
            return this._membershipRepository.GetByMemershipId(membershipGuid);
        }
        #endregion

        #endregion

        #region Post

        #region AddNewSubscription
        public string AddSubscription(MembershipModel Addmembership)
        {
            return this._membershipRepository.AddSubscription(Addmembership);
        }
        #endregion

        #endregion

        #region Put

        #region UpdateSubscription
        public bool UpdateSubscription(MembershipModel Addmembership)
        {
            return this._membershipRepository.UpdateSubscription(Addmembership);
        }
        #endregion

        #endregion

    }
}
