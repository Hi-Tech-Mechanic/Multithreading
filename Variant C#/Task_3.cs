internal class Task_3 //Задание 3. Параметры потока
{
    private string _message = "";  // общий ресурс
    AutoResetEvent waitHandler = new AutoResetEvent(true);  // объект-событие

    public void MainMethod()
    {
        Thread _thread_1 = new Thread(new ParameterizedThreadStart(Print));
        _thread_1.Name = "Поток первый";

        Thread _thread_2 = new Thread(new ParameterizedThreadStart(Print));
        _thread_2.Name = "Поток второй";

        Thread _thread_3 = new Thread(new ParameterizedThreadStart(Print));
        _thread_3.Name = "Поток третий";

        Thread _thread_4 = new Thread(new ParameterizedThreadStart(Print));
        _thread_4.Name = "Поток четвертый";

        _thread_1.Start("Некое сообщение");
        _thread_2.Start("Некое сообщение");
        _thread_3.Start("Некое сообщение");
        _thread_4.Start("Некое сообщение");
    }

    private void Print(object? message)
    {
        waitHandler.WaitOne();  // ожидаем сигнала

        if (message is string)
        {
            _message += message + "\t";
            Console.WriteLine($"{Thread.CurrentThread.Name}: {_message}");
            Thread.Sleep(200);
        }

        waitHandler.Set();  //  сигнализируем, что waitHandler в сигнальном состоянии
    }
}
