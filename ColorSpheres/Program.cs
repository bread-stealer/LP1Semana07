using System;

namespace ColorSpheres
{
    public class Color
    {
        private readonly int _red;
        private readonly int _green;
        private readonly int _blue;
        private readonly int _alpha;

        public Color(int red, int green, int blue, int alpha)
        {
            _red = Clamp(red);
            _green = Clamp(green);
            _blue = Clamp(blue);
            _alpha = Clamp(alpha);
        }

        public Color(int red, int green, int blue) : this(red, green, blue, 255) {}

        //Getters
        public int Red => _red;
        public int Green => _green;
        public int Blue => _blue;
        public int Alpha => _alpha;

        public int GetGrey() => (_red + _green + _blue)/3;

        public override string ToString()
        {
            return $"Color(R={_red}, G={_green}, B={_blue}, A={_alpha}, Grey={GetGrey()})";
        }

        private static int Clamp(int value) => Math.Clamp(value, 0, 255);
    }

    public class Sphere
    {
        private Color _color;
        private float _radius;
        private int _timesThrown;

        public Color Color => _color;
        public float Radius => _radius;
        public bool IsPopped => _radius <= 0f;

        public void Pop()
        {
            _radius = 0f;
        }

        public void Throw()
        {
            if (IsPopped)
            {
                Console.WriteLine("[Sphere] Cannot throw a popped sphere.");
                return;
            }

            _timesThrown++;
        }

        public int GetTimesThrown()=> _timesThrown;
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello LP!");
        }
    }
}
