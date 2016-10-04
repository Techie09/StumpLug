using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public class InputArgs
    {
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
        /*
        private ConsoleKey m_actionKey; // char which determines the action [ Add, Create, Exit : A,C,X ]
        private ConsoleKey m_typeKey; // char which determines the type [ Student, Course : S,C ]

        public ConsoleKey ActionKey
        {
            get
            {
               return m_actionKey;
            }
            set
            {
                m_actionKey = value;
            }
        }
        public ConsoleKey TypeKey
        {
            get
            {
                return m_typeKey;
            }
            set
            {
                m_typeKey = value;
            }
         
        }
        */

    }
}
