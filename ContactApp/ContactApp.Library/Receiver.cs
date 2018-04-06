using static ContactApp.Library.Broadcaster;

namespace ContactApp.Library
{
  public class Receiver
  {
    public void Receiving(Broadcaster b)
    {
      b.EventFire += Listening;
      //b.EventFire -= Listening;
      b.Event2 += () => {};
    }

    private void Listening()
    {
      System.Console.WriteLine("i am listening...");
    }
  }
}