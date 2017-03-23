using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistration
{
    #region Course
    public static class CourseManager
    {
        public static bool Create(Course source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
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

                    dbContext.Courses.Add(course);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Course> GetAllCourses()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Courses.Where(c => c.IsActive).ToList();
            }
        }

        public static int GetCourseCount()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Courses.Where(c => c.IsActive).Count();
            }
        }
    }

    #region Extensions
    public static class CourseExtensions
    {
        public static Faculty GetFaculty(this Course context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Faculties.FirstOrDefault(f => f.IsActive && f.Faculty_ID.Equals(context.Faculty_ID));
            }
        }
        public static List<Course_Schedule> GetSchedules(this Course context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Course_Schedule.Where(cs => cs.IsActive && cs.Course_ID.Equals(context.Course_ID)).ToList();
            }
        }
    }
    #endregion
    #endregion

    #region Course Schedule
    public static class ScheduleManager
    {
        public static bool Create(Course_Schedule source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                try
                {
                    Course_Schedule schedule = new Course_Schedule();

                    schedule.Course_ID = source.Course_ID;
                    schedule.CreatedBy = source.CreatedBy;
                    schedule.CreatedDateTime = DateTime.Now;
                    schedule.DT_From = source.DT_From;
                    schedule.DT_To = source.DT_To;
                    schedule.IsActive = true;
                    schedule.ModifiedBy = source.ModifiedBy;
                    schedule.ModifiedDateTime = DateTime.Now;
                    schedule.Teacher_ID = source.Teacher_ID;

                    dbContext.Course_Schedule.Add(schedule);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Course_Schedule> GetSchedulesOf(User user, RoleTypes roleType)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                //Check role type
                if (roleType == RoleTypes.Student)
                {
                    //Find all student course object with the user's id
                    var selections = dbContext.Student_Course.Where(sc => sc.User_ID.Equals(user.User_ID) && sc.IsActive);

                    //Convert student_course to course_schedule
                    List<Course_Schedule> courseSchedules = new List<Course_Schedule>();
                    foreach (Student_Course sc in selections)
                    {
                        Course_Schedule cs = sc.GetSchedule();
                        if (cs != null)
                            courseSchedules.Add(cs);
                    }

                    //Return the list
                    return courseSchedules;
                }
                else
                {
                    //Return all course_schedules where its teacher_id equals the given user's id.
                    var selections = dbContext.Course_Schedule.Where(s => s.Teacher_ID.Equals(user.User_ID) && s.IsActive);
                    return selections.ToList();
                }
            }
        }

        public static List<Course_Schedule> GetAllSchedules()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                //Get all schedules and return
                return dbContext.Course_Schedule.Where(cs => cs.IsActive).ToList();
            }
        }
    }

    #region Extensions
    public static class ScheduleExtensions
    {
        public static Course GetCourse(this Course_Schedule context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Courses.FirstOrDefault(c => c.Course_ID.Equals(context.Course_ID) && c.IsActive);
            }
        }
        public static User GetTutor(this Course_Schedule context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Users.FirstOrDefault(t => t.User_ID.Equals(context.Teacher_ID) && t.IsActive);
            }
        }
        public static List<Course> ToCourses(this List<Course_Schedule> context)
        {
            List<Course> courses = new List<Course>(context.Count);

            for (int i = 0; i < context.Count; i++)
            {
                Course course = context[i].GetCourse();
                if (course != null)
                    courses.Add(course);
            }

            return courses;
        }
        public static List<User> GetStudents(this Course_Schedule context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                //This holds student_courses of all students booked on this course_schedule.
                var firstSelection = dbContext.Student_Course.Where(s => s.CourseSchedule_ID.Equals(context.CourseSchedule_ID) && s.IsActive);

                List<User> students = new List<User>();
                foreach (Student_Course sc in firstSelection)
                {
                    User user = sc.GetStudent();
                    if (user != null)
                        students.Add(user);
                }
                return students;
            }
        }
        public static List<Student_Course> GetStudentCourses(this Course_Schedule context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Student_Course.Where(sc => sc.IsActive && sc.CourseSchedule_ID.Equals(context.CourseSchedule_ID)).ToList();
            }
        }
    }
    #endregion
    #endregion

    #region Student Course
    public static class StudentCourseManager
    {
        public static bool Create(Student_Course source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
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
                    sc.Grade = source.Grade;

                    dbContext.Student_Course.Add(sc);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Student_Course> GetStudentCoursesOf(User user)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                //Return all course_schedules where its teacher_id equals the given user's id.
                var selections = dbContext.Student_Course.Where(s => s.User_ID.Equals(user.User_ID) && s.IsActive);
                return selections.ToList();
            }
        }
    }

    #region Extensions
    public static class StudentCourseExtensions
    {
        public static User GetStudent(this Student_Course context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Users.FirstOrDefault(u => u.User_ID.Equals(context.User_ID) && u.IsActive);
            }
        }
        public static Course_Schedule GetSchedule(this Student_Course context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Course_Schedule.FirstOrDefault(s => s.IsActive && s.CourseSchedule_ID.Equals(context.CourseSchedule_ID));
            }
        }
        public static Course GetCourse(this Student_Course context)
        {
            return GetSchedule(context).GetCourse();
        }
    }
    #endregion
    #endregion
}
