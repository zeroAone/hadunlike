using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成.panel.view
{
    public partial class testCar : Form
    {
        private List<String> testCarList = new List<string>();//组卷车地址列表
        public testCar(List<String> testCarList)
        {
            InitializeComponent();
            this.testCarList = testCarList;
        }

        private void testCar_Load(object sender, EventArgs e)
        {

        }
    }
}
