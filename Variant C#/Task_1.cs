internal class Task_1 //Задание 1. Создание потока
{
    int x = 1;  // общий ресурс

    public void MainMethod()
    {
        Thread _thread_1 = new(Print);
        _thread_1.Name = "Поток первый";

        Thread _thread_2 = new(Print);
        _thread_2.Name = "Поток второй";

        _thread_1.Start();
        _thread_2.Start();
    }

    private void Print()
    {
        for (int i = 0; i < 10; i++)
        {
            if (x <= 10)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}, строка: {x}");
                x++;
                Thread.Sleep(100);
            }
        }
    }
}