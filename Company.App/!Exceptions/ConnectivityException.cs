using System;
using FlexiMvvm.Exceptions;

namespace Company.App
{
    public class ConnectivityException : Exception, IUserFriendlyException
    {
        public ConnectivityException(string message)
            : base(message)
        {
        }
    }
}
