using System;
using System.Collections.Generic;
using System.Linq;
using ShapeWorld.Library;

namespace ShapeWorld.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      PlayWithRectangle();
    }

    static void PlayWithRectangle()
    {
      var r = new Rectangle();
      var sq = new Square();
      //var s = new Shape();

      Shape s1 = r;
      Shape s2 = sq;
      sq.Length = 10;
      sq.Width = 11;
      //r.Edges = 10;

      Console.WriteLine(s1.Edges);
      System.Console.WriteLine(r.Edges);
      System.Console.WriteLine(s2.Area());
    }

    static void PlayWithShapes()
    {
      // 1-d
      Shape[] arrShapes1 = new Shape[10];
      var arrShapes2 = new Shape[]{ new Rectangle(), new Square(), new Triangle()};

      var item1 = arrShapes1[9];
      arrShapes2[0] = item1;

      // m-d
      Shape[,] arrShapes3 = new Shape[2,2];
      var arrShapes4 = new Shape[,]
      {
        {new Rectangle(), new Square()},
        {new Triangle(), new Triangle()}
      };

      var item2 = arrShapes3[1,0];
      arrShapes4[1,1] =  item2;

      // jagged
      Shape[][] arrShapes5 = new Shape[2][];
      var arrShapes6 = new Shape[][]{ new Rectangle[2], new Square[] { new Rectangle() as Square, new Square(), new Square()}};

      var item3 = arrShapes5[1][0];
      arrShapes6[1][0] = item3;

      // List
      List<Shape> lsShapes1 = new List<Shape>();
      var lsShapes2 = new List<Shape> { new Rectangle(), new Square(), new Triangle()};

      var item4 = lsShapes1[8];
      var item5 = lsShapes1.ElementAt(8);
      lsShapes2.Add(item4);
      lsShapes2[10] = item5;

      // Dictionary
      Dictionary<string, List<Shape>> diShapes1 = new Dictionary<string, List<Shape>>();
      var diShapes2 = new Dictionary<string, List<Shape>>
      {
        {"a", new List<Shape>()},
        {"b", new List<Shape>(){ new Rectangle(), new Square()}}
      };

      var item6 = diShapes1["a"];
      var item7 = diShapes1.Keys.ElementAt(1);
      diShapes2.Add("b", item6); //fail
      diShapes2["b"] = diShapes1[item7];
    }
  }
}
