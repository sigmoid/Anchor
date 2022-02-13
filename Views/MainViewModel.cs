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
using System.Windows;
using Microsoft.Win32;

namespace Anchor.Views
{
    public class MainViewModel : AnchorViewModel
    {
        #region Properties

        public RelayCommand SaveAsCommand { get; set; }
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
            SaveAsCommand = new RelayCommand(() => Save());

            Load(null);
        }

        public void Load(object parms)
        {
            DialogueProgression = SerializationManager.LoadProgression("C:\\Dev\\Tools\\Anchor\\Dialogue\\DialogueProgression.xml");
        }

        public void Save()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == true)
            {
                SerializationManager.SaveDialogueProgression(dialog.FileName, _dialogueProgression);
            }
        }

        private void EditScene(object sender)
        {

        }
    }
}
