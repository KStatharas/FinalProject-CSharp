using Microsoft.EntityFrameworkCore;
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
                Teacher result = convertDTO<T,Teacher>(t);
                genericDAO.Add(result);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student result = convertDTO<T, Student>(t);
                genericDAO.Add(result);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course result = convertDTO<T,Course>(t);
                genericDAO.Add(result);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse result = convertDTO<T,StudentCourse>(t);
                genericDAO.Add(result);
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

        public T GetEntity<T>(int id)
        {
            return genericDAO.Get<T>(id);
        }

        public void UpdateEntity<T>(T t)
        {
            if (typeof(T) == typeof(TeacherDTO))
            {
                Teacher result = convertDTO<T, Teacher>(t);
                genericDAO.Update(result);
            }
            else if (typeof(T) == typeof(StudentDTO))
            {
                Student result = convertDTO<T,Student>(t);
                genericDAO.Update(result);
            }
            else if (typeof(T) == typeof(CourseDTO))
            {
                Course result = convertDTO<T, Course>(t);
                genericDAO.Update(result);
            }
            else if (typeof(T) == typeof(StudentCourseDTO))
            {
                StudentCourse result = convertDTO<T, StudentCourse>(t);
                genericDAO.Update(result);
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
                return (U)(object)student;
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
            else if (typeof(U) == typeof(StudentCourseDTO))
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
