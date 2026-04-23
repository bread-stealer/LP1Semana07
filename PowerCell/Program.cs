using System;
using System.Globalization;

namespace PowerCell
{
    public class Cell
    {
        // Variable of instance private: charge (float) 
        private float charge;

        //Property auto-implemented of readonly: Name (string)
        public readonly string Name;

        //Property Charge (float) which the value is only between 0 and 200
        public float Charge
        {
            get => charge;
            private set => charge = Math.Clamp(value, 0f, 200f);
        }

        //Property readonly Level (int) with the value of 1 + (int)Charge/40
        public int Level => 1 + (int)(Charge / 40f);

        //Method Consume(float amount) which reduces the charge by the given amount
        public void Consume(float amount)
        {
            Charge -= amount;
        }

        // Method Restore() which restores the charge to 200
        public void Restore()
        {
            Charge = 200f;
        }

        // Constructor that takes the name of the cell and initializes the charge to 200
        public Cell(string name)
        {
            Name = name;
            Charge = 200f;
        }

        //Override Method ToString() to return a string in the format: "[Name] Level Level: Charge/200"
        public override string ToString()
        {
            return $"[{Name}] Level {Level}: {Charge}/200";
        }
    }
    public class Program
    {
        // Argumentos:
        // args[0]: Nome da célula
        // args[1]: Número de consumos
        // args[2]: Quantidade de energia a consumir por operação
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            string name = args[0];
            int n = int.Parse(args[1]);
            float amount = float.Parse(args[2]);

            // Cria uma Nova Célula com o Nome Fornecido
            Cell c = new Cell(name);

            // Mostra o Estado Inicial da Célula
            Console.WriteLine(c);

            // Consome a Célula n Vezes
            for (int i = 0; i < n; i++) c.Consume(amount);

            // Mostra o Estado Após os Consumos
            Console.WriteLine(c);

            // Restaura a Célula e Mostra o Estado Final
            c.Restore();
            Console.WriteLine(c);

            // Este programa mostra o seguinte no ecrã (exemplo: Apollo 3 60):
            //
            // [Apollo] Level 6: 200/200
            // [Apollo] Level 1: 20/200
            // [Apollo] Level 6: 200/200
        }
    }
}