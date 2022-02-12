using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Model;

namespace Anchor.Views
{
    public class PillViewModel : AnchorViewModel
    {
        private PillScene _scene;
        public PillScene Scene
        {
            get
            {
                return _scene;
            }
            set
            {
                _scene = value;
                OnPropertyChanged("Scene");
            }
        }

        public PillViewModel(PillScene scene)
        {
            Scene = scene;
        }
    }
}
