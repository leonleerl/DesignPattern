// 策略模式
// 定义一系列的算法类，按每个算法分别封装起来，让它们可以相互替换。也就是依赖注入，IoC
// 安装Extensions.DependencyInjection

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<IRepository, RedisRepository>();
services.AddScoped<AppService>();
var builder = services.BuildServiceProvider();
var appService = builder.GetRequiredService<AppService>();
appService.Create("Jerry");

public interface IRepository
{
    void Add(object entity);
}

public class EFCoreRepository : IRepository
{
    public void Add(object entity)
    {
        Console.WriteLine($"EFCore Repository add {entity}");
    }
}

public class RedisRepository : IRepository
{
    public void Add(object entity)
    {
        Console.WriteLine($"Redis Repository add {entity}");
    }
}

public class AppService
{
    private readonly IRepository _repository;

    public AppService(IRepository repository)
    {
        _repository = repository;
    }

    public void Create(object entity)
    {
        _repository.Add(entity);
    }
}