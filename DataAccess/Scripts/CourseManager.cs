using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    #region Course
    public static class CourseManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }


        public static bool Create(Course source)
        {
            try
            {
                Course course = new Course();

                course.Course_Code = source.Course_Code;
                course.Course_Description = source.Course_Description;
                course.Course_Name = source.Course_Name;
                course.CreatedBy = source.CreatedBy;
                course.CreatedDateTime = DateTime.Now;
                course.Faculty_ID = source.Faculty_ID;
                course.IsActive = true;
                course.ModifiedBy = source.ModifiedBy;
                course.ModifiedDateTime = DateTime.Now;

                cDBContext.Courses.Add(course);
                cDBContext.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }
    }

    #region Extensions
    public static class CourseExtensions
    {
        
    }
    #endregion
    #endregion

    #region Course Schedule
    public static class ScheduleManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }


        public static bool Create(Course_Schedule source)
        {
            try
            {
                Course_Schedule schedule = new Course_Schedule();

                schedule.Course_ID = schedule.Course_ID;
                schedule.CreatedBy = schedule.CreatedBy;
                schedule.CreatedDateTime = DateTime.Now;
                schedule.DT_From = source.DT_From;
                schedule.DT_To = source.DT_To;
                schedule.IsActive = true;
                schedule.ModifiedBy = source.ModifiedBy;
                schedule.ModifiedDateTime = DateTime.Now;
                schedule.Teacher_ID = source.Teacher_ID;

                cDBContext.Course_Schedule.Add(schedule);
                cDBContext.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public static List<Course_Schedule> GetSchedulesOf(User user)
        {
            //Return all course_schedules where its teacher_id equals the given user's id.
            var selections = cDBContext.Course_Schedule.Where(s => s.Teacher_ID.Equals(user.User_ID));
            return selections.ToList();
        }
    }

    #region Extensions
    public static class ScheduleExtensions
    {
        public static Course GetCourse(this Course_Schedule context)
        {
            return SharedManager.cDBContext.Courses.FirstOrDefault(c => c.Course_ID.Equals(context.Course_ID));
        }
        public static User GetTutor(this Course_Schedule context)
        {
            return SharedManager.cDBContext.Users.FirstOrDefault(t => t.User_ID.Equals(context.Teacher_ID));
        }
        public static List<Course> ToCourses(this List<Course_Schedule> context)
        {
            List<Course> courses = new List<Course>(context.Count);

            for(int i=0; i<context.Count; i++)
                courses.Add(context[i].GetCourse());

            return courses;
        }
        public static List<User> GetStudents(this Course_Schedule context)
        {
            //This holds student_courses of all students booked on this course_schedule.
            var firstSelection = SharedManager.cDBContext.Student_Course.Where(s => s.CourseSchedule_ID.Equals(context.CourseSchedule_ID));

            List<User> students = new List<User>();
            foreach(Student_Course sc in firstSelection)
            {
                students.Add(sc.GetStudent());
            }
            return students;
        }
    }
    #endregion
    #endregion

    #region Student Course
    public static class StudentCourseManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }


        public static bool Create(Student_Course source)
        {
            try
            {
                Student_Course sc = new Student_Course();

                sc.CourseSchedule_ID = source.CourseSchedule_ID;
                sc.CreatedBy = source.CreatedBy;
                sc.CreatedDateTime = DateTime.Now;
                sc.IsActive = true;
                sc.ModifiedBy = source.ModifiedBy;
                sc.ModifiedDateTime = DateTime.Now;
                sc.User_ID = source.User_ID;

                cDBContext.Student_Course.Add(sc);
                cDBContext.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            
            return true;
        }

        public static List<Student_Course> GetStudentCoursesOf(User user)
        {
            //Return all course_schedules where its teacher_id equals the given user's id.
            var selections = cDBContext.Student_Course.Where(s => s.User_ID.Equals(user.User_ID));
            return selections.ToList();
        }
    }

    #region Extensions
    public static class StudentCourseExtensions
    {
        public static User GetStudent(this Student_Course context)
        {
            return SharedManager.cDBContext.Users.FirstOrDefault(u => u.User_ID.Equals(context.User_ID));
        }
        public static Course_Schedule GetSchedule(this Student_Course context)
        {
            return SharedManager.cDBContext.Course_Schedule.FirstOrDefault(s => s.CourseSchedule_ID.Equals(context.CourseSchedule_ID));
        }
        public static Course GetCourse(this Student_Course context)
        {
            return GetSchedule(context).GetCourse();
        }
    }
    #endregion
    #endregion
}
