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
            
            if (typeof(T) is TeacherDTO)
            {
                Teacher result = convertDTO(t) as Teacher;
                genericDAO.Add(result);
            }
            else if (typeof(T) is StudentDTO)
            {
                Student result = convertDTO(t) as Student;
                genericDAO.Add(result);
            }
            else if (typeof(T) is CourseDTO)
            {
                Course result = convertDTO(t) as Course;
                genericDAO.Add(result);
            }
            else if (typeof(T) is StudentCourseDTO)
            {
                StudentCourse result = convertDTO(t) as StudentCourse;
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
            if (typeof(T) is TeacherDTO)
            {
                Teacher result = convertDTO(t) as Teacher;
                genericDAO.Update(result);
            }
            else if (typeof(T) is StudentDTO)
            {
                Student result = convertDTO(t) as Student;
                genericDAO.Update(result);
            }
            else if (typeof(T) is CourseDTO)
            {
                Course result = convertDTO(t) as Course;
                genericDAO.Update(result);
            }
            else if (typeof(T) is StudentCourseDTO)
            {
                StudentCourse result = convertDTO(t) as StudentCourse;
                genericDAO.Update(result);
            }
        }


        private T convertDTO<T>(T t)
        {
            T result = default(T);

            if (typeof(T) is TeacherDTO)
            {
                TeacherDTO tDTO = t as TeacherDTO;
                Teacher teacher = new()
                {
                    Id = tDTO.Id,
                    Firstname = tDTO.Firstname,
                    Lastname = tDTO.Lastname,
                };
                result = (T)(object)teacher;
            }
            else if (typeof(T) is StudentDTO)
            {
                StudentDTO tDTO = t as StudentDTO;
                Student student = new()
                {
                    Id = tDTO.Id,
                    Firstname = tDTO.Firstname,
                    Lastname = tDTO.Lastname,
                };
                result = (T)(object)student;
            }
            else if (typeof(T) is CourseDTO)
            {
                CourseDTO tDTO = t as CourseDTO;
                Course course = new()
                {
                    Id = tDTO.Id,
                    Description = tDTO.Description,
                    TeacherId = tDTO.TeacherId,
                };
                result = (T)(object)course;
            }
            else if (typeof(T) is StudentCourseDTO)
            {
                StudentCourseDTO tDTO = t as StudentCourseDTO;
                StudentCourse studentCourse = new()
                {
                    StudentId = tDTO.StudentId,
                    CourseId = tDTO.CourseId
                };
                result = (T)(object)studentCourse;
            }


            return result;
        }
    }
}
