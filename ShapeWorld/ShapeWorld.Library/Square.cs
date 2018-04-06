namespace ShapeWorld.Library
{
  public class Square : Rectangle
  {
    //public new int Edges { get; set; } //overwrite not override
    private double _length;

    public override double Length
    {
      get
      {
        return _length;
      }
      set
      {
        _length = value;
      }
    }

    public override double Width
    {
      get
      {
        return _length;
      }
      set
      {
        _length = value;
      }
    }
    
    public override double Area()
    {
      return 1;
    }
  }
}