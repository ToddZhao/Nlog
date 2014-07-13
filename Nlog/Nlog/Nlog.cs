using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nlog
{
    public partial class Nlog : Form
    {
        public Nlog()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类 
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名 
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名 
                string[] str = new string[] { ".log", ".txt"};
                if (!str.Contains(extension))
                {
                    MessageBox.Show("仅能选择log、txt的文集");
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的 
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    //读取文件进行展示 TODO
                    txtFilePath.Text = fileDialog.FileName;
                }
            }
        }
    }
}
