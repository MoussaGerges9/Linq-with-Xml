using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXml
{
    class Program
    {
        static void Main(string[] args)
        {

            string studentXml = File.ReadAllText("Xml.txt");

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentXml);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value
                           };

            foreach (var student in students)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}, University: {2}", student.Name, student.Age, student.University);
            }

            Console.WriteLine();

            var sortedStudents = from student in students
                orderby student.Age
                select student;

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}, University: {2}", student.Name, student.Age, student.University);
            }

            Console.ReadKey();
        }

    }
}
