using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ReStatusStrip;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace Semaphore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, true);
        }
        TcpClientChannel channel;
        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Semaphore _pool;
            _pool = System.Threading.Semaphore.OpenExisting("sunleisolar");
            _pool.Release();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerObject SerObj = (ServerObject)Activator.GetObject(typeof(ServerObject), "tcp://127.0.0.1:12556/Startapp.soap");
			if (SerObj!= null)
			{
				try
				{
					SerObj.ShowMessage("System startup success！");
                    SerObj.StartApp("eGingkoReport",DateTime.Now.ToString());
				}
				catch (Exception de)
				{
					MessageBox.Show(String.Format("{0},Please check the C:/Windows/System32/drivers/et/hosts！",de.Message));
				}				
			}
        }
    }
}
