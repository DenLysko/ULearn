namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        public readonly double X;
        public readonly double Y;

        public ReadOnlyVector(double x, double y)
        {
            X = x; 
            Y = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector other) =>
            new ReadOnlyVector(this.X + other.X, this.Y + other.Y);

        public ReadOnlyVector WithX(double x) =>
            new ReadOnlyVector(x, this.Y);

        public ReadOnlyVector WithY(double y) =>
            new ReadOnlyVector(this.X, y);
    }
}
