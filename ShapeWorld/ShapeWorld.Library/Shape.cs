namespace ShapeWorld.Library
{
  public abstract class Shape : IShape, IForm
  {
    //public int Edges { get; protected set; }
    public int Edges { get; }

    // private Shape()
    // {
    //   Edges = 10;
    // }

    public Shape(int e)
    {
      Edges = e;
    }

    public abstract double Area();
    public abstract double Volume();
    public abstract double Perimeter();

    int IForm.Area()
    {
      throw new System.NotImplementedException();
    }



    // public virtual double Area()
    // {
    //   return 0;
    // }

    // int IForm.Area()
    // {
    //   return 0;
    // }

    // public abstract double Volume();

    // public virtual double Perimeter()
    // {
    //   return 10;
    // }
  }
}
