internal class Task_4 //Задание 4. Принудительное завершение потока
{
    CancellationTokenSource tokenSource = new();

    public void MainMethod()
    {
        Thread _thread_1 = new Thread(Print);

        _thread_1.Start();
        Thread.Sleep(2000);
        tokenSource.Cancel();
    }

    private void Print()
    {        
        for (int i = 0; i < 20 && !tokenSource.Token.IsCancellationRequested; i++)
        {
            Console.WriteLine("Hello");
            Thread.Sleep(200);
        }
    }
}
