internal class Task_7 //Задание 11. Синхронизационный вывод
{
    static Mutex mutexMain = new();
    static Mutex mutexChild = new();

    public void MainMethod()
    {
        Thread.CurrentThread.Name = "главный поток";

        while (true) 
        {
            mutexMain.WaitOne(); // Ждём сигнала от дочернего потока
            Console.WriteLine($"Работает: {Thread.CurrentThread.Name}");
            Thread.Sleep(200);
            Thread _thread_1 = new(Print);
            _thread_1.Name = "дочерний поток";
            _thread_1.Start();
            mutexMain.ReleaseMutex();
        }

    }

    private void Print()
    {
        mutexChild.WaitOne();
        Console.WriteLine($"Работает: {Thread.CurrentThread.Name}");
        Thread.Sleep(200);
        mutexChild.ReleaseMutex();
    }
}
