using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapoDllDependencyTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Cheapo Dll Dependency Tool";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            byte[] ExeByteArray;
            string[] DllFileNames;
            int ExeByteArrayPossibleIndexSize = 0;
            int[] ExeByteArrayPossibleIndex;
            int ExeDllFileNamesArrayIndexSize = 0;


            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                ExeByteArray = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                for (int i = 0; i < ExeByteArray.Length; i++)
                {
                    if (ExeByteArray[i] == '.')
                    {
                        if (i <= ExeByteArray.Length - 4)
                        {
                            if (ExeByteArray[i + 1] == 'd' &&
                               ExeByteArray[i + 2] == 'l' &&
                               ExeByteArray[i + 3] == 'l')
                            {
                                ExeByteArrayPossibleIndexSize++;
                            }
                        }
                    }
                }
                DllFileNames = new string[ExeByteArrayPossibleIndexSize];
                ExeByteArrayPossibleIndex = new int[ExeByteArrayPossibleIndexSize];
                ExeByteArrayPossibleIndexSize = 0;
                for (int i = 0; i < ExeByteArray.Length; i++)
                {
                    if (ExeByteArray[i] == '.')
                    {
                        if (i <= ExeByteArray.Length - 4)
                        {
                            if (ExeByteArray[i + 1] == 'd' &&
                               ExeByteArray[i + 2] == 'l' &&
                               ExeByteArray[i + 3] == 'l')
                            {
                                ExeByteArrayPossibleIndex[ExeByteArrayPossibleIndexSize] = i;
                                ExeByteArrayPossibleIndexSize++;
                            }
                        }
                    }
                }
                bool WhiteSpaceFoundOrTooLongName = false;
                int WhiteSpaceFinderCount = 0;

                for (int i = 0; i < ExeByteArrayPossibleIndexSize; i++)
                {
                    WhiteSpaceFoundOrTooLongName = false;
                    WhiteSpaceFinderCount = 0;
                    byte[] filenamebytes;

                    do
                    {
                        if (ExeByteArray[ExeByteArrayPossibleIndex[i] - WhiteSpaceFinderCount] == ' ' ||
                           WhiteSpaceFinderCount > 50)
                        {
                            WhiteSpaceFoundOrTooLongName = true;
                        }
                        WhiteSpaceFinderCount++;
                    }
                    while (WhiteSpaceFoundOrTooLongName == false);

                    filenamebytes = new byte[WhiteSpaceFinderCount];
                    WhiteSpaceFoundOrTooLongName = false;
                    WhiteSpaceFinderCount = 0;

                    do
                    {
                        if (ExeByteArray[ExeByteArrayPossibleIndex[i] - WhiteSpaceFinderCount] == ' ' ||
                           WhiteSpaceFinderCount > 50)
                        {
                            WhiteSpaceFoundOrTooLongName = true;
                        }
                        else
                        {
                            filenamebytes[WhiteSpaceFinderCount] = ExeByteArray[ExeByteArrayPossibleIndex[i] - WhiteSpaceFinderCount];
                        }

                        WhiteSpaceFinderCount++;
                    }
                    while (WhiteSpaceFoundOrTooLongName == false);
                 
                    DllFileNames[i] = System.Text.Encoding.ASCII.GetString(filenamebytes);
                }
                for (int i = 0; i < DllFileNames.Length; i++)
                {
                    listView1.Items.Add(DllFileNames[i]);
                }
                listView1.View = View.Tile;// LargeIcon;
            }
        }
    }
}
