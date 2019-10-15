namespace Task4.Shapes
{
    public abstract class Shape
    {
        public double Area { get; set; }

        public double Perimeter { get; set; }

        public abstract void InitializeByArea(double area);
    }
}
