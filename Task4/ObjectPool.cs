using System;
using System.Collections.Generic;

public class ObjectPool<T>
{
    private Queue<T> objects = new Queue<T>();
    private Func<T> objectFactory;
    private Action<T> objectReset;

    public ObjectPool(Func<T> factory, Action<T> reset)
    {
        objectFactory = factory;
        objectReset = reset;
    }

    public T GetObject()
    {
        if (objects.Count > 0)
        {
            var obj = objects.Dequeue();
            return obj;
        }
        return objectFactory();
    }

    public void ReturnObject(T obj)
    {
        objectReset(obj);
        objects.Enqueue(obj);
    }
}