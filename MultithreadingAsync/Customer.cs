

public class Customer {
    public string Name {get; private set;}

    public RequestTypes Request{get; private set;}

    public bool SpecialRequest{get; private set;}


    public Customer(string name, RequestTypes request, bool specialRequest){
        Name = name;
        Request = request;
        SpecialRequest = specialRequest;
    }

    
}