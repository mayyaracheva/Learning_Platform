
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Exceptions;
using System;

namespace Poodle.Services.Helpers
{
	public static class AuthorizationHelper
	{
        public static void ValidateAccess(string requesterRole)
        {

            if (!requesterRole.Equals("teacher", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
            }
        }
    }
}
