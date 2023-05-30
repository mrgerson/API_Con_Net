public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "bienvenido Gerson Calvo!";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}