namespace Wpf.Interview.Models;

public static class InvokeDispatcherExtensions
{
    public static void InvokeWithNoReturn(Func<Task> runFunc)
    {
        //System.Windows for WinUI
        //DispatcherQueue dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        //dispatcherQueue.TryEnqueue(() =>
        try
        {
            var syncContext = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                await runFunc();
                /*syncContext?.Post(_ =>
                {
                    // Use the result in the original thread
                    //Console.WriteLine(result);
                }, null);*/
            });
        }
        catch (AggregateException ex)
        {
            // Handle the exception
            foreach (var innerException in ex.InnerExceptions)
            {
                Console.WriteLine(innerException.Message);
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine(ex.Message);
        }
    }
}

