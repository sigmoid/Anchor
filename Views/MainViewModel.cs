using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Managers;
using Anchor.Util;
using Anchor.Model;
using CommunityToolkit.Mvvm.Input;

namespace Anchor.Views
{
    public class MainViewModel : AnchorViewModel
    {
        #region Properties

        public RelayCommand<object> EditSceneCommand { get; set; }

        private DialogueProgression _dialogueProgression;
        public DialogueProgression DialogueProgression {
            get
            {
                return _dialogueProgression;
            }
            set
            {
                _dialogueProgression = value;
                OnPropertyChanged("DialogueProgression");
            }
        }

        #endregion

        public MainViewModel()
        {
            EditSceneCommand = new RelayCommand<object>((sender) => EditScene(sender));

            Load(null);
        }

        public void Load(object parms)
        {
            DialogueProgression = new DialogueProgression();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private void EditScene(object sender)
        {
            ViewManager.Instance.ShowView(new TestView(), new TestViewModel());
        }
    }
}
