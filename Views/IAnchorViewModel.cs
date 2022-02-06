using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.Views
{
    public interface IAnchorViewModel : INotifyPropertyChanged
    {
        void Load(object parms);

        void Save();
    }
}
