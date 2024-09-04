internal class Task_6 //Задание 24. Производственная линия
{
    static Semaphore sem = new Semaphore(1, 1);
    private Thread _productionLine;
    private int _currentStep = 0;

    public void MainMethod()
    {
        while (true)
        {
            sem.WaitOne();

            switch (_currentStep)
            {
                case 0:
                    _productionLine = new Thread(CreateWidget_A);
                    break;
                case 1:
                    _productionLine = new Thread(CreateWidget_B);
                    break;
                case 2:
                    _productionLine = new Thread(CreateWidget_C);
                    break;
                case 3:
                    _productionLine = new Thread(CreateModule);
                    break;
                case 4:
                    _productionLine = new Thread(CreateScrew);
                    break;
            }

            //Запуск производственной линии//
            _productionLine.Start();
            _currentStep++;
        }
    }

    private void CreateScrew()
    {
        Thread.Sleep(1500);
        _currentStep = 0;
        sem.Release();
        Console.WriteLine("Винтик создан");
        Console.WriteLine("========================================");
    }

    private void CreateModule()
    {
        Thread.Sleep(500);
        sem.Release();
        Console.WriteLine("Модуль создан");
    }

    private void CreateWidget_A()
    {
        Thread.Sleep(1000);
        sem.Release();
        Console.WriteLine("Деталь A создана");
    }

    private void CreateWidget_B()
    {
        Thread.Sleep(2000);
        sem.Release();
        Console.WriteLine("Деталь B создана");
    }

    private void CreateWidget_C()
    {
        Thread.Sleep(3000);
        sem.Release();
        Console.WriteLine("Деталь C создана");
    }
}
