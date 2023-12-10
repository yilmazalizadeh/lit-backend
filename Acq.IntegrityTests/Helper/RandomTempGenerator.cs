namespace Acq.IntegrityTests.Helper;

public static class RandomTempGenerator
{
    public static float Generate(float minValue, float maxValue)
    {
        var random = new Random();
        return (float)(minValue + random.NextDouble() * (maxValue - minValue));
    }
}