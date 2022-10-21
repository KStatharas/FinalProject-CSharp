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
                TeacherDTO tDTO = t as TeacherDTO;
                Teacher teacher = new()
                {
                    Id = tDTO.Id,
                    Firstname = tDTO.Firstname,
                    Lastname = tDTO.Lastname,
                };
                genericDAO.Add(teacher);
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
                genericDAO.Add(student);
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
                genericDAO.Add(course);
            }
            else if (typeof(T) is StudentCourseDTO)
            {
                StudentCourseDTO tDTO = t as StudentCourseDTO;
                StudentCourse studentCourse = new()
                {
                    StudentId = tDTO.StudentId,
                    CourseId = tDTO.CourseId
                };
                genericDAO.Add(studentCourse);
            }

        }

        public void DeleteEntity<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllEntities<T>()
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity<T>(T t)
        {
            throw new NotImplementedException();
        }


        //private T convertDTO<T>(T t)
        //{
        //    if (typeof(T) is TeacherDTO)
        //    {

        //        return new Teacher()
        //        {
        //            Firstname = t.Firstname,
        //            LastName = t.LastName,
        //            Id = t.Id,
        //            Courses = t.Courses
        //        };
        //    }

        //    else if (typeof(T) is StudentDTO)
        //    {
        //    }
        //    else if (typeof(T) is CourseDTO)
        //    {
        //        _context.Course.Add((Course)(object)t);
        //    }
        //    else if (typeof(T) is StudentCourseDTO)
        //    {
        //        _context.StudentCourse.Add((StudentCourse)(object)t);
        //    }
        //}
    }
}
