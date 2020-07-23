using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Dow.Utilities.Exceptions
{
    public interface IUserDefinedException
    {

    }

  

    [Serializable]
    public class UserDefinedException : Exception , IUserDefinedException
    {

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected UserDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorCode = (string)info.GetValue("ErrorCode", typeof(string));
        }
        public UserDefinedException(string errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ErrorCode", ErrorCode);
        }

        public string ErrorCode { get; private set; }
    }
}
