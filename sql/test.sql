/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     2021/1/4 22:34:18                            */
/*==============================================================*/


alter table class
   drop constraint FK_CLASS_REFERENCE_TEACHER;

alter table sc_choose
   drop constraint FK_SC_CHOOS_REFERENCE_COURSE;

alter table sc_choose
   drop constraint FK_SC_CHOOS_REFERENCE_STUDENT;

alter table sc_choose
   drop constraint FK_SC_CHOOS_REFERENCE_TEACHER_;

alter table student
   drop constraint FK_STUDENT_REFERENCE_CLASS;

alter table teacher_group
   drop constraint FK_TEACHER__REFERENCE_TEACHER;

alter table teacher_group
   drop constraint FK_TEACHER__REFERENCE_COURSE;

drop table class cascade constraints;

drop table course cascade constraints;

drop table sc_choose cascade constraints;

drop table student cascade constraints;

drop table teacher cascade constraints;

drop table teacher_group cascade constraints;

/*==============================================================*/
/* Table: class                                                 */
/*==============================================================*/
create table class 
(
   class_id             NUMBER(10)           not null,
   teacher_id           NUMBER(10)           not null,
   class_name           VARCHAR(10),
   class_headmaster     NUMBER(10),
   constraint PK_CLASS primary key (class_id, teacher_id)
);

/*==============================================================*/
/* Table: course                                                */
/*==============================================================*/
create table course 
(
   course_id            NUMBER(10)           not null,
   course_name          VARCHAR(20)          not null,
   course_type          CHAR(10),
   course_investigate   CHAR(10),
   course_credit        INT,
   course_class         INT,
   constraint PK_COURSE primary key (course_id)
);

/*==============================================================*/
/* Table: sc_choose                                             */
/*==============================================================*/
create table sc_choose 
(
   course_id            NUMBER(10)           not null,
   student_id           NUMBER(10)           not null,
   teacher_id           NUMBER(10),
   tea_course_id        NUMBER(10),
   grade                FLOAT,
   constraint PK_SC_CHOOSE primary key (course_id, student_id)
);

/*==============================================================*/
/* Table: student                                               */
/*==============================================================*/
create table student 
(
   student_id           NUMBER(10)           not null,
   class_id             NUMBER(10),
   teacher_id           NUMBER(10),
   student_name         VARCHAR(20)          not null,
   student_sex          CHAR(8),
   student_password     VARCHAR(20)          not null,
   constraint PK_STUDENT primary key (student_id)
);

/*==============================================================*/
/* Table: teacher                                               */
/*==============================================================*/
create table teacher 
(
   teacher_id           NUMBER(10)           not null,
   teacher_name         VARCHAR(20)          not null,
   teacher_position     VARCHAR(20),
   teacher_password     NUMBER(10)           not null,
   constraint PK_TEACHER primary key (teacher_id)
);

/*==============================================================*/
/* Table: teacher_group                                         */
/*==============================================================*/
create table teacher_group 
(
   teacher_id           NUMBER(10)           not null,
   course_id            NUMBER(10)           not null,
   constraint PK_TEACHER_GROUP primary key (teacher_id, course_id)
);

alter table class
   add constraint FK_CLASS_REFERENCE_TEACHER foreign key (teacher_id)
      references teacher (teacher_id);

alter table sc_choose
   add constraint FK_SC_CHOOS_REFERENCE_COURSE foreign key (course_id)
      references course (course_id);

alter table sc_choose
   add constraint FK_SC_CHOOS_REFERENCE_STUDENT foreign key (student_id)
      references student (student_id);

alter table sc_choose
   add constraint FK_SC_CHOOS_REFERENCE_TEACHER_ foreign key (teacher_id, tea_course_id)
      references teacher_group (teacher_id, course_id);

alter table student
   add constraint FK_STUDENT_REFERENCE_CLASS foreign key (class_id, teacher_id)
      references class (class_id, teacher_id);

alter table teacher_group
   add constraint FK_TEACHER__REFERENCE_TEACHER foreign key (teacher_id)
      references teacher (teacher_id);

alter table teacher_group
   add constraint FK_TEACHER__REFERENCE_COURSE foreign key (course_id)
      references course (course_id);

