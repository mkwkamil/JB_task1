namespace JB_task1;

class Program
{
    static void Main(string[] args)
    {
        var x = new VariableExpression("x");
        var y = new VariableExpression("y");
        var five = new ConstantExpression(5);
        var three = new ConstantExpression(3);

        var sum = new BinaryExpression(x, five, OperatorSign.Plus);
        var sinExpr = new Function(FunctionKind.Sin, sum);
        var subtract = new BinaryExpression(y, three, OperatorSign.Minus);
        var finalExpr = new BinaryExpression(sinExpr, subtract, OperatorSign.Multiply);

        Console.WriteLine(finalExpr);
    }
}