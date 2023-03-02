using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(string name, int id, GroupName groupName)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(nameof(name));
        }

        GroupName = groupName;
        Name = name;
        Id = id;
    }

    public GroupName GroupName { get; set; }

    public int Id { get; private set; }
    public string Name { get; set; }

    public void ChangeStudentGroup(GroupName groupName)
    {
        GroupName = groupName;
    }
}