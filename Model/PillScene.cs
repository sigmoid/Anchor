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

    public class PillScene : DialogueScene
    {
        public PillScene()
        {
            EditCommand = new RelayCommand(() => Edit());
            this.Type = DialogueSceneType.Title;
        }


        public override void Edit()
        {
            ViewManager.Instance.ShowView(new PillView(), new PillViewModel(this));
        }
    }
}
