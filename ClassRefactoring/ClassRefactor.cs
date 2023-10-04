using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None = 0, Coconut = 4
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.European:
                    return new EuropeanSwallow();
                case SwallowType.African:
                    return new AfricanSwallow();
                default:
                    return new Swallow(swallowType);
            }
        }
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public readonly int AirspeedVelocity;
        
        public SwallowLoad Load { get; private set; }
        public int LoadAmount;

        public Swallow(SwallowType swallowType, int airspeedVelocity = 0) // This is to keep the airspeed readonly.
        {
            Type = swallowType;
            AirspeedVelocity = airspeedVelocity;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            var speed = AirspeedVelocity - (int)Load;
            if (speed < 0)
            {
                throw new Exception("This swallow's airspeed is too low.");
            }

            return speed;
        }
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow() : base(SwallowType.African, 22) 
        {
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow() : base(SwallowType.European, 20)
        {
        }

    }
}