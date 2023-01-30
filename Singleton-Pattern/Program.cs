
#region Main Region

using System;

var b1 = LoadBalancer.GetLoadBalancer();
var b2 = LoadBalancer.GetLoadBalancer();
var b3 = LoadBalancer.GetLoadBalancer();
var b4 = LoadBalancer.GetLoadBalancer();

// check same instance 
if (b1 == b2 && b2 == b3 && b3 == b4)
{
    Console.WriteLine("Same instance");
}

// Let's try to get 10 request for server
var balancer=LoadBalancer.GetLoadBalancer();
for (int i = 0; i < 10; i++)
{
   Console.WriteLine($"Request running on server: {balancer.NextServer.Name}");
}


#endregion


/// <summary>
/// Singleton class
/// </summary>
class LoadBalancer
{
    static LoadBalancer? instance;

    List<Server> Servers = new();

    Random random= new Random();

    private LoadBalancer()
    {
        Servers = new List<Server>{
            new Server { IP="120.19.10.01", Name="Server 1" },
            new Server { IP="120.19.10.02", Name="Server 2" },
            new Server { IP="120.19.10.03", Name="Server 3" },
            new Server { IP="120.19.10.04", Name="Server 4" },
            new Server { IP="120.19.10.05", Name="Server 5" },
        };
    }

    public static LoadBalancer GetLoadBalancer() => instance ??= new();

    public Server NextServer
    {
        get
        {
            int r = random.Next(Servers.Count);
            return Servers[r];
        }
    }
}


class Server
{
    public string Name { get; set; } = string.Empty;
    public string IP { get; set; } = string.Empty;
}