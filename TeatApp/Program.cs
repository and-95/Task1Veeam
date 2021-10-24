using System;
using System.Diagnostics;
using System.IO;

namespace TestApp
{
    class Program
    {
        private string name, timer, count;
        private string Name //Имя процесса
        {    
            get { return name; }
            set {  name = value.ToLower();}        
        }
        private string Timer //Установленное время существования в минутах
        { 
            get { return timer; } 
            set {double i = double.Parse(value);  i = ((i * 60)*1000); timer = i.ToString();} 
        }
        public string Count //установленный шаг проверки в минутах
        { 
            get { return count; }
            set { double i = double.Parse(value); i = (i * 60); count = i.ToString(); }      
        }

        public Program() {}
        public Program(string name, string timer, string count)
        {
            Name = name;
            Timer = timer;
            Count = count;
        }
        public void Test(object state)
        { 
           bool chek = true;
            foreach (Process p in Process.GetProcessesByName(Name)) //проверка на наличие процессов
            {

                chek = false;
                if ((DateTime.Now - p.StartTime).TotalMilliseconds < Int32.Parse(Timer))
                {
                Console.WriteLine("Процесс с именем '{0}' существует {1} мин.", Name, Math.Round((DateTime.Now - p.StartTime).TotalMinutes));
                Console.WriteLine("Ожидайте завершения процесса через {0} мин.", Timer);
                break;
                } else 
                Console.WriteLine("Процесс с именем '{0}' существовал {1} мин. и был завершен!", Name, Math.Round(((DateTime.Now - p.StartTime).TotalMinutes)));
                p.Kill();
                StreamWriter f = new StreamWriter("log.log", true);
                f.WriteLine("{2}:  Процесс с именем '{0}' существовал {1} мин. и был завершен!", Name, Math.Round(((DateTime.Now - p.StartTime).TotalMinutes)), DateTime.Now);
                f.Close();
               

                break;

            } if (chek) {  Console.WriteLine("Такого процесса не существует! Нажмите Enter, чтобы завершить программу!");  }

            }
    }
}
