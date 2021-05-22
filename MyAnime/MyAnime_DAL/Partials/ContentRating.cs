using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    public partial class ContentRating
    {
        public override bool Equals(object obj)
        {
            return obj is ContentRating rating &&
                   Rating == rating.Rating;
        }

        public override int GetHashCode()
        {
            int hashCode = 254066416;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rating);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Rating;
        }
    }
}
