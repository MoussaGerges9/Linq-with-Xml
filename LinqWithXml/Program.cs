using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string studentXml = @"
                             <Students>
                              <Student>
                                <Name>Marco</Name>
                                <Age>19</Age>
                                <University>Don Bosco</University>
                              </Student>
                               <Student>
                                <Name>Maickel</Name>
                                <Age>18</Age>
                                <University>Cairo University</University>
                              </Student>
                              <Student>
                                <Name>Abdo</Name>
                                <Age>17</Age>
                                <University>Modern Academy</University>
                              </Student>
                             </Students>";

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

            Console.ReadKey();
        }
    }
}
