using System;

public class Calculator<T>
{
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

    public AddDelegate Add { get; set; }
    public SubtractDelegate Subtract { get; set; }
    public MultiplyDelegate Multiply { get; set; }
    public DivideDelegate Divide { get; set; }

    public Calculator()
    {
        Add = (a, b) => (dynamic)a + b;
        Subtract = (a, b) => (dynamic)a - b;
        Multiply = (a, b) => (dynamic)a * b;
        Divide = (a, b) => (dynamic)a / b;
    }

    public T PerformOperation(T a, T b, AddDelegate operation)
    {
        return operation(a, b);
    }

    public T PerformOperation(T a, T b, SubtractDelegate operation)
    {
        return operation(a, b);
    }

    public T PerformOperation(T a, T b, MultiplyDelegate operation)
    {
        return operation(a, b);
    }

    public T PerformOperation(T a, T b, DivideDelegate operation)
    {
        if (b.Equals((dynamic)0))
        {
            throw new DivideByZeroException("Division by zero!");
        }
        return operation(a, b);
    }
}
