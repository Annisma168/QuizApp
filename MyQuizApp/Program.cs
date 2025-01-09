namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question(
                    "What is the capital of Germany?",  //Qustion Text
                    new string[] { "Madrid", "Berlin", "Rome", "London"}, // answers
                    1 // correct answer
                ),
                new Question(
                    "What is 10+10?",  // Question Text
                    new string[] {"22", "30", "20", "35"}, // Answers Array
                    2 // CorrectAnswerIndex
                ),
                new Question(
                    "Who wrote 'Hamlet'?",  // Question Text
                    new string[] { "Shakespeare", "Goethe", "Tolkien", "Austen"}, // Answers Array
                    0 // CorrectAnswerIndex
                )
            };
        

            Quiz quiz1 = new Quiz(questions);
            quiz1.StartQuiz();

            Console.ReadLine();
        }
    }
}
