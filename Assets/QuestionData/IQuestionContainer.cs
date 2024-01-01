using System.Collections.Generic;

public interface IQuestionContainer
{
    public List<Question> QuestionList { get; }
}

public sealed class AllValidQuestions : IQuestionContainer
{
    public List<Question> QuestionList { get; } = new List<Question>();
}

public interface IManipulateContainer : IQuestionContainer
{
    public AllValidQuestions AllValidQuestions { get; }
}

public sealed class QuestionsToEvaluate : IManipulateContainer
{
    public AllValidQuestions AllValidQuestions { get; }
    public QuestionsToEvaluate(AllValidQuestions allValidQuestions)
    {
        AllValidQuestions = allValidQuestions;
    }
    
    public List<Question> QuestionList { get; } = new List<Question>();
}

public sealed class ReportedQuestions : IManipulateContainer
{
    public AllValidQuestions AllValidQuestions { get; }
    public ReportedQuestions(AllValidQuestions allValidQuestions)
    {
        AllValidQuestions = allValidQuestions;
    }
    
    public List<Question> QuestionList { get; } = new List<Question>();
}

public sealed class RemovedQuestions : IManipulateContainer
{
    public AllValidQuestions AllValidQuestions { get; }
    public RemovedQuestions(AllValidQuestions allValidQuestions)
    {
        AllValidQuestions = allValidQuestions;
    }
    
    public List<Question> QuestionList { get; } = new List<Question>();
}