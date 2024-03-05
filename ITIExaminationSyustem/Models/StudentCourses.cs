﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class StudentCourses
    {
        [ForeignKey("Navigation_Student")]
        public int Std_Id { get; set; }
        [ForeignKey("Navigation_Course")]
        public int Crs_Id { get; set; }
        public int Grade { get; set; }

        #region Navigation property
        public Course Navigation_Course { get; set; }
        public Student Navigation_Student { get; set; }
        #endregion
    }
}
