internal class Task_8 //Задание 14. Синхронизационный вывод 4
{
    static Semaphore _semaphoreMain = new Semaphore(1, 1);
    static Semaphore _semaphoreChild = new Semaphore(0, 1);

    public void MainMethod()
    {
        Thread.CurrentThread.Name = "главный поток";

        while (true)
        {
            _semaphoreMain.WaitOne(); // Ждём сигнала от дочернего потока
            Console.WriteLine($"Работает: {Thread.CurrentThread.Name}");
            Thread.Sleep(300);
            Thread _thread_1 = new(ChildThread);
            _thread_1.Name = "дочерний поток";
            _thread_1.Start();
            _semaphoreChild.Release();
        }
    }

    private void ChildThread()
    {
        _semaphoreChild.WaitOne();
        Console.WriteLine($"Работает: {Thread.CurrentThread.Name}");
        Thread.Sleep(300);
        _semaphoreMain.Release();
    }
}
