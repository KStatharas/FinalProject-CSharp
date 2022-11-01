using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using StudentTeacherApp.DAO;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Models;
using System.Collections.Generic;

namespace StudentTeacherApp.Service
{
    public class GenericServiceImpl : IGenericService
    {

        private IGenericDAO genericDAO;

        public GenericServiceImpl(IGenericDAO genericDAO)
        {
            this.genericDAO = genericDAO;
        }

        public int AddEntity<T>(T t)
        {
            int id = 0;

            if (typeof(T) == typeof(TeacherDTO))
            {
                Teacher teacher = ConvertDTO<T, Teacher>(t);
                id = genericDAO.Add(teacher);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student student = ConvertDTO<T, Student>(t);
                id = genericDAO.Add(student);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course course = ConvertDTO<T, Course>(t);
                id = genericDAO.Add(course);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse studentcourse = ConvertDTO<T, StudentCourse>(t);
                id = genericDAO.Add(studentcourse);
            }
            else if (typeof(T) == typeof(AdminDTO))
            {
                Admin admin = ConvertDTO<T, Admin>(t);
                id = genericDAO.Add(admin);
            }
            else if (typeof(T) == typeof(UserDTO))
            {
                User user = ConvertDTO<T, User>(t);
                id = genericDAO.Add(user);
            }

            return id;
        }

        public void DeleteEntity<T>(int id) => genericDAO.Delete<T>(id);

        public List<T> GetAllEntities<T>() => genericDAO.GetAll<T>();


        public F GetEntity<F, T>(int id)
        {
            
            var daoResult = genericDAO.Get<T>(id);
            if (daoResult is null) return default(F);

            F entity = ConvertModel<T,F>(daoResult);
            return entity;
        }


        public void UpdateEntity<T>(T t)
        {
            if (typeof(T) == typeof(TeacherDTO))
            {
                Teacher teacher = ConvertDTO<T, Teacher>(t);
                genericDAO.Update(teacher);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student student = ConvertDTO<T, Student>(t);
                genericDAO.Update(student);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course course = ConvertDTO<T, Course>(t);
                genericDAO.Update(course);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse studentcourse = ConvertDTO<T, StudentCourse>(t);
                genericDAO.Update(studentcourse);
            }
            else if (typeof(T) == typeof(AdminDTO))
            {
                Admin admin = ConvertDTO<T, Admin>(t);
                genericDAO.Update(admin);
            }
            else if (typeof(T) == typeof(UserDTO))
            {
                User user = ConvertDTO<T, User>(t);
                genericDAO.Update(user);
            }
        }


        private U ConvertDTO<T, U>(T t)
        {
            U result = default;

            if (typeof(T) == typeof(TeacherDTO))
            {
                TeacherDTO tDTO = t as TeacherDTO;
                Teacher teacher = new()
                {
                    Id = tDTO.Id,
                    Firstname = tDTO.Firstname,
                    Lastname = tDTO.Lastname,
                };
                result = (U)(object)teacher;
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                StudentDTO tDTO = t as StudentDTO;
                Student student = new()
                {
                    Id = tDTO.Id,
                    Firstname = tDTO.Firstname,
                    Lastname = tDTO.Lastname,
                };
                result = (U)(object)student;
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                CourseDTO tDTO = t as CourseDTO;
                Course course = new()
                {
                    Id = tDTO.Id,
                    Description = tDTO.Description,
                    TeacherId = tDTO.TeacherId,
                };
                result = (U)(object)course;
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourseDTO tDTO = t as StudentCourseDTO;
                StudentCourse studentCourse = new()
                {
                    StudentId = tDTO.StudentId,
                    CourseId = tDTO.CourseId
                };
                result = (U)(object)studentCourse;
            }
            else if (typeof(T) == typeof(AdminDTO))
            {
                AdminDTO aDTO = t as AdminDTO;
                Admin admin = new()
                {
                    Id = aDTO.Id,
                    Firstname = aDTO.Firstname,
                    Lastname = aDTO.Lastname
                };
                result = (U)(object)admin;
            }
            else if (typeof(T) == typeof(UserDTO))
            {
                UserDTO uDTO = t as UserDTO;
                User user = new()
                {
                    Id = uDTO.Id,
                    Username = uDTO.Username,
                    Password = uDTO.Password,
                    Type = uDTO.Type
                };
                result = (U)(object)user;
            }


            return result;
        }


        private T ConvertModel<U,T>(U u)
        {
            T result = default;

            if (typeof(U) == typeof(Teacher))
            {
                Teacher teacher = u as Teacher;
                TeacherDTO teacherDTO = new()
                {
                    Id = teacher.Id,
                    Firstname = teacher.Firstname,
                    Lastname = teacher.Lastname,
                };
                result = (T)(object)teacherDTO;
            }
            else if (typeof(U) == typeof(Student))
            {
                Student student = u as Student;
                StudentDTO studentDTO = new()
                {
                    Id = student.Id,
                    Firstname = student.Firstname,
                    Lastname = student.Lastname,
                };
                result = (T)(object)studentDTO;
            }
            else if (typeof(U) == typeof(Course))
            {
                Course course = u as Course;
                CourseDTO courseDTO = new()
                {
                    Id = course.Id,
                    Description = course.Description,
                    TeacherId = course.TeacherId,
                };
                result = (T)(object)courseDTO;
            }
            else if (typeof(U) == typeof(StudentCourse))
            {
                StudentCourse studentcourse = u as StudentCourse;
                StudentCourseDTO studentCourseDTO = new()
                {
                    StudentId = studentcourse.StudentId,
                    CourseId = studentcourse.CourseId
                };
                result = (T)(object)studentCourseDTO;
            }
            else if (typeof(U) == typeof(Admin))
            {
                Admin admin = u as Admin;
                AdminDTO adminDTO = new()
                {
                    Id = admin.Id,
                    Firstname = admin.Firstname,
                    Lastname = admin.Lastname
                };
                result = (T)(object)adminDTO;
            }
            else if (typeof(U) == typeof(User))
            {
                User user = u as User;
                UserDTO userDTO = new()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Type = user.Type
                };
                result = (T)(object)userDTO;
            }

            return result;
        }

    }

}
