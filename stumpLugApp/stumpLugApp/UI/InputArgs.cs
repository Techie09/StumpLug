using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public class InputArgs
    {
        private string m_input = String.Empty;
        public string input
        {
            get { return m_input; }
            set { m_input = value; }
        }

        private ConsoleKeyInfo m_keyInfo = new ConsoleKeyInfo();
        public ConsoleKeyInfo KeyInfo
        {
            get
            {
                return m_keyInfo;
            }
            set
            {
                m_keyInfo = value;
            }
        }

        public ConsoleKey Key
        {
            get { return KeyInfo.Key; }
        }

        public bool isShiftKeyPressed
        {
            get { return (KeyInfo.Modifiers & ConsoleModifiers.Shift) != 0; }
        }

        public bool isAltKeyPressed
        {
            get { return (KeyInfo.Modifiers & ConsoleModifiers.Alt) != 0; }
        }

        public bool isCtrlKeyPressed
        {
            get { return (KeyInfo.Modifiers & ConsoleModifiers.Control) != 0; }
        }
    }
}
