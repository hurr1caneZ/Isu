using System.Collections;
using System.Dynamic;
using System.Text.RegularExpressions;
using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Services;
using Xunit;
using Group = Isu.Entities.Group;

namespace Isu.Test;
public class IsuServiceTest
{
    private IsuService isuService = new IsuService();
    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var newGroup = new Group(new GroupName("m31321"));
        isuService.AddGroup(newGroup.GroupName);
        Student student = isuService.AddStudent(newGroup, "chikibamboni");
        Assert.That(student.GroupName, Is.EqualTo(newGroup.GroupName));
        Assert.Contains(student, (ICollection?)newGroup.Students);
    }
    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var newGroup = new Group(new GroupName("m3123"));
        for (int i = 0; i < 30; i++)
        {
            isuService.AddStudent(newGroup, "bobi");
        }
        Assert.Throws<ArgumentOutOfRangeException>(() => isuService.AddStudent(newGroup, "bobik"));
    }
    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        
        Assert.Throws<WrongGroupNameException>(() => isuService.AddGroup(new GroupName("M32121123")));
    }
    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        Group curGroup = new Group(new GroupName("m3121"));
        Group newGroup = new Group(new GroupName("m3122"));
        Student newStudent = isuService.AddStudent(curGroup, "chikibamboni");
        isuService.ChangeStudentGroup(newStudent, newGroup);
        if (newGroup != null)
            Assert.Contains(curGroup.ToString(), new[] { newGroup.ToString() });
    }
}