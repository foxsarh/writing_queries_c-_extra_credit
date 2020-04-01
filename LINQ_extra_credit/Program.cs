using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_extra_credit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a data source by using a collection initializer.
            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}},

                //Add a new student to the list of student constructor objects 
                new Student {First="Sarah", Last="Fox", ID=123, Scores= new List<int> {99,87,93,96}}
            };

            // Create the query.
            // The first line could also be written as "var studentQuery ="
            IEnumerable<Student> studentQuery =
                from student in students
                //where student.Scores[0] > 90
                where student.Scores[0] > 90 && student.Scores[3] < 80
                //orderby student.Last ascending
                orderby student.Scores[0] descending
                select student;

            // studentQuery2 is an IEnumerable<IGrouping<char, Student>>
            // this produces a sequence of groups that have char data type as a "key"
            // and a sequence of student objects 
            var studentQuery2 =
                from student in students
                group student by student.Last[0];

            // Execute the query.
            // var could be used here also.
            foreach (Student student in studentQuery)
            {
                //Console.WriteLine("{0}, {1} || ID Number: {2}", student.Last, student.First, student.ID);

                // Change the output so that the score are visible
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);

            }//end of foreach loop

            // studentGroup is a IGrouping<char, Student>
            // output data from studentQuery2 grouping 
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }//end of foreach loop

            //make the variables implicitly typed 
            //using the var keyword to make it more convenient to change the types of my objects
            var studentQuery3 =
                from student in students
                group student by student.Last[0];

            //output data from studentQuery3
            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

        }//End of main
    }//End of program class

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }
   
}
