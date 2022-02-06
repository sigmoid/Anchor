using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.Views
{
    internal class TestViewModel : IAnchorViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void Load(object parms)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
