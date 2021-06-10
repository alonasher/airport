using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class SimulatorService
    {
        private static Random r = new Random();


        public static Plane GetRandomPlane()
        {

            int minSeats = 100;
            int maxSeats = 100;
            string model = GetRandomModel();
            Plane p = new Plane()
            {
                id = Guid.NewGuid(),
                model = model.ToString(),
                seats = r.Next(minSeats, maxSeats)
            };
            return p;
        }

        private static string GetRandomModel()
        {
            int modelStringLength = 5;
            int A = 65;
            int Z = 91;
            int ZERO = 48;
            int NINE = 58;

            StringBuilder model = new StringBuilder();
            for (int i = 0; i < modelStringLength; i++)
            {
                if (i <= 1)
                {
                    char c = (char)r.Next(A, Z);
                    model.Append(c);
                }
                else
                {
                    char c = (char)r.Next(ZERO, NINE);
                    model.Append(c);
                }
            }

            return model.ToString();
        }
    }
}
