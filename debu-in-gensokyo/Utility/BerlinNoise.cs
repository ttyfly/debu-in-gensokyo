using System;

namespace DebuInGensokyo.Utility
{
    // reference: https://github.com/raxod502/TerrariaClone/blob/master/src/PerlinNoise.java
    class BerlinNoise1D
    {
        public static double PerlinNoise(double x, double p, int n)
        {
            double total = 0;
            double freq, ampl;
            for (int i = 0; i < n + 1; i++) {
                freq = Math.Pow(2, i);
                ampl = Math.Pow(p, i);
                total = total + InterpolateNoise(x * freq) * ampl;
            }
            return total;
        }

        private static double InterpolateNoise(double x)
        {
            int ix = (int)x;
            double fx = x - ix;
            double v1 = SmoothNoise(ix);
            double v2 = SmoothNoise(ix + 1);
            return Interpolate(v1, v2, fx);
        }

        private static double SmoothNoise(int x)
        {
            return Noise(x) / 2 + Noise(x - 1) / 4 + Noise(x + 1) / 4;
        }

        private static double Noise(int x)
        {
            x = (x << 13) ^ x;
            return (1.0 - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0);
        }

        private static double Interpolate(double a, double b, double x)
        {
            double ft = x * Math.PI;
            double f = (1 - Math.Cos(ft)) / 2;
            return a * (1 - f) + b * f;
        }
    }
}