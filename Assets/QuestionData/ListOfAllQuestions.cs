using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOfAllQuestions
{
    private static readonly List<Question> QuestionList = new List<Question>();

    public static void AddQuestion(Question question)
    {
        QuestionList.Add(question);
    }

    public static int GetCount()
    {
        return QuestionList.Count;
    }

    public static Question FindQuestionByIndex(int index)
    {
        return QuestionList[index];
    }

    public static Question FindQuestionByID(int id)
    {
        foreach (var question in QuestionList.Where(question => question.ID == id))
        {
            return question;
        }

        throw new Exception("Question not found.");
    }
}