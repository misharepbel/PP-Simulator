using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {
        private string description = "Capybaras";
        private uint size=3;
        public required string Description
        {
            get => description;
            init => description = Validator.Shortener(value, 3, 15, '#');
        }
        public uint Size { get; set; } = 3;
        public virtual string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name.ToUpper()}: {this.Info}";
        }
    }
}
