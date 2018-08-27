namespace Polarization
{
    // Particle with polarization
    public abstract class Particle
    {
        protected Particle(Env env)
        {
            Env = env;
        }

        public Env Env { get; private set; }

        // Measure polarization
        public abstract bool Measure(double angle);
    }
}
