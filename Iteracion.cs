using System;
using System.Collections.Generic;
using System.Text;

namespace metodo_de_newton_raphson
{
    class Iteracion
    {
        private double error;

        public int I { get; set; }
        public double Xi { get; set; }
        public double Fx { get; set; }
        public double Dx { get; set; }
        public double Xi1 { get; set; }
        public double Error { get => Math.Round(error, 3); set => error = value; }
    }
}
