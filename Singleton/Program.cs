// 保证系统中的类只有一个对象
Parallel.For(0, 10, index =>
{
    var id = Singleton.GetInstance().GetId();
    Console.WriteLine(id);
});

class Singleton
{
    private Guid _guid;
    private static Singleton _instance;
    private static object _lock = new object();

    private Singleton()
    {
        _guid = Guid.NewGuid();
    }

    public static Singleton GetInstance()
    {
        if (_instance is null)
        {
            lock (_lock)
            {
                if (_instance is null)
                {
                    _instance = new Singleton();
                }
            }
        }

        return _instance;
    }
    
    public Guid GetId() => _guid;
}