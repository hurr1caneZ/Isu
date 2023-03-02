namespace Isu.Models;

public class CourseNumber
{
    public CourseNumber(byte courseNum)
    {
        CourseNum = courseNum;
    }

    public byte CourseNum { get; private set; }
}   