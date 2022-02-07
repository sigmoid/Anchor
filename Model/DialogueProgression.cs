using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media;

namespace Anchor.Model
{
    public class DialogueProgression
    {
        public IList<DialogueScene> Scenes
        {
            get;
            set;
        }

        public DialogueProgression()
        {
            Scenes = new List<DialogueScene>()
            {
                new DialogueScene() {Content = "Conversation1", Color = Brushes.Firebrick, Type = DialogueSceneType.Conversation  },
                new DialogueScene() { Content = "TestPillState", Color = Brushes.Azure, Type = DialogueSceneType.PillState },
                new DialogueScene() { Content = "TestDrawingState", Color = Brushes.Crimson, Type = DialogueSceneType.DrawingState },
                new DialogueScene() {Content = "Test Title!", Color = Brushes.Cyan, Type = DialogueSceneType.Title}
        }; 
        }
    }
}
