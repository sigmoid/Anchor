using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media;
using Anchor.Managers;
using Anchor.Views;

namespace Anchor.Model
{
    public enum DialogueSceneType { Conversation, PillState, DrawingState, Title}

    public class DialogueScene
    {
        public RelayCommand EditCommand
        {
            get;
            set;
        }

        public DialogueSceneType Type
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public Brush Color
        {
            get;
            set;
        }

        public DialogueScene()
        {
            EditCommand = new RelayCommand(() => Edit());
        }


        public virtual void Edit()
        {
            
        }
    }
}
