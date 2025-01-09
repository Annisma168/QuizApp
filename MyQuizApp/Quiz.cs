using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score;

        public Quiz(Question[] questions)
        {
            this._questions = questions;
        }

        

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int numberQuestion = 1;
            foreach (Question question in _questions)
            {
                Console.WriteLine($"\nQuestion {numberQuestion++}: ");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Wrong. The correct answer is {question.Answers[question.CorrectAnswerIndex]}");
                }
            }
            DisplayResults();
        }
        public void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"The Quiz is finished. Your score is: {_score} out of {_questions.Length}");
            double persentage = (double)_score / _questions.Length;
            if (persentage > 0.8) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent work!");
            }
            else if (persentage > 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practising");
            }
            Console.ResetColor();
        }

        public void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);


            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("   ");
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($". {question.Answers[i]}");
            }
        }

        public int GetUserChoice()
        {
            Console.WriteLine("Write your answer(number): ");
            string input = Console.ReadLine();
            int choice = 0;
            if (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine($"Incorrect input. Please use the numbers between 1 and 4:");
                input = Console.ReadLine();
                int.TryParse(input, out choice);
            }
            return choice - 1;//adjusting to 0-indexed array
        }
    }
    
}
