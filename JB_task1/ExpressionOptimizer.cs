namespace JB_task1;

public class ExpressionOptimizer
{
    private readonly Dictionary<IExpression, IExpression> _cache = new();

    public IExpression Optimize(IExpression expression)
    {
        if (_cache.TryGetValue(expression, out var cachedExpression))
        {
            return cachedExpression;
        }

        IExpression optimized;
        switch (expression)
        {
            case IConstantExpression c:
                optimized = c;
                break;
            case IVariableExpression v:
                optimized = v;
                break;
            case IBinaryExpression b:
                var optimizedLeft = Optimize(b.Left);
                var optimizedRight = Optimize(b.Right);
                optimized = new BinaryExpression(optimizedLeft, optimizedRight, b.Sign);
                break;
            case IFunction f:
                var optimizedArg = Optimize(f.Argument);
                optimized = new Function(f.Kind, optimizedArg);
                break;
            default:
                throw new ArgumentException("Unknown expression type");
        }
        
        if (_cache.TryGetValue(optimized, out var finalCached))
        {
            return finalCached;
        }

        _cache.Add(optimized, optimized);
        return optimized;
    }
}