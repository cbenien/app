using System;

namespace app
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
        if (i < 0) throw new ArgumentException("I can only do positive numbers", "i");
        if (i1 < 0) throw new ArgumentException("I can only do positive numbers", "i1");

        return i + i1;
    }
  }
}