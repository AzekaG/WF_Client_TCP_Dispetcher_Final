using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Client_TCP_Dispetcher_Final
{
    public partial class Form1 : Form
    {
        Controller controller;
        SynchronizationContext uiContext;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            uiContext = new SynchronizationContext();
            controller.SetMessageToForm += IniListBox;
            controller.GetMessageFromForm += GetMessageFromListBox;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
           uiContext.Send(x=> controller.Connect(),null);
        }
        public void IniListBox(string text)
        {
            uiContext.Send(x=>listBox1.Items.Add(text),null);
        }
        public string GetMessageFromListBox()
        {
            string res = listBox1.SelectedItem as string;
            return res;
        }

        private void btnRefreshListProcess_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            uiContext.Send(x => controller.AskListProcess(),null);
        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                controller.SendCommandToKillProcessOnServer();
            }
            else MessageBox.Show("Выберите процесс");
        }
    }
}
