using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ContactApp.Library.Interfaces;
using ContactApp.Library.Models;

namespace ContactApp.Library
{
  public class ContactHelper<T> where T : IContact, new()
  {
    private static List<T> _container = new List<T>();

    public bool Add(T t)
    {
      try
      {
        _container.Add(t);
        return true;
      }
      catch (ArgumentNullException e)
      {
        _container.Add(new T());
        return true;
      }
      catch(Exception e)
      {
        //throw;
        //throw e;
        //throw new CustomException("my bad, i forgot about null", e);

        return false;
      }
      finally
      {
        GC.Collect();
      }
    }

    public List<T> Read()
    {
      return _container;
    }

    public void WriteToText()
    {
      var path = @"contact.txt";
      
      File.WriteAllText(path, _container.FirstOrDefault().ToString());
    }

    public void WriteToXml()
    {
      var path = @"contact.xml";
      var p = _container.FirstOrDefault();

      using (var s = new StreamWriter(path))
      {
        var xml = new XmlSerializer(typeof(Person));
        xml.Serialize(s, p);
      }
    }

    public Person ReadFromText()
    {
      var path = @"contact.txt";
      var p = new Person();

      using(var s = new StreamReader(path))
      {
        var text = s.ReadLine();
        var first = text.Split()[0];
        var last = text.Split()[1];

        var n = new Name(){ First = first, Last = last};
        p.Name = n;
      }

      return p;
    }

    public T ReadFromXml()
    {
      var path = @"contact.xml";
      T person;

      using(var s = new StreamReader(path))
      {
        var xml = new XmlSerializer(typeof(T));
        person = (T) xml.Deserialize(s);
        //person = xml.Deserialize(s) as T;
      }

      return person;
    }

    public void Update(T t)
    {
      var a = _container.First(p => p.PId == t.PId);
      //var b = _container.First()
      // foreach (var item in _container)
      // {
      //   if (item.PId == t.PId)
      //   {
      //     return item;
      //   }
      // }
    }

    Func<string> hello = () => { return "hello";};
    Action<string> hello2 = (string h) => { System.Console.WriteLine(h);};

    public delegate string Hello5();
    public delegate void Hello6();

    public string Hello3()
    {
      return "hello3";
    }

    public string Hello4(Hello5 fs)
    {
      return fs();
    }
    //public void Delete();
  }
}