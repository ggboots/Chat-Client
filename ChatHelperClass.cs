using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; //. accessing UI elements

namespace ChatMessageApp
{
    public class ChatHelperClass
    {
        public TextBox chatTextbox;
        // potential naming issue
        public int port;

        public void SetChat(string str)
        {
            //delegate takes it from current thread to main thread
            chatTextbox.Invoke((Action)delegate
            {
                chatTextbox.Text = str;
                chatTextbox.AppendText(Environment.NewLine);
            });
        }
        public void AddToChat(string str)
        {
            chatTextbox.Invoke((Action)delegate
            {
                chatTextbox.AppendText(str);
                chatTextbox.AppendText(Environment.NewLine);
            });
        }
    }
}
