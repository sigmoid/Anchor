using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Anchor.Views;

namespace Anchor.Managers
{
    public class ViewManager : IAnchorManager
    {


        #region Properties

        // Singleton
        private static IAnchorManager? _instance;
        public static ViewManager Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewManager();
                }

                return (ViewManager)_instance;
            }
        }

        private Stack<Window> _viewStack = new Stack<Window>();

        private Window? _mainWindow;

        #endregion

        public ViewManager()
        {
            _mainWindow = App.Current.MainWindow;
            _viewStack.Push(_mainWindow);
        }

        // Called once on application start
        public void Initialize()
        { 
        }

        public void ShowView(Window view, IAnchorViewModel viewModel, object? loadParms = null)
        {

            view.DataContext = viewModel;
            view.Owner = _mainWindow;

            _viewStack.Push(view);

            viewModel.Load(loadParms);

            try
            {
                view.Show();
                view.Closing += CloseView;
            }
            catch (Exception ex)
            {
                _viewStack.Pop();
            }
        }

        public void CloseView(object sender, CancelEventArgs args)
        {
            _viewStack.Pop();
        }

    }
}
