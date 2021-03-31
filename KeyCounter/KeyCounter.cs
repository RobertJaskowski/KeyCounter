using KeyCounter.View;
using KeyCounter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeyCounter
{
    public class KeyCounter : ICoreModule
    {
        public string ModuleName => "KeyCounter";
        private UserControl _view;
        public UserControl View
        {
            get
            {
                if (_view == null)
                {
                    _view = new KeyCounterView();
                    _view.DataContext = new KeyCounterViewModel(_host, this);
                }

                return _view;
            }
            set { _view = value; }
        }



        private UserControl _settingsView;
        public UserControl SettingsView
        {
            get
            {
                if (_settingsView == null)
                {
                    _settingsView = new KeyCounterSettingsView();
                    _settingsView.DataContext = new KeyCounterSettingsViewModel(_host, this);
                }

                return _settingsView;
            }
            set { _settingsView = value; }
        }
        private IModuleController _host;

        public string GetModuleName()
        {
            return ModuleName;
        }

        public ModulePosition GetModulePosition()
        {
            return ModulePosition.MID;
        }

        public UserControl GetModuleUserControlView()
        {
            return View;

        }

        public UserControl GetSettingsUserControlView()
        {
            return SettingsView;
        }

        public void Init(IModuleController host)
        {
            _host = host;
        }

        public void OnFullViewEntered()
        {

        }

        public void OnInteractableEntered()
        {

        }

        public void OnInteractableExited()
        {

        }

        public void OnMinViewEntered()
        {

        }

        public void ReceiveMessage(string message)
        {

        }

        public void Start()
        {
            _host.HookKeyboardPressedEvent(((KeyCounterViewModel)View.DataContext).KeyPressed);
            _host.HookKeyboardReleaseEvent(((KeyCounterViewModel)View.DataContext).KeyReleased);

        }

        public void Stop()
        {
            _host.UnHookKeyboardPressedEvent(((KeyCounterViewModel)View.DataContext).KeyPressed);
            _host.UnHookKeyboardReleasedEvent(((KeyCounterViewModel)View.DataContext).KeyReleased);


        }
    }
}
