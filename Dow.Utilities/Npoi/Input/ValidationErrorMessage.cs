namespace Dow.Utilities.Npoi.Input
{
    public class ValidationErrorMessage
    {
        public ValidationErrorMessage(string title,string context)
        {
            Title = title;
            Context = context;
        }

        public string Title { get; private set; }

        public string Context { get; private set; }
    }
}
