﻿using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class ExamQuestionRepo: IExamQuestionRepo
    {

        private Exam_Context _context;
        public ExamQuestionRepo(Exam_Context examContext)
        {
            _context = examContext;
        }

        public List<ExamQs> GetExamQuestions (int id)

        {
            return _context.ExamQs.Include(eQ => eQ.Navigation_Question)
                                  .ThenInclude(a => a.Navigation_QuestionType)
                                  .Include(a => a.Navigation_Question)
                                  .ThenInclude(a => a.Navigation_Choices)
                                  .Where(a=>a.Exam_Id==id)
                                  .ToList();
        }
        
        public List<ExamQs> GenerateExam(int crsId, int stdId)
        {
            List<ExamQs> examlist = new List<ExamQs>();
            StudentCourse studentCourse = _context.StudentCourses.SingleOrDefault(stdCrs => stdCrs.Std_Id == stdId && stdCrs.Crs_Id == crsId);
            studentCourse.HasTakenExam = true;
            // generate exam 
            var exam = new Exam { Crs_Id = crsId, StudId = stdId, Grade = 0 };
            _context.Exams.Add(exam);
            _context.SaveChanges();
            //add to ExamQs table
            var rand = new Random();
            var course = _context.Courses.Include(a => a.Navigation_Question)
                                         .ThenInclude(a => a.Navigation_QuestionType)
                                         .Include(a => a.Navigation_Question)
                                         .ThenInclude(a => a.Navigation_Choices)
                                         .SingleOrDefault(a => a.Course_Id == crsId);
            var MCQquestions = course.Navigation_Question.Where(a => a.Navigation_QuestionType.Type == "MCQ").ToList();
            var TFQuestions = course.Navigation_Question.Where(a => a.Navigation_QuestionType.Type == "T&F").ToList();
            List<int> QuestionsId = new List<int>();
            
            for(int i =0;i<2;i++)
            {
                bool flag = true;
                Question randQs1 = null;
                Question randQs2 = null;
                while (flag)
                {
                    int randNum = rand.Next(0, MCQquestions.Count);
                     randQs1 = MCQquestions[randNum];

                    randNum = rand.Next(0, TFQuestions.Count);
                     randQs2 = TFQuestions[randNum];

                    if(!QuestionsId.Contains(randQs1.Question_Id) && !QuestionsId.Contains(randQs2.Question_Id))
                    {
                        QuestionsId.Add(randQs1.Question_Id);
                        QuestionsId.Add(randQs2.Question_Id);
                        flag = false;
                    }
                    
                }

                if(randQs1!=null && randQs2 != null)
                {
                    var examQ1 = new ExamQs { Exam_Id = exam.Exam_Id, Q_Id = randQs1.Question_Id, Result = 0 };
                    _context.ExamQs.Add(examQ1);
                    var examQ2 = new ExamQs { Exam_Id = exam.Exam_Id, Q_Id = randQs2.Question_Id, Result = 0 };
                    _context.ExamQs.Add(examQ2);
                    examlist.Add(examQ1);
                    examlist.Add(examQ2);
                }
            }
            _context.SaveChanges();
            return examlist;
        }

        public ExamQs GetByIds(int examId, int questionId)
        {
            return _context.ExamQs.SingleOrDefault(eQ => eQ.Exam_Id == examId && eQ.Q_Id == questionId);
        }

        public void CheckAnswer(ExamQs examQs)
        {
            Question question = _context.Questions.Include(a=>a.Navigation_QuestionType).SingleOrDefault(a => a.Question_Id == examQs.Q_Id);
            Exam exam = _context.Exams.SingleOrDefault(exam => exam.Exam_Id == examQs.Exam_Id);
            StudentCourse studentCourse = _context.StudentCourses.SingleOrDefault(stdCrs => stdCrs.Std_Id == exam.StudId && stdCrs.Crs_Id == exam.Crs_Id);
            if (examQs.Student_Answer == question.Question_Answer)
            {
                examQs.Result = question.Navigation_QuestionType.Degree;
                exam.Grade += examQs.Result;
            }
            studentCourse.Grade = exam.Grade;
            _context.StudentCourses.Update(studentCourse);
            _context.ExamQs.Update(examQs);
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }
    }
}