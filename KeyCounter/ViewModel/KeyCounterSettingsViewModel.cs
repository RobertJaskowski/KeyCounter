using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCounter.ViewModel
{
    class KeyCounterSettingsViewModel
    {
        private object host;
        private KeyCounter keyCounter;

        public KeyCounterSettingsViewModel(object host, KeyCounter keyCounter)
        {
            this.host = host;
            this.keyCounter = keyCounter;
        }
    }
}
