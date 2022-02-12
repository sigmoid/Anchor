using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Model;

namespace Anchor.Views
{
    public class TitleViewModel : AnchorViewModel
    {
        private TitleScene _scene;
        public TitleScene Scene
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

        public TitleViewModel(TitleScene scene)
        {
            Scene = scene;
        }
    }
}
