


public class APImanager {
    private HttpClient httpClient;

    public APImanager(){
        httpClient = new HttpClient();
    }
    public async Task GetCatFact(){
        try{
            HttpResponseMessage response = await httpClient.GetAsync($"https://catfact.ninja/fact");


            response.EnsureSuccessStatusCode();


            string content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
        catch(HttpRequestException e){
            Console.WriteLine($"HTTP error: {e.Message}");
        }
        catch(Exception e){
            Console.WriteLine($"Error: {e.Message}");
        }
        
    }
}