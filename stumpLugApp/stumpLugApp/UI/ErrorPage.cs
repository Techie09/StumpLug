using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    public class ErrorPage : Page
    {
        private Exception m_exception;
        public Exception exception
        {
            get { return m_exception; }
            set { m_exception = value; }
        }

        public override void OnLoad()
        {
            base.OnLoad();
            pageTitle = "Lost in the STARS?";
            commands = new List<CommandsEnum> { CommandsEnum.MainMenu, CommandsEnum.Exit };
            int truncateSize = Console.BufferWidth - 3;

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLineTruncate(truncateSize, " Error: {0}", exception.Message);
            contentBuilder.AppendLineTruncate(truncateSize, "Source: {0}", exception.Source);
            contentBuilder.AppendLine(horzRule);

            if (exception.InnerException != null)
            {
                Exception innermostException = exception.InnerException;
                while (innermostException != null)
                    innermostException = innermostException.InnerException;

                contentBuilder.AppendLineTruncate(truncateSize, "Innermost Exception: {0}", innermostException.Message);
                contentBuilder.AppendLineTruncate(truncateSize, "Source: {0}", innermostException.Source);
                contentBuilder.AppendLine(horzRule);
            }

            foreach (string s in exception.StackTrace.Split('\n'))
            {

                contentBuilder.AppendLineTruncate(truncateSize,  s);
            }
            content = contentBuilder.ToString();
        }
    }
}
