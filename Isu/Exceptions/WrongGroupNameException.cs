using Isu.Services;

namespace Isu.Exceptions;

public class WrongGroupNameException : Exception
{
    public WrongGroupNameException(string groupName)
        : base($"GroupName can't be {groupName}")
    { }
}