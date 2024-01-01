public class QuestionDataManager
{
    public void RelocateQuestion(int id, IManipulateContainer listToRemove, IManipulateContainer listToReceive)
    {
        for (int i = listToRemove.QuestionList.Count - 1; i >= 0; i--)
        {
            var question = listToRemove.QuestionList[i];

            if (id == question.ID)
            {
                listToReceive.QuestionList.Add(question);
                listToRemove.QuestionList.RemoveAt(i);

                break;
            }
        }
    }
}