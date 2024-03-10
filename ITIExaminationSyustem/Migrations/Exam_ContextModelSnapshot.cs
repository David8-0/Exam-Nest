﻿// <auto-generated />
using System;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    [DbContext(typeof(Exam_Context))]
    partial class Exam_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChoiceQuestion", b =>
                {
                    b.Property<int>("Navigation_ChoicesChoice_Id")
                        .HasColumnType("int");

                    b.Property<int>("Navigation_QuestionsQuestion_Id")
                        .HasColumnType("int");

                    b.HasKey("Navigation_ChoicesChoice_Id", "Navigation_QuestionsQuestion_Id");

                    b.HasIndex("Navigation_QuestionsQuestion_Id");

                    b.ToTable("ChoiceQuestion");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("Navigation_CoursesCourse_Id")
                        .HasColumnType("int");

                    b.Property<int>("Navigation_DepartmentsDepartment_Id")
                        .HasColumnType("int");

                    b.HasKey("Navigation_CoursesCourse_Id", "Navigation_DepartmentsDepartment_Id");

                    b.HasIndex("Navigation_DepartmentsDepartment_Id");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesCourse_Id")
                        .HasColumnType("int");

                    b.Property<int>("Navigation_InstructorsInstructor_Id")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourse_Id", "Navigation_InstructorsInstructor_Id");

                    b.HasIndex("Navigation_InstructorsInstructor_Id");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Admin", b =>
                {
                    b.Property<int>("Admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_Id"));

                    b.Property<int>("Admin_Branch_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Admin_User_Id")
                        .HasColumnType("int");

                    b.HasKey("Admin_Id");

                    b.HasIndex("Admin_Branch_Id")
                        .IsUnique();

                    b.HasIndex("Admin_User_Id")
                        .IsUnique()
                        .HasFilter("[Admin_User_Id] IS NOT NULL");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Branch", b =>
                {
                    b.Property<int>("Branch_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Branch_Id"));

                    b.Property<string>("Branch_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Branch_Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.BranchManager", b =>
                {
                    b.Property<int>("Branch_Manager_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Branch_Manager_Id"));

                    b.Property<int?>("Branch_Manager_User_Id")
                        .HasColumnType("int");

                    b.HasKey("Branch_Manager_Id");

                    b.HasIndex("Branch_Manager_User_Id")
                        .IsUnique()
                        .HasFilter("[Branch_Manager_User_Id] IS NOT NULL");

                    b.ToTable("BranchManagers");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Choice", b =>
                {
                    b.Property<int>("Choice_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Choice_Id"));

                    b.Property<string>("Choice_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Choice_Id");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Course", b =>
                {
                    b.Property<int>("Course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_Id"));

                    b.Property<int>("Course_Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Course_Exam_StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Course_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Crs_Exam_Duration")
                        .HasColumnType("int");

                    b.HasKey("Course_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Department", b =>
                {
                    b.Property<int>("Department_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Department_Id"));

                    b.Property<int?>("Brch_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Department_MgrId")
                        .HasColumnType("int");

                    b.Property<int?>("MainDept_Id")
                        .HasColumnType("int");

                    b.HasKey("Department_Id");

                    b.HasIndex("Brch_Id");

                    b.HasIndex("Department_MgrId");

                    b.HasIndex("MainDept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.DepartmentInstructors", b =>
                {
                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Ins_Id")
                        .HasColumnType("int");

                    b.HasKey("Dept_Id", "Ins_Id");

                    b.HasIndex("Ins_Id");

                    b.ToTable("DepartmentInstructors");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Exam", b =>
                {
                    b.Property<int>("Exam_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Exam_Id"));

                    b.Property<int?>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int?>("StudId")
                        .HasColumnType("int");

                    b.HasKey("Exam_Id");

                    b.HasIndex("Crs_Id");

                    b.HasIndex("StudId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.ExamQs", b =>
                {
                    b.Property<int?>("Exam_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Q_Id")
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("Student_Answer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Exam_Id", "Q_Id");

                    b.HasIndex("Q_Id");

                    b.ToTable("ExamQs");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Instructor", b =>
                {
                    b.Property<int>("Instructor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Instructor_Id"));

                    b.Property<int?>("Ins_User_Id")
                        .HasColumnType("int");

                    b.HasKey("Instructor_Id");

                    b.HasIndex("Ins_User_Id")
                        .IsUnique()
                        .HasFilter("[Ins_User_Id] IS NOT NULL");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.MainDepartment", b =>
                {
                    b.Property<int>("MainDepartment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainDepartment_Id"));

                    b.Property<string>("MainDepartment_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainDepartment_Id");

                    b.ToTable("MainDepartments");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Question", b =>
                {
                    b.Property<int>("Question_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Question_Id"));

                    b.Property<int?>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<string>("Question_Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Question_Type")
                        .HasColumnType("int");

                    b.HasKey("Question_Id");

                    b.HasIndex("Crs_Id");

                    b.HasIndex("Question_Type");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.QuestionType", b =>
                {
                    b.Property<int>("QuestionType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionType_Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionType_Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Role", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Role_Id"));

                    b.Property<string>("Role_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_Id"));

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Std_User_Id")
                        .HasColumnType("int");

                    b.HasKey("Student_Id");

                    b.HasIndex("Dept_Id");

                    b.HasIndex("Std_User_Id")
                        .IsUnique()
                        .HasFilter("[Std_User_Id] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.StudentCourse", b =>
                {
                    b.Property<int?>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Std_Id")
                        .HasColumnType("int");

                    b.Property<int>("Bouns")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Ins_Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Std_Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Crs_Id", "Std_Id");

                    b.HasIndex("Std_Id");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.HasIndex("User_Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("Navigation_RolesRole_Id")
                        .HasColumnType("int");

                    b.Property<int>("Navigation_UsersUser_Id")
                        .HasColumnType("int");

                    b.HasKey("Navigation_RolesRole_Id", "Navigation_UsersUser_Id");

                    b.HasIndex("Navigation_UsersUser_Id");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ChoiceQuestion", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Choice", null)
                        .WithMany()
                        .HasForeignKey("Navigation_ChoicesChoice_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("Navigation_QuestionsQuestion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("Navigation_CoursesCourse_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("Navigation_DepartmentsDepartment_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourse_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("Navigation_InstructorsInstructor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Admin", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Branch", "Navigation_Branch")
                        .WithOne("Navigation_Admin")
                        .HasForeignKey("ITIExaminationSyustem.Models.Admin", "Admin_Branch_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.User", "Navigation_User")
                        .WithOne("Navigation_Admin")
                        .HasForeignKey("ITIExaminationSyustem.Models.Admin", "Admin_User_Id");

                    b.Navigation("Navigation_Branch");

                    b.Navigation("Navigation_User");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.BranchManager", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.User", "Navigation_User")
                        .WithOne("Navigation_BranchManager")
                        .HasForeignKey("ITIExaminationSyustem.Models.BranchManager", "Branch_Manager_User_Id");

                    b.Navigation("Navigation_User");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Department", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Branch", "Navigation_Branch")
                        .WithMany("Navigation_Departments")
                        .HasForeignKey("Brch_Id");

                    b.HasOne("ITIExaminationSyustem.Models.Instructor", "Navigation_Department_Manager_Instructor")
                        .WithMany("Departments")
                        .HasForeignKey("Department_MgrId");

                    b.HasOne("ITIExaminationSyustem.Models.MainDepartment", "Navigation_MainDepartment")
                        .WithMany("Navigation_Departments")
                        .HasForeignKey("MainDept_Id");

                    b.Navigation("Navigation_Branch");

                    b.Navigation("Navigation_Department_Manager_Instructor");

                    b.Navigation("Navigation_MainDepartment");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.DepartmentInstructors", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Department", "Navigation_Department")
                        .WithMany("Navigation_Department_Instructor")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Instructor", "Navigation_Instructor")
                        .WithMany("Navigation_Department_Instructor")
                        .HasForeignKey("Ins_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Navigation_Department");

                    b.Navigation("Navigation_Instructor");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Exam", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Course", "Navigation_Course")
                        .WithMany("Navigation_Exam")
                        .HasForeignKey("Crs_Id");

                    b.HasOne("ITIExaminationSyustem.Models.Student", "Navigation_Student")
                        .WithMany("Navigation_StudentExam")
                        .HasForeignKey("StudId");

                    b.Navigation("Navigation_Course");

                    b.Navigation("Navigation_Student");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.ExamQs", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Exam", "Navigation_Exam")
                        .WithMany("Navigation_ExamQs")
                        .HasForeignKey("Exam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Question", "Navigation_Question")
                        .WithMany("Navigation_ExamQs")
                        .HasForeignKey("Q_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Navigation_Exam");

                    b.Navigation("Navigation_Question");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Instructor", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.User", "Navigation_User")
                        .WithOne("Navigation_Instructor")
                        .HasForeignKey("ITIExaminationSyustem.Models.Instructor", "Ins_User_Id");

                    b.Navigation("Navigation_User");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Question", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Course", "Navigation_Course")
                        .WithMany("Navigation_Question")
                        .HasForeignKey("Crs_Id");

                    b.HasOne("ITIExaminationSyustem.Models.QuestionType", "Navigation_QuestionType")
                        .WithMany("Navigation_Question")
                        .HasForeignKey("Question_Type");

                    b.Navigation("Navigation_Course");

                    b.Navigation("Navigation_QuestionType");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Student", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Department", "Navigation_Department")
                        .WithMany("Navigation_Students")
                        .HasForeignKey("Dept_Id");

                    b.HasOne("ITIExaminationSyustem.Models.User", "Navigation_User")
                        .WithOne("Navigation_Student")
                        .HasForeignKey("ITIExaminationSyustem.Models.Student", "Std_User_Id");

                    b.Navigation("Navigation_Department");

                    b.Navigation("Navigation_User");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.StudentCourse", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Course", "Navigation_Course")
                        .WithMany("Navigation_StudentCourses")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.Student", "Navigation_Student")
                        .WithMany("Navigation_StudentCourses")
                        .HasForeignKey("Std_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Navigation_Course");

                    b.Navigation("Navigation_Student");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("ITIExaminationSyustem.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("Navigation_RolesRole_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIExaminationSyustem.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Navigation_UsersUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Branch", b =>
                {
                    b.Navigation("Navigation_Admin");

                    b.Navigation("Navigation_Departments");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Course", b =>
                {
                    b.Navigation("Navigation_Exam");

                    b.Navigation("Navigation_Question");

                    b.Navigation("Navigation_StudentCourses");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Department", b =>
                {
                    b.Navigation("Navigation_Department_Instructor");

                    b.Navigation("Navigation_Students");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Exam", b =>
                {
                    b.Navigation("Navigation_ExamQs");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Instructor", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Navigation_Department_Instructor");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.MainDepartment", b =>
                {
                    b.Navigation("Navigation_Departments");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Question", b =>
                {
                    b.Navigation("Navigation_ExamQs");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.QuestionType", b =>
                {
                    b.Navigation("Navigation_Question");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.Student", b =>
                {
                    b.Navigation("Navigation_StudentCourses");

                    b.Navigation("Navigation_StudentExam");
                });

            modelBuilder.Entity("ITIExaminationSyustem.Models.User", b =>
                {
                    b.Navigation("Navigation_Admin");

                    b.Navigation("Navigation_BranchManager");

                    b.Navigation("Navigation_Instructor");

                    b.Navigation("Navigation_Student");
                });
#pragma warning restore 612, 618
        }
    }
}
