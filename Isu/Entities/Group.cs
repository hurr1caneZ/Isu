using System.Collections.Immutable;
using Isu.Models;

namespace Isu.Entities;

public class Group
{
    private const int MaxStudents = 30;
    private List<Student> _students;

    public Group(GroupName groupName)
    {
        GroupName = groupName;
        _students = new List<Student>();
    }

    public GroupName GroupName { get; set; }
    public CourseNumber? CourseNumber { get; set; }
    public IReadOnlyList<Student> Students { get => _students; }
    public void AddStudentToGroup(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        if (Students.Count + 1 > MaxStudents)
        {
            throw new ArgumentOutOfRangeException("Students count is out of range");
        }

        _students.Add(student);
    }

    public void RemoveStudentFromGroup(Student student)
    {
        _students.Remove(student);
    }
}