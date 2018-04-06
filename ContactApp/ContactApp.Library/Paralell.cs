using System.Threading;
using System.Threading.Tasks;

namespace ContactApp.Library
{
  public class Paralell
  {
    public void WorkWithThread()
    {
      var t1 = new Thread(() => { RunMethod(100, 'A'); });
      var t2 = new Thread(() => { RunMethod(100, 'B'); });

      t1.Start();
      t2.Start();

      t1.Join();
      t2.Join();
    }

    public void WorkWithTask()
    {
      var t1 = new Task(() => { RunMethod(10000, 'A'); });
      var t2 = new Task(() => { RunMethod(10000, 'B'); });

      t1.Start();
      t2.Start();

      Task.WaitAll(new Task[]{t1, t2}, 50);
    }

    public async Task WorkWithAsync()
    {
      await Task.Run(() => RunMethod(1000, 'C'));
    }

    private void RunMethod(int i, char ch)
    {
      var c = 0;

      while (c < i)
      {
        System.Console.Write(ch);
        c += 1;
      }
    }
  }   
}
