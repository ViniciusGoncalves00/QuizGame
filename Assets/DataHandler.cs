public sealed class DataHandler
{
    private static DataHandler _instance = new DataHandler();

    public AllValidQuestions AllValidQuestions { get; }
    public QuestionsToEvaluate QuestionsToEvaluate { get; }
    public ReportedQuestions ReportedQuestions { get; }
    public RemovedQuestions RemovedQuestions { get; }

    private DataHandler()
    {
        AllValidQuestions = new AllValidQuestions();
        QuestionsToEvaluate = new QuestionsToEvaluate(AllValidQuestions);
        ReportedQuestions = new ReportedQuestions(AllValidQuestions);
        RemovedQuestions = new RemovedQuestions(AllValidQuestions);
    }

    public static DataHandler GetInstance()
    {
        return _instance;
    }
}