﻿namespace StudentTeacherApp.Data.Models
{
    public interface IUser
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
