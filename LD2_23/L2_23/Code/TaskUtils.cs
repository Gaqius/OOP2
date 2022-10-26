using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_23.Code
{
    public class TaskUtils
    {
        /// <summary>
        /// Filters the list by input month
        /// </summary>
        /// <param name="students"></param>
        /// <param name="month"></param>
        /// <returns>Student list</returns>
        public static ObjectList FilterByMonth(ObjectList students, string month)
        {
            ObjectList studentList = new ObjectList();

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
        /// 
        /// </summary>
        /// <param name="excersises"></param>
        /// <returns></returns>
        public static ObjectList GetProfName(ObjectList excersises)
        {
            ObjectList profList = new ObjectList();

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
        /// Matches exercise IDs to professors
        /// </summary>
        /// <param name="excersises"></param>
        /// <returns>A dictionary</returns>
        public static Dictionary<string, List<string>> GroupExerciseIDsByProffesor(ObjectList excersises)
        {
            Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();

            foreach (Excersise ex in excersises)
            {
                if (!list.ContainsKey(ex.ProfNameSurname))
                {
                    list.Add(ex.ProfNameSurname, new List<string>());
                }
                list[ex.ProfNameSurname].Add(ex.ID);
            }
            return list;
        }
        /// <summary>
        /// Counts how many students pass the filter
        /// </summary>
        /// <param name="students"></param>
        /// <param name="IDs"></param>
        /// <returns>A number</returns>
        public static int CountStudentsByExerciseIDs(ObjectList students, List<string> IDs)
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
        public static ObjectList CountAssignedStudents(ObjectList students, ObjectList excersises)
        {
            ObjectList studentCounts = new ObjectList();

            foreach (var item in GroupExerciseIDsByProffesor(excersises))
            {
                int count = CountStudentsByExerciseIDs(students, item.Value);
                studentCounts.Add(new TupleStringInt(item.Key, count));
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
        public static int FindProffesorAssignedStudentsAverage(ObjectList students, ObjectList excersises)
        {
            int count = 0;
            int sum = 0;
            ObjectList list = CountAssignedStudents(students, excersises);
            
            foreach (TupleStringInt line in list)
            {
                sum += line.Item2;
                count++;
            }
            return sum / count;
        }
        /// <summary>
        /// Filters professors by the average number
        /// </summary>
        /// <param name="students"></param>
        /// <param name="excersises"></param>
        /// <param name="month"></param>
        /// <returns>A filtered list</returns>
        public static ObjectList FilterProffessorsByAverage(ObjectList students, ObjectList excersises)
        {
            ObjectList list = CountAssignedStudents(students, excersises);
            ObjectList filteredList = new ObjectList();
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
        public static ObjectList FilterByAssignedStudents(ObjectList excersises, ObjectList students, int minAssignedStudents)
        {
            ObjectList filtered = new ObjectList();
            Dictionary<string, ObjectList> groupedExercises = GroupExercisesByProffesor(excersises);
        
            foreach (TupleStringInt item in CountAssignedStudents(students, excersises))
            {
                string proffesor = item.Item1;
                int count = item.Item2;
                if (count >= minAssignedStudents)
                {
                    filtered.Add(groupedExercises[proffesor]);
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
        public static Excersise GetExcersiseByID (string ID, ObjectList excersises)
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
        /// <summary>
        /// Groups all the exercises to their corresponding professors
        /// </summary>
        /// <param name="excersises"></param>
        /// <returns>A dictionary</returns>
        public static Dictionary<string, ObjectList> GroupExercisesByProffesor(ObjectList excersises)
        {
            Dictionary<string, List<string>> profList = GroupExerciseIDsByProffesor(excersises);
            Dictionary<string, ObjectList> list = new Dictionary<string, ObjectList>();

            foreach (var profs in profList)
            {
                ObjectList profExc = new ObjectList();
                foreach (var ID in profs.Value)
                {
                    profExc.Add(GetExcersiseByID(ID, excersises));
                }
                list.Add(profs.Key, profExc);
            }
            return list;
        }        
    }
}