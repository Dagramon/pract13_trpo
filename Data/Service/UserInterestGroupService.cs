using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.Data.Service
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public void Add(UserInterestGroup userInterestGroup)
        {
            var _userInterestGroup = new UserInterestGroup
            {
                InterestGroupId = userInterestGroup.InterestGroupId,
                InterestGroup = userInterestGroup.InterestGroup,
                UserId = userInterestGroup.UserId,
                User = userInterestGroup.User,
                JoinedAt = userInterestGroup.JoinedAt,
                IsModerator = userInterestGroup.IsModerator,
            };
            _db.Add<UserInterestGroup>(_userInterestGroup);
            _db.SaveChanges();
        }
    }
}
