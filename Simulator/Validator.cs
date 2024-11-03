using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator
{
	public static class Validator
	{
		public static int Limiter(int value, int min, int max)
		{
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
        public static string Shortener(string value, int min, int max, char placeholder)
        {
            value = value.Trim();
            if (value.Length > max)
            {
                value = value.Substring(0, max);
            }
            value = value.TrimEnd();
            if (value.Length < min)
            {
                value += new String(placeholder, min - value.Length);
            }
            if (value[0] is >= 'a' and <= 'z')
            {
                value = (char)(value[0] - 32) + value.Substring(1);
            }
            return value;
        }
	}
}
