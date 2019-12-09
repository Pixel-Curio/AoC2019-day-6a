using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_6a
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CelestialBody> bodies = new Dictionary<string, CelestialBody>();
            string[] orbits = File.ReadAllLines(@"day6a-input.txt");

            foreach (string orbit in orbits)
            {
                var names = orbit.Split(')');
                if (!bodies.ContainsKey(names[0])) bodies.Add(names[0], new CelestialBody());
                if (!bodies.ContainsKey(names[1])) bodies.Add(names[1], new CelestialBody());

                bodies[names[0]].OrbitedBy.Add(bodies[names[1]]);
                bodies[names[1]].Orbits.Add(bodies[names[0]]);
            }

            int count = bodies.Sum(x => OrbitSum(x.Value));

            Console.WriteLine($"Total orbits: {count}");
        }

        private static int OrbitSum(CelestialBody body)
        {
            return body.Orbits.Count != 0 ? 1 + OrbitSum(body.Orbits[0]) : 0;
        }

        class CelestialBody
        {
            public List<CelestialBody> Orbits = new List<CelestialBody>();
            public List<CelestialBody> OrbitedBy = new List<CelestialBody>();
        }
    }
}
