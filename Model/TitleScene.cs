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

    public class TitleScene : DialogueScene
    {
        public TitleScene()
        {
            EditCommand = new RelayCommand(() => Edit());
            this.Type = DialogueSceneType.Title;
        }

        #region Properties

        public float Duration
        {
            get;set;
        }

        public float Red
        {
            get
            {
                return (float)(Color as SolidColorBrush).Color.R / 255.0f; 
            }
        }

        public float Green
        {
            get
            {
                return (float)(Color as SolidColorBrush).Color.G / 255.0f;
            }
        }

        public float Blue
        {
            get
            {
                return (float)(Color as SolidColorBrush).Color.B / 255.0f;
            }
        }

        #endregion


        public override void Edit()
        {
            ViewManager.Instance.ShowView(new TitleView(), new TitleViewModel(this));
        }
    }
}
