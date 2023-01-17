using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; //. accessing UI elements

namespace ChatMessageApp
{
    public class ChatHelperClass
    {
        public TextBox chatTextBox;
        // potential naming issue
        public int port;

        public void SetChat(string str)
        {
            //delegate takes it from current thread to main thread
            chatTextBox.Invoke((Action)delegate
            {
                chatTextBox.Text = str;
                chatTextBox.AppendText(Environment.NewLine);
            });
        }
        public void AddToChat(string str)
        {
            chatTextBox.Invoke((Action)delegate
            {
                chatTextBox.AppendText(str);
                chatTextBox.AppendText(Environment.NewLine);
            });
        }
    }
}
