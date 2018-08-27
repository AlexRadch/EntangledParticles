namespace Polarization
{
    // Environment for particles with hidden parameters
    public class HPEnv : Env
    {
        // Creation of two entangled particles with hidden parameters
        public override (Particle first, Particle second) BurnPair() =>
            HPParticle.BurnPair(this);
    }
}
