using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using StudentTeacherApp.DAO;
using StudentTeacherApp.Data.Models;
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

        public void AddEntity<T>(T t)
        {

            if (typeof(T) == typeof(TeacherDTO))
            {
                Teacher teacher = convertDTO<T,Teacher>(t);
                genericDAO.Add(teacher);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student student = convertDTO<T, Student>(t);
                genericDAO.Add(student);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course course = convertDTO<T,Course>(t);
                genericDAO.Add(course);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse studentcourse = convertDTO<T,StudentCourse>(t);
                genericDAO.Add(studentcourse);
            }

        }

        public void DeleteEntity<T>(int id)
        {
            genericDAO.Delete<T>(id);
        }

        public List<T> GetAllEntities<T>()
        {
            return genericDAO.GetAll<T>();
        }

        public F GetEntity<F,T>(int id)
        {
            return (F)(object)genericDAO.Get<T>(id);
        }
    

    public void UpdateEntity<T>(T t)
        {
            if (typeof(T) == typeof(TeacherDTO))
            {
                Teacher teacher = convertDTO<T, Teacher>(t);
                genericDAO.Update(teacher);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student student = convertDTO<T,Student>(t);
                genericDAO.Update(student);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course course = convertDTO<T, Course>(t);
                genericDAO.Update(course);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse studentcourse = convertDTO<T, StudentCourse>(t);
                genericDAO.Update(studentcourse);
            }
        }


        private U convertDTO<T,U>(T t)
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


            return result;
        }

    }
}
