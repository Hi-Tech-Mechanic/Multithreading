internal class Task_5 //Задание 5. Обработка завершения потока
{
    CancellationTokenSource tokenSource = new();
    Action OnCancelled;

    public void MainMethod()
    {
        Thread _thread_1 = new Thread(Print);
        OnCancelled += OutputEndAction;

        _thread_1.Start();
        Thread.Sleep(2000);
        tokenSource.Cancel();
        OnCancelled.Invoke();
    }

    private void Print()
    {
        for (int i = 0; i < 20 && !tokenSource.Token.IsCancellationRequested; i++)
        {
            Console.WriteLine("Hello");
            Thread.Sleep(200);
        }
    }

    private void OutputEndAction()
    {
        Console.WriteLine("Поток сейчас будет завершен");
    }
}
