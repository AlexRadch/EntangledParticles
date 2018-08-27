namespace Polarization
{
    // Particle with polarization and hidden parameters
    public class HPParticle: Particle
    {
        // Hidden parameters
        private double _angle;

        protected HPParticle(HPEnv env) : base(env) { }

        // Measure polarization
        public override bool Measure(double angle)
        {
            var result = Env.MeasurePolarization(angle, _angle);

            if (result)
                _angle = angle; // the polarization angle becomes equalt to the sensor
            else
                _angle = angle + Env.HalfPi; // the polarization angle becomes orthogonal to the sensor

            return result;
        }

        // Creation of two entangled particles with hidden parameters
        public static (HPParticle first, HPParticle second) BurnPair(HPEnv env)
        {
            var first = new HPParticle(env);
            var second = new HPParticle(env);

            var angle = env.RandomAngle();

            first._angle = angle; // the second particle polarization 
            second._angle = angle + Env.HalfPi; // the second particle polarization is orthogonal to the first

            return (first, second);
        }
    }
}
