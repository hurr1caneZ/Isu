using Isu.Entities;
using Isu.Models;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private int id = 100_000;
        private List<Group> _groupList;
        private List<Student> _studentsList;
        public IsuService()
        {
            _groupList = new List<Group>();
            _studentsList = new List<Student>();
        }

        public Group AddGroup(GroupName name)
        {
            var group = new Group(name);
            _groupList.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            var student = new Student(name, ++id, group.GroupName);
            group.AddStudentToGroup(student);
            _studentsList.Add(student);
            return student;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            var removableStudent = _groupList.Find(x => x.GroupName.Equals(student.GroupName));
            if (removableStudent != null)
            {
                removableStudent.RemoveStudentFromGroup(student);
                newGroup.AddStudentToGroup(student);
                student.ChangeStudentGroup(newGroup.GroupName);
            }
        }

        public Group? FindGroup(GroupName groupName)
        {
             return _groupList.Find(x => x.GroupName.Equals(groupName));
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groupList.FindAll(x => x.GroupName.Equals(_groupList));
        }

        public Student? FindStudent(int id)
        {
                return _studentsList.Find(x => x.Id == id);
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            Group? group = _groupList.Find(group => group.GroupName.Equals(groupName));
            if (group != null)
                return (List<Student>)group.Students;
            return new List<Student>();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return _groupList
                .Where(group => group.GroupName.CourseNum.Equals(courseNumber))
                .SelectMany(group => group.Students).ToList();
        }

        public Student GetStudent(int id)
        {
            Student? student = _studentsList.Find(x => x.Id == id);
            if (student == null)
                throw new ArgumentNullException("shit, we hav nul");
            return student;
        }
    }
}