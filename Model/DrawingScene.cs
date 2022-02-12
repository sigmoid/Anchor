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

    public class DrawingScene : DialogueScene
    {
        public DrawingScene()
        {
            EditCommand = new RelayCommand(() => Edit());
            this.Type = DialogueSceneType.Title;
        }


        public string DrawingFilePath
        {
            get;
            set;
        }

        public override void Edit()
        {
            ViewManager.Instance.ShowView(new DrawingView(), new DrawingViewModel(this));
        }
    }
}
