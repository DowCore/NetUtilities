using Microsoft.SqlServer.Server;
using System;

namespace Dow.Utilities.Exceptions
{
    public interface IUserDefinedException
    {

    }

    public class UserDefinedException : Exception, IUserDefinedException
    {
        public UserDefinedException(string errorCode):base()
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; private set; }
    }
}
