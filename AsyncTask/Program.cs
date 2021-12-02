using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask{
    class Program{
        static void DosomeThing(int seconds, string mgs){
            lock(Console.Out){
                Console.WriteLine($"{mgs, 25} Start");
            }
            for(int i = 1; i <= seconds; i++)
            {
                lock(Console.Out){
                    Console.WriteLine($"{mgs, 25}");
                    Thread.Sleep(1000);
                }
            }
            lock(Console.Out){
                Console.WriteLine($"{mgs, 25} End");
            }
        }
        static async Task CreatTask(string mgs){
            Task task = new Task(
                () => {
                    DosomeThing(5, mgs);
                }
            );

            task.Start();
            await task;
            Console.WriteLine($"{mgs} finish");
        }
        static void Main(){
            Task t1 = CreatTask("this is task 1");
            Task t2 = CreatTask("this is task 2");
            Task.WaitAll(t1, t2);
            Console.WriteLine("bye");
        }
    }
}