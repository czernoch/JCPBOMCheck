using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JCPBOMCheck
{
    public partial class LoadingForm : Form
    {

        //public int pocetzaznamu = 0;

        public LoadingForm()
        {
            InitializeComponent();
        }

        public void Start()
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                this.ShowDialog();
            });
        }

        public void Stop()
        {
            BeginInvoke((Action)delegate { this.Close(); });
        }

    }
}
