namespace ContactApp.Library
{
  public class Broadcaster
  {
    public delegate void Notifier();
    public event Notifier EventFire;
    public event Notifier Event2;

    public void Broadcast()
    {
      var count = 0;

      while(count < 10)
      {
        if (EventFire != null)
        {
          EventFire();
        }
        
        count += 1;
      }
    }
  }
}
