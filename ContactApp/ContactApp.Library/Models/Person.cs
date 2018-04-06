using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ContactApp.Library.Enums;
using ContactApp.Library.Interfaces;

namespace ContactApp.Library.Models
{
  public class Person : IContact
  {
    public long PId { get; }
    [XmlAttribute]
    public Name Name { get; set; }
    [XmlElement]
    public Phone Phone { get; set; }
    [XmlIgnore]
    public Dictionary<ContactEnum, string> Email { get; set; }
    [XmlIgnore]
    public Dictionary<ContactEnum, Address> Address { get; set; }

    public Person()
    {
      checked
      {
        PId = DateTime.Now.Ticks;
      }
      
      Name = new Name();
      Phone = new Phone();
      Email = new Dictionary<ContactEnum, string>();
      Address = new Dictionary<ContactEnum, Address>();
      //Email.Add(ContactEnum.Home, "fred@revature.com");
    }

    public override string ToString()
    {
      return string.Format("{0}\n{1}\n{2}\n{3}", Name, Phone, Email, Address);
    }
  }
}