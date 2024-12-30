using System.Collections;

public enum RequestTypes {
    Difficulty1,
    Difficulty2,
    Difficulty3,
}

public class SupportCenter {
    private static readonly Dictionary<RequestTypes, int> TimePerRequest = new Dictionary<RequestTypes, int>()
    {
        {RequestTypes.Difficulty1, 5000}, {RequestTypes.Difficulty2, 10000}, {RequestTypes.Difficulty3, 20000}
    };//Dictionary to dicate how long it takes for each request type(ms)


    //The threads display the workers in the support center
    private Thread thread1;
    private Thread thread2;
    private Thread thread3;

    private Queue<Customer> customers;//The customers in the center

    public SupportCenter(){
        customers = new Queue<Customer>();
    }

    public void AddCustomer(Customer customer){//Adds a customer to the support center queue
        customers.Enqueue(customer);
    }

    public void StartProcessingAll(){//Starts processing all of the customers that are currently in the queue
        while(customers.Count > 0){
            if(thread1 == null || !thread1.IsAlive){//Checks if the thread is done/available
                thread1 = new Thread(ProcessRequest);//Creates a new thread
                thread1.Start();//Starts the work
                continue;//goes to the next iteration of the while to make sure there's still customers left
            }
            if(thread2 == null || !thread2.IsAlive){//If thread 1 was unavailable runs the same as thread2
                thread2 = new Thread(ProcessRequest);
                thread2.Start();
            }
            if(thread3 == null || !thread3.IsAlive){//If thread 1 was unavailable runs the same as thread2
                thread3 = new Thread(ProcessRequest);
                thread3.Start();
            }
            //While isAlive also shows when a thread is ready but has not started yet, I didn't initialize the therads with the constructor but rather initialize them and start them immediatly
            //therefore there is never a time when they are ready but get overrun.
            
            
        }
    }

    private void ProcessRequest(){
        Customer current = customers.Dequeue();//Takes the first customer and dequeues it

        Console.WriteLine($"Processing {current.Name}");
        if(current.SpecialRequest){
            Console.WriteLine("Calling Manager");
            Thread.Sleep(5000);
            Console.WriteLine("Manager Called");
        }
        Thread.Sleep(TimePerRequest[current.Request]);//Processes it for the time according to the dictionary
        Console.WriteLine($"Done processing {current.Name}");

    }



}