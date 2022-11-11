namespace LearningMaterials.Structures
{
    public struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }

    readonly public struct ReadonlyPoint3D
    {
        public ReadonlyPoint3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
    }

    public struct Point3D
    {
        public Point3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private double _x;
        public double X
        {
            readonly get => _x;
            set => _x = value;
        }

        private double _y;
        public double Y
        {
            readonly get => _y;
            set => _y = value;
        }

        private double _z;
        public double Z
        {
            readonly get => _z;
            set => _z = value;
        }

        public readonly double Distance => Math.Sqrt(X * X + Y * Y + Z * Z);

        public readonly override string ToString() => $"{X}, {Y}, {Z}";
    }
}
