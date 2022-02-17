using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> students { get; set; }
        public int Capacity { get; set; }
        public int Count => students.Count;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (students.Count + 1 <= Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string first, string second)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == first && student.LastName == second)
                {
                    students.Remove(student);
                    return $"Dismissed student {first} {second}";

                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            int count = 0;
            List<string> names = new List<string>();

            names.Add($"Subject: {subject}");
            names.Add($"Students:");

            foreach (Student student in students)
            {
                if (student.Subject == subject)
                {
                    names.Add($"{student.FirstName} {student.LastName}");
                    count++;
                }
            }

            if (count == 0)
            {
                return "No students enrolled for the subject";
            }
            return string.Join("\n", names);
        }

        public int GetStudentCount()
        {
            return Count;
        }

        public string GetStudent(string first, string last)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == first && student.LastName == last)
                {
                    return student.ToString();
                }
            }

            return null;
        }
    }
}
