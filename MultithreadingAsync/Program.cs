




public class Program{
    public static async Task Main(string[] args){
        ShowSupportCenter();
        await ShowAsyncAPICalls();
    }


    public static void ShowSupportCenter(){
        Customer John = new Customer("John", RequestTypes.Difficulty1,true);
        Customer Dave = new Customer("Dave", RequestTypes.Difficulty2, false);
        Customer Clint = new Customer("Clint", RequestTypes.Difficulty3, true);
        Customer Brann = new Customer("Brann", RequestTypes.Difficulty3, true);
        Customer Jaina = new Customer("Jaina", RequestTypes.Difficulty3, true);


        SupportCenter supportCenter = new SupportCenter();

        supportCenter.AddCustomer(John);
        supportCenter.AddCustomer(Dave);
        supportCenter.AddCustomer(Clint);
        supportCenter.AddCustomer(Brann);
        supportCenter.AddCustomer(Jaina);

        supportCenter.StartProcessingAll();
    }

    public static async Task ShowAsyncAPICalls(){
        APImanager APImanager = new APImanager();

        Console.WriteLine("How many cat facts would you like");
        string? input = Console.ReadLine();
        List<Task> tasks = new List<Task>();
        if (input != null && int.TryParse(input, out int number))
        {
            for (int i = 0; i < number; i++)
            {
                tasks.Add(APImanager.GetCatFact());
            }
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("Done showing cat facts");

    }
}
