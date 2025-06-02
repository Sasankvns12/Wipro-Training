using System;
using System.Collections.Generic;
using System.Linq;

public class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public int CorrectAnswerIndex { get; set; }

    public Question(string text, List<string> options, int correctAnswerIndex)
    {
        Text = text;
        Options = options;
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public void DisplayQuestion()
    {
        Console.WriteLine(Text);
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }

    public bool CheckAnswer(int userAnswer)
    {
        return userAnswer - 1 == CorrectAnswerIndex;
    }
}

class QuizProgram
{
    static void Main(string[] args)
    {
        // Create a list of questions
        List<Question> questions = new List<Question>
        {
            new Question("What is the capital of France?", 
                new List<string> { "London", "Paris", "Berlin", "Madrid" }, 1),
            new Question("Which planet is known as the Red Planet?", 
                new List<string> { "Venus", "Mars", "Jupiter", "Saturn" }, 1),
            new Question("What is 2 + 2?", 
                new List<string> { "3", "4", "5", "6" }, 1),
            new Question("Who painted the Mona Lisa?", 
                new List<string> { "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Michelangelo" }, 2),
            new Question("What is the largest mammal?", 
                new List<string> { "Elephant", "Blue Whale", "Giraffe", "Polar Bear" }, 1),
            new Question("Which language is this program written in?", 
                new List<string> { "Java", "Python", "C#", "JavaScript" }, 2),
            new Question("What year did World War II end?", 
                new List<string> { "1943", "1945", "1947", "1950" }, 1)
        };

        Console.WriteLine("Welcome to the Quiz Game!");
        Console.WriteLine($"There are {questions.Count} questions available.");
        Console.Write("How many questions would you like to answer? ");
        
        int numberOfQuestions;
        while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || 
               numberOfQuestions <= 0 || 
               numberOfQuestions > questions.Count)
        {
            Console.Write($"Please enter a number between 1 and {questions.Count}: ");
        }

        // Select random questions
        Random random = new Random();
        var selectedQuestions = questions.OrderBy(q => random.Next()).Take(numberOfQuestions).ToList();

        int score = 0;
        int questionNumber = 1;

        Console.WriteLine("\nLet's begin!\n");

        foreach (var question in selectedQuestions)
        {
            Console.WriteLine($"Question {questionNumber} of {numberOfQuestions}:");
            question.DisplayQuestion();
            
            Console.Write("Your answer (enter the number): ");
            int userAnswer;
            while (!int.TryParse(Console.ReadLine(), out userAnswer) || 
                   userAnswer < 1 || 
                   userAnswer > question.Options.Count)
            {
                Console.Write($"Please enter a number between 1 and {question.Options.Count}: ");
            }

            if (question.CheckAnswer(userAnswer))
            {
                Console.WriteLine("Correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect! The correct answer was: {question.Options[question.CorrectAnswerIndex]}\n");
            }

            questionNumber++;
        }

        // Display results
        Console.WriteLine("Quiz Complete!");
        Console.WriteLine($"You scored {score} out of {numberOfQuestions} ({score * 100 / numberOfQuestions}%)");

        // Performance comment
        string[] comments = {
            "Excellent work!",
            "Good job!",
            "Not bad!",
            "You might want to brush up on your knowledge.",
            "Better luck next time!"
        };

        int commentIndex = score == numberOfQuestions ? 0 : 
                          score >= numberOfQuestions * 0.75 ? 1 :
                          score >= numberOfQuestions * 0.5 ? 2 :
                          score >= numberOfQuestions * 0.25 ? 3 : 4;

        Console.WriteLine(comments[commentIndex]);
    }
}