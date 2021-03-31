using System;
using System.Diagnostics;
using System.Windows.Input;

namespace KeyCounter.ViewModel
{
    class KeyCounterViewModel : ObservableObject
    {
       


        private int _keyCounterString = 0;
        public int KeyCounter
        {
            get
            {

                return _keyCounterString;
            }
            set
            {

                _keyCounterString = value;
                OnPropertyChanged(nameof(KeyCounter));
            }
        }

        private bool ZPressed = false;
        private bool CtrlPressed = false;

        private ICommand _keyCounterClicked;
        public ICommand KeyCounterClicked
        {
            get
            {
                if (_keyCounterClicked == null)
                    _keyCounterClicked = new RelayCommand(
                       (object o) =>
                       {

                           Debug.WriteLine("_keyCounterClicked " + KeyCounter);

                       },
                       (object o) =>
                       {
                           return true;
                       });

                return _keyCounterClicked;

            }
        }


        private object host;
        private KeyCounter keyCounter;

        public KeyCounterViewModel(object host, KeyCounter keyCounter)
        {
            this.host = host;
            this.keyCounter = keyCounter;
        }


        private void CheckForCtrlZCombination()
        {
            if (CtrlPressed && ZPressed)
            {
                KeyCounter++;
                //label1.Content = ctrlZCounter;
            }
        }

        internal void KeyReleased(KeyReleasedArgs e)
        {
            if (e.KeyReleased == System.Windows.Input.Key.LeftCtrl)
            {
                CtrlPressed = false;

            }
            else if (e.KeyReleased == System.Windows.Input.Key.Z)
            {
                ZPressed = false;

            }
        }

        internal void KeyPressed(KeyPressedArgs e)
        {
            if (e.KeyPressed == System.Windows.Input.Key.LeftCtrl)
            {
                CtrlPressed = true;
                CheckForCtrlZCombination();
            }
            else if (e.KeyPressed == System.Windows.Input.Key.Z)
            {
                ZPressed = true;
                CheckForCtrlZCombination();
            }
        }
    }
}
