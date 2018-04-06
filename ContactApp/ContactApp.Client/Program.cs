using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using ContactApp.Library;
using ContactApp.Library.Models;

namespace ContactApp.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      //PlayWithContact();
      //PlayWithDelegate();
      //PlayWithEvent();
      PlayWithParalell();
      
      System.Console.WriteLine("FINISH MAIN THREAD");

      //var arrNames = new string[] { "123", "fred", "Fred", "fred1"};
      // string validName;

      // foreach (var item in arrNames)
      // {
      //   if (NameCheck(out validName, item))
      //   {
      //     System.Console.WriteLine("your valid name is: {0}", validName);
      //     break;
      //   }

      //   System.Console.WriteLine("your name should not be: {0}", validName);
      // }

      // string first;
      // string middle;
      // string last;

      // foreach (var item in arrNames)
      // {
      //   first = item + "1";
      //   middle = item + "2";
      //   last = item + "3";

      //   if (NameCheck(middle: middle, last: last, first: ref first))
      //   {
      //     System.Console.WriteLine("your valid name is: {0}", first);
      //   }
      //   else
      //   {
      //     System.Console.WriteLine("your name should not be: {0}", last);
      //   }
      // }

      // Sum(1,2,3);
      // Sum(new int[]{1,2,3});
    }

    static void PlayWithContact()
    {
      var ch = new ContactHelper<Person>();

      ch.Add(new Person());

      foreach (var item in ch.Read())
      {
        System.Console.WriteLine(item);
      }

      ch.WriteToText();
      ch.WriteToXml();
    }

    static void PlayWithDelegate()
    {
      var ch = new ContactHelper<Person>();

      //System.Console.WriteLine(ch.Hello4(() => { return "goodbye";}));
      System.Console.WriteLine(ch.Hello4(ch.Hello3));
    }

    public static void PlayWithEvent()
    {
      var b = new Broadcaster();
      var r = new Receiver();

      
      b.Broadcast();
      r.Receiving(b);
      b.Broadcast();
    }

    static bool NameCheck(out string validName, string name = "not named")
    {
      if (Regex.IsMatch(name, "^[a-z]*$"))
      {
        validName = name;
        return true;
      }
      //var s = validName;
      validName = "not valid";
      return false;
    }

    static bool NameCheck(ref string first, string middle, string last = "not named")
    {
      if (Regex.IsMatch(first, "^[a-z].*$"))
      {
        var temp = last;
        last = first;
        first = middle;
        middle = temp;
        return true;
      }

      return false;
    }

    // public double Sum(List<int> i)
    // {
    //   return 1;
    // }

    public static double Sum(params int[] i)
    {
      return 1;
    }

    public static void PlayWithParalell()
    {
      var p = new Paralell();

      //p.WorkWithThread();
      //p.WorkWithTask();
      p.WorkWithAsync().GetAwaiter().GetResult();
    }
  }
}
