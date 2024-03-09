﻿using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IStudentCourseRepo
    {
        List<Course> GetStudentCourses(int id);
        List<Student> GetCourseStudents(int id);
        StudentCourse GetStudentCourseDetails(int studentId, int courseId);
        List<String> GetCourseFeedbacks(int courseId);
        List<String> GetStudentFeedbacks(int studentId, int courseId); //--> for dept manager
        void UpdateStudentFeedback(int studentId, int courseId, string feedback);

    }
}