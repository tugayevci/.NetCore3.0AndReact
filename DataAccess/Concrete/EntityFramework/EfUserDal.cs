using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from o in context.OperationClaims
                             join u in context.UserOperationClaims
                             on o.Id equals u.OperationClaimId
                             where u.UserId == user.Id
                             select new OperationClaim { Id = o.Id, Name = o.Name };
                return result.ToList();
            }

        }
    }
}
