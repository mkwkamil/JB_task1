namespace JB_task1;

public class ConstantExpression(int value) : IConstantExpression
{
    public int Value { get; } = value;

    public override bool Equals(object? obj) => obj is ConstantExpression other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
}

public class VariableExpression(string name) : IVariableExpression
{
    public string Name { get; } = name;

    public override bool Equals(object? obj) => obj is VariableExpression other && Name == other.Name;
    public override int GetHashCode() => Name.GetHashCode();
    public override string ToString() => Name;
}

public class BinaryExpression(IExpression left, IExpression right, OperatorSign sign) : IBinaryExpression
{
    public IExpression Left { get; } = left;
    public IExpression Right { get; } = right;
    public OperatorSign Sign { get; } = sign;

    public override bool Equals(object? obj) =>
        obj is BinaryExpression other &&
        Sign == other.Sign &&
        Left.Equals(other.Left) &&
        Right.Equals(other.Right);

    public override int GetHashCode() => HashCode.Combine(Left, Right, Sign);

    public override string ToString()
    {
        var signStr = Sign switch
        {
            OperatorSign.Plus => "+",
            OperatorSign.Minus => "-",
            OperatorSign.Multiply => "*",
            OperatorSign.Divide => "/",
            _ => "?"
        };
        return $"({Left} {signStr} {Right})";
    }
}

public class Function(FunctionKind kind, IExpression argument) : IFunction
{
    public FunctionKind Kind { get; } = kind;
    public IExpression Argument { get; } = argument;

    public override bool Equals(object? obj) =>
        obj is Function other &&
        Kind == other.Kind &&
        Argument.Equals(other.Argument);

    public override int GetHashCode() => HashCode.Combine(Kind, Argument);
    public override string ToString() => $"{Kind.ToString().ToLower()}({Argument})";
}