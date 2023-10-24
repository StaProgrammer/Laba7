using System;
public class TaskScheduler<TTask, TPriority>
{
    private readonly PriorityQueue<TTask, TPriority> taskQueue = new PriorityQueue<TTask, TPriority>();
    public ObjectPool<TTask> taskPool;

    public delegate void TaskExecution(TTask task);

    public TaskScheduler(Func<TTask> taskFactory, Action<TTask> taskReset)
    {
        taskPool = new ObjectPool<TTask>(taskFactory, taskReset);
    }

    public void AddTask(TTask task, TPriority priority)
    {
        taskQueue.Enqueue(task, priority);
    }

    public void ExecuteNext(TaskExecution executeTask)
    {
        if (taskQueue.Count > 0)
        {
            var nextTask = taskQueue.Dequeue();
            executeTask(nextTask);
            taskPool.ReturnObject(nextTask);
        }
        else
        {
            Console.WriteLine("No tasks in the queue.");
        }
    }

    public int TaskCount => taskQueue.Count;
}