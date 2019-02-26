using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Model
{
    public class Model : DbContext
    {
        bool IsInitialize = false;
        bool IsRecreate = false;

        public DbSet<Survey> SurveyList { get; set; }
        public DbSet<Question> QuestionList { get; set; }
        public DbSet<Answer> AnswerList { get; set; }

        public Model(DbContextOptions<Model> options) : base(options)
        {
            if (IsRecreate)
            {
                Recreate();
            }
            if (IsInitialize)
            {
                Initialize();
            }
        }
        public static Model ModelFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Model>();
            var connectionString = "Server=LAPTOP-73MHSR7G\\SQLEXPRESS;Database=SurveysDataBase;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
            return new Model(optionsBuilder.Options);
        }
        void Recreate()
        {
            this.Database.EnsureCreated();
        }
        void Initialize()
        {
            Console.WriteLine("Initialize()<-------------------------------------------------------//");

            this.SurveyList.Add(survey1);
            this.SurveyList.Add(survey2);

            this.QuestionList.Add(question1);
            this.QuestionList.Add(question2);
            this.QuestionList.Add(question3);
            this.QuestionList.Add(question4);

            this.AnswerList.Add(answer1);
            this.AnswerList.Add(answer2);
            this.AnswerList.Add(answer3);
            this.AnswerList.Add(answer4);
            this.AnswerList.Add(answer5);
            this.AnswerList.Add(answer6);
            this.AnswerList.Add(answer7);
            this.AnswerList.Add(answer8);

            this.SaveChanges();
        }
        public Survey survey1 = new Survey() { SurveyName = "Survey for owls", CreatorName = "Nikita", CreationDay = 25, CreationMonth = 2, CreationYear = 2019 };
        public Survey survey2 = new Survey() { SurveyName = "Survey for larks", CreatorName = "Nikita", CreationDay = 25, CreationMonth = 2, CreationYear = 2019 };

        public Question question1 = new Question() { QuestionDescription = "How early do you get up?", AdditionalInformation = "In what time?" };
        public Question question2 = new Question() { QuestionDescription = "What do you eat on breakfast?", AdditionalInformation = "For example?" };
        public Question question3 = new Question() { QuestionDescription = "How late do you go to sleep?", AdditionalInformation = "In what time?" };
        public Question question4 = new Question() { QuestionDescription = "What do you eat on dinner?", AdditionalInformation = "For example?" };

        public Answer answer1 = new Answer() { AnswerDescription = "before 6 a.m." };
        public Answer answer2 = new Answer() { AnswerDescription = "after 6 a.m." };
        public Answer answer3 = new Answer() { AnswerDescription = "omlet" };
        public Answer answer4 = new Answer() { AnswerDescription = "porridge" };
        public Answer answer5 = new Answer() { AnswerDescription = "before midnight" };
        public Answer answer6 = new Answer() { AnswerDescription = "after midnight" };
        public Answer answer7 = new Answer() { AnswerDescription = "steak with beer" };
        public Answer answer8 = new Answer() { AnswerDescription = "i'm trying to drop my weight" };
    }
}
