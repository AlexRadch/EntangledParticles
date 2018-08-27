using System;

namespace Polarization
{
    // Simulation of entangled particles with polarization
    internal class Program
    {
        private static void Main(string[] args)
        {
            Experiment1();
            Experiment2();
            Experiment3();
            Experiment4();
            Console.ReadLine();
        }

        private static double Experiment(Env env,
            // Sets the position of the first sensor for each measurement
            Func<int, double> getFirstSensorAngle,
            // Sets the position of the second sensor for each measurement
            Func<int, double> getSecondSensorAngle)
        {
            var totalMeasurements = 10000;
            var disparityCount = 0; // how many measurements did not match

            for (int attemptNumber = 1; attemptNumber <= totalMeasurements; attemptNumber++)
            {
                // Зарождение пары запутанных частиц
                var pair = env.BurnPair(); 

                double firstSensorAngle = getFirstSensorAngle(attemptNumber);
                double secondSensorAngle = getSecondSensorAngle(attemptNumber);

                bool measureFirst = pair.first.Measure(firstSensorAngle);
                bool measureSecond = pair.second.Measure(secondSensorAngle);

                // counting the number of mismatched measurements
                if (measureFirst != measureSecond) 
                    disparityCount++;
            }

            return (double)disparityCount / totalMeasurements;
        }

        private static void Experiment1()
        {
            var result = Experiment(new HPEnv(), attemptNumber => 0D, attemptNumber => 0D);
            Console.WriteLine("Experiment 1: {0}% measurements did not match", result * 100);
        }

        private static void Experiment2()
        {
            var result = Experiment(new WFCEnv(), attemptNumber => 0D, attemptNumber => 0D);
            Console.WriteLine("Experiment 2: {0}% measurements did not match", result * 100);
        }

        private static void Experiment3()
        {
            var env = new HPEnv();
            var result = Experiment(env,
                attemptNumber => Env.TwoPi / 3D * env.Random.Next(0, 3),
                attemptNumber => Env.TwoPi / 3D * env.Random.Next(0, 3));
            Console.WriteLine("Experiment 3: {0}% measurements did not match", result * 100);
        }

        private static void Experiment4()
        {
            var env = new WFCEnv();
            var result = Experiment(env,
                attemptNumber => Env.TwoPi / 3D * env.Random.Next(0, 3),
                attemptNumber => Env.TwoPi / 3D * env.Random.Next(0, 3));
            Console.WriteLine("Experiment 4: {0}% measurements did not match", result * 100);
        }

    }
}
