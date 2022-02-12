using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Model;

namespace Anchor.Views
{
    public class DrawingViewModel : AnchorViewModel
    {
        private DrawingScene _scene;
        public DrawingScene Scene
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

        public DrawingViewModel(DrawingScene scene)
        {
            Scene = scene;
        }
    }
}
