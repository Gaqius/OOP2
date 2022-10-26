using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3.Code
{
    public class TaskUtils
    {
        /// <summary>
        /// Filters the list by input month
        /// </summary>
        /// <param name="students"></param>
        /// <param name="month"></param>
        /// <returns>Student list</returns>
        public static MyList<Student> FilterByMonth(MyList<Student> students, string month)
        {
            MyList<Student> studentList = new MyList<Student>();

            foreach (Student student in students)
            {
                if (student.Month == month)
                {
                    studentList.Add(student);
                }
            }
            return studentList;
        }
        /// <summary>
        /// Gets a professors name from an excersise
        /// </summary>
        /// <param name="excersises"></param>
        /// <returns></returns>
        public static MyList<String> GetProfName(IEnumerable<Excersise> excersises)
        {
            var profList = new MyList<String>();

            foreach (Excersise prof in excersises)
            {
                if (!profList.Contains(prof.ProfNameSurname))
                {
                    profList.Add(prof.ProfNameSurname);
                }
            }
            return profList;
        }
        /// <summary>
        /// Gets an excersise by using a professors name
        /// </summary>
        /// <param name="excersises"></param>
        /// <param name="profName"></param>
        /// <returns></returns>
        public static MyList<string> GetExcersisesFromProf(IEnumerable<Excersise> excersises, string profName)
        {
            var list = new MyList<string>();

            foreach (var ex in excersises)
            {
                if (ex.ProfNameSurname == profName)
                {
                    list.Add(ex.ID);
                }
            }
            return list;
        }
        /// <summary>
        /// Counts students by excersise IDs
        /// </summary>
        /// <param name="students"></param>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public static int CountStudentsByExerciseIDs(MyList<Student> students, MyList<string> IDs)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if (IDs.Contains(student.ExcersiseID))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Counts assigned studends
        /// </summary>
        /// <param name="students"></param>
        /// <param name="excersises"></param>
        /// <param name="month"></param>
        /// <returns>List of students</returns>
        public static MyList<TupleStringInt> CountAssignedStudents(MyList<Student> students, MyList<Excersise> excersises)
        {
            var profNames = GetProfName(excersises);
            var studentCounts = new MyList<TupleStringInt>();

            foreach (var profName in profNames)
            {
                GetExcersisesFromProf(excersises, profName);
                int count = CountStudentsByExerciseIDs(students, GetExcersisesFromProf(excersises, profName));
                studentCounts.Add(new TupleStringInt(profName, count));
            }

            return studentCounts;
        }
        /// <summary>
        /// Finds the average amount of how many students each professor gave an exercise to
        /// </summary>
        /// <param name="students"></param>
        /// <param name="excersises"></param>
        /// <param name="month"></param>
        /// <returns>A number</returns>
        public static int FindProffesorAssignedStudentsAverage(MyList<Student> students, MyList<Excersise> excersises)
        {
            int count = 0;
            int sum = 0;
            MyList<TupleStringInt> list = CountAssignedStudents(students, excersises);

            foreach (TupleStringInt line in list)
            {
                sum += line.Item2;
                count++;
            }
            return sum / count;
        }
        /// <summary>
        /// Filters list of professors by average
        /// </summary>
        /// <param name="students"></param>
        /// <param name="excersises"></param>
        /// <returns></returns>
        public static MyList<TupleStringInt> FilterProffessorsByAverage(MyList<Student> students, MyList<Excersise> excersises)
        {
            MyList<TupleStringInt> list = CountAssignedStudents(students, excersises);
            MyList<TupleStringInt> filteredList = new MyList<TupleStringInt>();
            int avrg = FindProffesorAssignedStudentsAverage(students, excersises);

            foreach (TupleStringInt prof in list)
            {
                if (prof.Item2 > avrg)
                {
                    filteredList.Add(prof);
                }
            }
            return filteredList;
        }
        /// <summary>
        /// Filters the list by assigned students
        /// </summary>
        /// <param name="excersises"></param>
        /// <param name="minAssignedStudents"></param>
        /// <returns>A filtered list</returns>
        public static MyList<MyList<Excersise>> FilterByAssignedStudents(MyList<Excersise> excersises, MyList<Student> students, int minAssignedStudents)
        {
            var filtered = new MyList<MyList<Excersise>>();

            foreach (TupleStringInt item in CountAssignedStudents(students, excersises))
            {
                string proffesor = item.Item1;
                int count = item.Item2;
                if (count >= minAssignedStudents)
                {
                    var IDs = GetExcersisesFromProf(excersises, proffesor);
                    var profExcersises = new MyList<Excersise>();
                    foreach (var ID in IDs)
                    {
                        profExcersises.Add(GetExcersiseByID(ID, excersises));
                    }
                    filtered.Add(profExcersises);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Finds an exercise by its ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="excersises"></param>
        /// <returns>An exercise</returns>
        public static Excersise GetExcersiseByID(string ID, IEnumerable<Excersise> excersises)
        {
            foreach (Excersise excersise in excersises)
            {
                if (excersise.ID == ID)
                {
                    return excersise;
                }
            }
            return null;
        }
    }
}