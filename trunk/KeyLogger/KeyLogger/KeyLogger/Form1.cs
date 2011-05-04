using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();
            hook.Install();
            hook.KeyUp += new KeyEventHandler(hook_KeyUp);
        }

        void hook_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        void hook_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //hook.KeyDown += new KeyEventHandler(hook_KeyDown);
        }
    }
}
