using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace AutoBhopV2
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        public string fJump = "client.dll+0x72DCF0";
        public string inair = "client.dll+0x6BADC8";
        public int result = 123;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName("left4dead2");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                Thread bh = new Thread(autobhop);
                bh.Start();
            }
        }

        private void autobhop()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    if (GetAsyncKeyState(Keys.Space)<0)
                    {
                        
                        result = m.ReadInt(inair);
                        if (result == 0)
                        {
                            m.WriteMemory(fJump, "int", "5");
                            Thread.Sleep(10);
                            m.WriteMemory(fJump, "int", "4");
                            
                        }
                        
                    }
                    
                }
                Thread.Sleep(1);
            }
        }

        
    }
}
