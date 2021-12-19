using System;
using TestDataGen.Models;

namespace TestDataGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Teacher teacher = GenerateTeacher();
            AddTeacher(teacher);
        }

        public static Teacher GenerateTeacher()
        {
            Teacher teacher = new Teacher();
            //teacher.TeacherId = Faker.RandomNumber.Next(0, 10000);
            teacher.TeacherName = Faker.Name.FullName();
            teacher.StandardId = Faker.RandomNumber.Next(1, 9);
            teacher.TeacherType = Faker.RandomNumber.Next(0, 10000);
            return teacher;
        }

        public static void AddTeacher(Teacher teacher)
        {
            SchoolDBContext db = new SchoolDBContext();
            db.Add<Teacher>(teacher);
            db.SaveChanges();
        }
    }
}
