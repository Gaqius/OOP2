using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace L3.Code
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads lines from a file
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        private static IEnumerable<string> ReadLines(Stream contents)
        {
            using (StreamReader reader = new StreamReader(contents))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        /// <summary>
        /// Reads student file
        /// </summary>
        /// <param name="contents"></param>
        /// <returns>A student list</returns>
        public static MyList<Student> ReadStudents(Stream contents)
        {
            var students = new MyList<Student>();
            foreach (string line in ReadLines(contents))
            {
                string[] parts = line.Split(';');
                string surname = parts[0];
                string name = parts[1];
                string group = parts[2];
                string month = parts[3];
                string excersiseId = parts[4];
                students.Add(new Student(surname, name, group, month, excersiseId));
            }
            return students;
        }
        /// <summary>
        /// Reads exercises file
        /// </summary>
        /// <param name="contents"></param>
        /// <returns>Exercise list</returns>
        public static MyList<Excersise> ReadExcersises(Stream contents)
        {
            var excersises = new MyList<Excersise>();
            foreach (string line in ReadLines(contents))
            {
                string[] parts = line.Split(';');
                string iD = parts[0];
                string name = parts[1];
                string profCreds = parts[2];
                int timeLimit = Convert.ToInt32(parts[3]);
                excersises.Add(new Excersise(iD, name, profCreds, timeLimit));
            }
            return excersises;
        }
        /// <summary>
        /// Prints the starting data
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="students"></param>
        public static void PrintData(StreamWriter writer, IEnumerable<Student> students)
        {

            if (students.Count() == 0)
            {
                writer.WriteLine("Tuščia");
                return;
            }
            writer.WriteLine(new string('-', 65));
            writer.WriteLine("| {0,10} | {1,10} | {2,6} | {3,8} | {4,15} |", "Pavardė", "Vardas", "Grupė", "Mėnuo", "Užduoties kodas");
            writer.WriteLine(new string('-', 65));
            foreach (Student e in students)
            {
                writer.WriteLine("| {0,10} | {1,10} | {2,6} | {3,8} | {4,15} |", e.Surname, e.Name, e.Group, e.Month, e.ExcersiseID);
            }
            writer.WriteLine(new string('-', 65));
        }
        /// <summary>
        /// Prints assigned students
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="counts"></param>
        public static void PrintAssignedStudentCounts(StreamWriter writer, IEnumerable<TupleStringInt> counts)
        {
            if (counts.Count() == 0)
            {
                writer.WriteLine("Tuščia");
                return;
            }
            writer.WriteLine(new string('-', 23));
            writer.WriteLine("| {0,10} | {1,-6} |", "Dėstytojas", "Kiekis");
            writer.WriteLine(new string('-', 23));
            foreach (TupleStringInt e in counts)
            {
                writer.WriteLine("| {0,10} | {1,-6} |", e.Item1, e.Item2);
            }
            writer.WriteLine(new string('-', 23));
        }
        /// <summary>
        /// Pritns exercise table
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="list"></param>
        public static void PrintExerciseTables(StreamWriter writer, IEnumerable<Excersise> list)
        {
            var profNames = TaskUtils.GetProfName(list);
            foreach (var profName in profNames)
            {
                var IDs = TaskUtils.GetExcersisesFromProf(list, profName);
                if (IDs.Count() == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }
                writer.WriteLine(new string('-', 73));
                writer.WriteLine("| {0,12} | {1,21} | {2,10} | {3,14} |", "Užduoties kodas", "Užduoties pavadinimas", "dėstytojas", "skirtas laikas");
                writer.WriteLine(new string('-', 73));
                foreach (var ID in IDs)
                {
                    var e = TaskUtils.GetExcersiseByID(ID, list);
                    writer.WriteLine("| {0,15} | {1,21} | {2,10} | {3,14} |", e.ID, e.Name, e.ProfNameSurname, e.TimeLimit);
                }
                writer.WriteLine(new string('-', 73));
            }
        }
        /// <summary>
        /// Prints filtered exercise table
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="list"></param>
        public static void PrintFilteredExerciseTables(StreamWriter writer, MyList<MyList<Excersise>> list)
        {
            foreach (MyList<Excersise> item in list)
            {
                if (list.Count() == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }

                writer.WriteLine(new string('-', 73));
                writer.WriteLine("| {0,12} | {1,21} | {2,10} | {3,14} |", "Užduoties kodas", "Užduoties pavadinimas", "dėstytojas", "skirtas laikas");
                writer.WriteLine(new string('-', 73));
                foreach (Excersise e in item)
                {
                    writer.WriteLine("| {0,15} | {1,21} | {2,10} | {3,14} |", e.ID, e.Name, e.ProfNameSurname, e.TimeLimit);
                }
                writer.WriteLine(new string('-', 73));
            }
        }
    }
}