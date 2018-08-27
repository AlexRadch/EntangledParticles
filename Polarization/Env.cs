using System;

namespace Polarization
{
    // Experience environment
    public abstract class Env
    {
        #region Utility constants and static methods

        public const double TwoPi = Math.PI * 2D; // 360 degree
        public const double HalfPi = Math.PI / 2D; // 90 degree

        public static double PolarizationProbability(double angle) =>
            Math.Pow(Math.Cos(angle), 2D);

        public static double PolarizationProbability(double angle1, double angle2) =>
            PolarizationProbability(angle2 - angle1);

        #endregion

        #region Properties

        public readonly Random Random = new Random();

        #endregion

        #region Utility methods

        public double RandomAngle() =>
            Random.NextDouble() * TwoPi;

        public bool MeasurePolarization(double angle) =>
            Random.NextDouble() < PolarizationProbability(angle);

        public bool MeasurePolarization(double angle1, double angle2) =>
            MeasurePolarization(angle2 - angle1);

        #endregion

        // Creation of two entangled particles
        public abstract (Particle first, Particle second) BurnPair();
    }
}
