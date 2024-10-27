using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {
        private string description = "Capybaras";
        private uint size;
        public required string Description
        {
            get => description;
            init
            {
                value = value.Trim();
                if (value.Length > 15)
                {
                    value = value.Substring(0, 15);
                }
                value = value.TrimEnd();
                if (value.Length < 3)
                {
                    value += new String('#', 3 - value.Length);
                }
                if (value[0] is >= 'a' and <= 'z')
                {
                    value = (char)(value[0] - 32) + value.Substring(1);
                }
                description = value;
            }
        }
        public uint Size { get; set; } = 3;
        public string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
    }
}
