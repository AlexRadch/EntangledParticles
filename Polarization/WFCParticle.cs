namespace Polarization
{
    // Particle with polarization and wave function collapse
    public class WFCParticle : Particle
    {
        private double? _angle;
        private WFCParticle _entangledParticle;

        protected WFCParticle(Env env) : base(env) { }

        public override bool Measure(double angle)
        {
            if (!_angle.HasValue)
                _angle = Env.RandomAngle();

            var result = Env.MeasurePolarization(angle, _angle.Value);

            if (result)
                _angle = angle; // the polarization angle becomes equalt to the sensor
            else
                _angle = angle + Env.HalfPi; // the polarization angle becomes orthogonal to the sensor

            // Wave function collapse
            if (_entangledParticle != null)
            {
                // polarization of the entangled particle becomes orthogonal to our
                _entangledParticle._angle = _angle + Env.HalfPi; 
                // superposition breaks down
                _entangledParticle._entangledParticle = null;
                _entangledParticle = null;
            }

            return result;
        }

        public static (WFCParticle first, WFCParticle second) BurnPair(Env env)
        {
            var first = new WFCParticle(env);
            var second = new WFCParticle(env);

            first._entangledParticle = second;
            second._entangledParticle = first;

            return (first, second);
        }
    }
}
