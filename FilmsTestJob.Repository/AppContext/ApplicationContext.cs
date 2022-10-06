namespace FilmsTestJob.Repository.AppContext;

public class ApplicationContext
{
    public ApplicationContext() : base()
    {
        
    }
    
    public static readonly HttpClient Http = new HttpClient();
}