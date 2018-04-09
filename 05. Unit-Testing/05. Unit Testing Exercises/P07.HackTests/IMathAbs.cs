using System;
using System.Collections.Generic;
using System.Text;

namespace P07.HackTests
{
   public interface IMathAbs
    {
        decimal Abs(decimal value);
        double Abs(double value);
        short Abs(short value);
        int Abs(int value);
        long Abs(long value);
        sbyte Abs(sbyte value);
        float Abs(float value);
    }
}
