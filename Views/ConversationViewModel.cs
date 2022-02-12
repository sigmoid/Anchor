using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Model;

namespace Anchor.Views
{
    public class ConversationViewModel : AnchorViewModel
    {
        private ConversationScene _scene;
        public ConversationScene Scene
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

        public ConversationViewModel(ConversationScene scene)
        {
            Scene = scene;
        }
    }
}
