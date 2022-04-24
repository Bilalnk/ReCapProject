#region info

// Bilal Karataş20220424

#endregion

using System.Collections.Generic;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}