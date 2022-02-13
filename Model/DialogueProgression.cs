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
                //new ConversationScene() {Content = "Conversation1", Color = Brushes.Firebrick, Type = DialogueSceneType.Conversation  },
                //new PillScene() { Content = "TestPillState", Color = Brushes.Azure, Type = DialogueSceneType.PillState },
                //new DrawingScene() { Content = "TestDrawingState", Color = Brushes.Crimson, Type = DialogueSceneType.DrawingState },
                //new TitleScene() {Content = "Test Title!", Color = Brushes.Cyan, Type = DialogueSceneType.Title}
        }; 
        }
    }
}
