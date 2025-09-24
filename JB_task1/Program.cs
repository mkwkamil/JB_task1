namespace JB_task1;

public class Program
{
    public static void Main(string[] args)
    {
        var expression = new BinaryExpression(
            new BinaryExpression(
                new Function(
                    FunctionKind.Sin,
                    new BinaryExpression(
                        new ConstantExpression(7),
                        new BinaryExpression(
                            new ConstantExpression(2),
                            new VariableExpression("x"),
                            OperatorSign.Plus
                        ),
                        OperatorSign.Multiply
                    )
                ),
                new BinaryExpression(
                    new ConstantExpression(7),
                    new BinaryExpression(
                        new ConstantExpression(2),
                        new ConstantExpression(6),
                        OperatorSign.Plus
                    ),
                    OperatorSign.Multiply
                ),
                OperatorSign.Minus
            ),
            new Function(
                FunctionKind.Cos,
                new VariableExpression("x")
            ),
            OperatorSign.Plus
        );

        Console.WriteLine("Original Expression: " + expression);
        Console.WriteLine();

        var optimizer = new ExpressionOptimizer();
        var optimizedExpression = optimizer.Optimize(expression);

        Console.WriteLine("Optimized Expression: " + optimizedExpression);
        Console.WriteLine();
    }
}