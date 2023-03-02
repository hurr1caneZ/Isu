using Isu.Exceptions;

namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        if (TryParse(groupName))
        {
            GroupNamy = groupName;
            EducationType = int.Parse(groupName[1].ToString());
            CourseNum = new CourseNumber(byte.Parse(groupName[2].ToString()));
            GroupNumber = int.Parse(groupName[3].ToString());
            Specialization = int.Parse(groupName[4].ToString());
        }
        else
        {
            throw new WrongGroupNameException(groupName);
        }
    }

    public int EducationType { get; set; }
    public CourseNumber CourseNum { get; set; }
    public int GroupNumber { get; set; }
    public string GroupNamy { get; set; }
    public int Specialization { get; set; }

    public static bool TryParse(string groupName)
    {
        if (!char.IsLetter(groupName[0]) && (groupName.Length != 5 || groupName.Length != 6))
        {
            return false;
        }

        return true;
    }
}