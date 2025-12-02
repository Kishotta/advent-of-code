using Spectre.Console.Cli;

namespace AdventOfCode.Infrastructure;

public sealed class TypeResolver : ITypeResolver
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider)
    {
        _provider = provider;
    }

    public object? Resolve(Type? type)
    {
        if (type is null)
        {
            return null;
        }

        return _provider.GetService(type);
    }
}
