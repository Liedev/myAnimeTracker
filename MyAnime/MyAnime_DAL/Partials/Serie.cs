using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    public partial class Serie
    {
        public override bool Equals(object obj)
        {
            return obj is Serie serie &&
                   SerieId == serie.SerieId &&
                   Name == serie.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 120212388;
            hashCode = hashCode * -1521134295 + SerieId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
