using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anchor.Managers;
using Anchor.Util;

namespace Anchor.Views
{
    public class MainViewModel : IAnchorViewModel
    {
        #region Properties

        public event PropertyChangedEventHandler? PropertyChanged;

        public AnchorCommand OpenTestWindowCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            OpenTestWindowCommand = new AnchorCommand(() => OpenTestWindow()); 
        }

        public void Load(object parms)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private void OpenTestWindow()
        {
            ViewManager.Instance.ShowView(new TestView(), new TestViewModel());
        }
    }
}
