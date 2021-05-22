using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    public partial class Writer
    {
        public override bool Equals(object obj)
        {
            return obj is Writer writer &&
                   Name == writer.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
