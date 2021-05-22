using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL.Data.Interfaces
{
    //https://stackoverflow.com/questions/16172462/close-window-from-viewmodel/16173553
    public interface ICloseable
    {
        void Close();
    }
}
