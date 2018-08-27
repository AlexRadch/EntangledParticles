namespace Polarization
{
    // Environment for particles with wave function collapse
    public class WFCEnv : Env
    {
        // Creation of two entangled particles with wave function collapse
        public override (Particle first, Particle second) BurnPair() =>
            WFCParticle.BurnPair(this);
    }
}
