using System;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{

    /// <summary>
    /// A set of args used to store input data and make validating easier.
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/InputArgs
    public class InputArgs
    {
        #region Members
        private string m_input = String.Empty;
        /// <summary>
        /// A <see cref="string"/> representing text gathered when enter key is pressed
        /// </summary>
        public string input
        {
            get { return m_input; }
            set { m_input = value; }
        }

        private ConsoleKeyInfo m_keyInfo = new ConsoleKeyInfo();
        /// <summary>
        /// A <see cref="ConsoleKeyInfo"/> representing a <see cref="ConsoleKey"/> with <see cref="ConsoleModifiers"/>  
        /// </summary>
        public ConsoleKeyInfo keyInfo
        {
            get { return m_keyInfo; }
            set { m_keyInfo = value; }
        }

        /// <summary>
        /// returns <see cref="ConsoleKey"/> pressed
        /// </summary>
        /// <see cref="keyInfo"/>
        public ConsoleKey Key
        {
            get { return keyInfo.Key; }
        }

        /// <summary>
        /// Returns true if shift Key was pressed
        /// </summary>
        public bool isShiftKeyPressed
        {
            get { return (keyInfo.Modifiers & ConsoleModifiers.Shift) != 0; }
        }

        /// <summary>
        /// Returns true if Alt Key was pressed
        /// </summary>
        public bool isAltKeyPressed
        {
            get { return (keyInfo.Modifiers & ConsoleModifiers.Alt) != 0; }
        }

        /// <summary>
        /// Returns true if Ctrl KEy was pressed
        /// </summary>
        public bool isCtrlKeyPressed
        {
            get { return (keyInfo.Modifiers & ConsoleModifiers.Control) != 0; }
        }        
        #endregion

        #region Methods
        /// <summary>
        /// Initializes <see cref="keyInfo"/> 
        /// </summary>
        /// <param name="cki">data needed to populate <see cref="InputArgs"/> </param>
        public InputArgs(ConsoleKeyInfo cki)
        {
            keyInfo = cki;
        }

        /// <summary>
        /// Initializes <see cref="input"/> 
        /// </summary>
        /// <param name="input">data needed to populate <see cref="InputArgs"/> </param>
        public InputArgs(string input)
        {
            keyInfo = new ConsoleKeyInfo(); //protects getters from null
            this.input = input;
        }

        /// <summary>
        /// Checks if Key was pressed
        /// </summary>
        /// <param name="key">used to compare against <see cref="keyInfo"/> </param>
        /// <returns></returns>
        /// <see cref="ConsoleKey"/>
        public bool IsKeyPressed(ConsoleKey key)
        {
            return Key == key;
        }
        #endregion
    }
}
