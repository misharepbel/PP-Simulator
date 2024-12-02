namespace Simulator;

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
            value = value[..max];
        }
        value = value.TrimEnd();
        if (value.Length < min)
        {
            value += new String(placeholder, min - value.Length);
        }
        if (Char.IsLower(value[0]))
        {
            value = Char.ToUpper(value[0]) + value[1..];
        }
        return value;
    }
	}
