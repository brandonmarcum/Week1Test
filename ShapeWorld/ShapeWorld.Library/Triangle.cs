namespace ShapeWorld.Library
{
  public class Triangle : Shape
  {
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle() : base(3)
    {

    }

    public override double  Area()
    {
      return 0.5 * Base * Height;
    }

    public override double Perimeter()
    {
      return 1;
    }
    
    public override double Volume()
    {
      return  Area() * 1;
    }
  }
}