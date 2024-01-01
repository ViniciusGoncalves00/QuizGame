public sealed class DataHandler
{
    private static DataHandler Instance = new DataHandler();

    public AllValidQuestions AllValidQuestions { get; }
    public QuestionsToEvaluate QuestionsToEvaluate { get; }
    public ReportedQuestions ReportedQuestions { get; }
    public RemovedQuestions RemovedQuestions { get; }
    
    public QuizCreator QuizCreator { get; }
    public QuestionCreator QuestionCreator { get; }

    private DataHandler()
    {
        AllValidQuestions = new AllValidQuestions();
        QuestionsToEvaluate = new QuestionsToEvaluate(AllValidQuestions);
        ReportedQuestions = new ReportedQuestions(AllValidQuestions);
        RemovedQuestions = new RemovedQuestions(AllValidQuestions);
        
        QuizCreator = new QuizCreator();
        QuestionCreator = new QuestionCreator();
    }

    public static DataHandler GetInstance()
    {
        return Instance;
    }
}