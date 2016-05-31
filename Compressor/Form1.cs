//Aashir Javed 
//aashirjaved.me
//aas.jav@gmail.com




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zlib;
using Ionic.Zip;
using System.IO;
using System.IO.Compression;



namespace ZIPer
{
    public partial class Compressor : Form
    {
        List<string> listSelectedFile = new List<string>(); //for adding all the files in the list 
        string Password;  // for adding password in the zip file

        string ZipName; // for file name
        string DestinationPath; // for destination of the file
        bool status;
        bool zip_flag = false;
        bool flag_check_list = false;
        public static string extension;


        public Compressor()
        {
            InitializeComponent();
        }

        // Browse Button
        private void add_items_button_Click(object sender, EventArgs e)
        {
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BrowserTextBox.Enabled = true;
                BrowserTextBox.Text = openFileDialog1.FileName.ToString();
            

                SelectedFileList.Items.Add(openFileDialog1.FileName);
                flag_check_list = true;
            }
        }

        //Delete Button
        private void delete_button_click(object sender, EventArgs e)
        {

           if (SelectedFileList.SelectedIndex.Equals(0))
            { 

                SelectedFileList.Items.RemoveAt(SelectedFileList.SelectedIndex);
           

            }
           else
            MessageBox.Show("Please Select the item to delete");
        }

        // Password Check Box
        private void check_for_password(object sender, EventArgs e)
        {
            if (IsPassword.Checked)
            {
                PasswordTextBox.Enabled = true;
                AddPasswordButton.Enabled = true;
            }
            else
            {
                PasswordTextBox.Enabled = false;
                AddPasswordButton.Enabled = false;
            }
        }

        
        private void destination_folder_button(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DestinationTextBox.Enabled = true;
                DestinationTextBox.Text =folderBrowserDialog1.SelectedPath.ToString();
            }
        }

        //Finally, ZIP Button
        private void ZIPButton_Click(object sender, EventArgs e)
        {
            if (zip_flag == true  )
                MessageBox.Show("You have already zipped the files");
            else if(flag_check_list == false)
                MessageBox.Show("you havn't selected any files");
            else
            {

                foreach (object item in SelectedFileList.Items)
                    listSelectedFile.Add(item.ToString());

                DestinationPath = DestinationTextBox.Text;
                ZipName = ZipTextBox.Text;
                status = Zip_Files(listSelectedFile, Password, DestinationPath, ZipName);








                if (status == true)
                {


                    MessageBox.Show("You have Sucessfully Ziped your files in following destination " + DestinationPath);
                    zip_flag = true;

                }

                else
                    MessageBox.Show("Some Error Occured :(");
            }


        }

        public static bool Zip_Files(List<string> listSelectedFile, string Password , string DestinationPath, string ZipName)
        {
            
            if (listSelectedFile != null)
            {

                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = (Password);
                    foreach (var sFile in listSelectedFile)
                    {
                        zip.AddFile(sFile);
                    }
                    zip.Save(DestinationPath + "\\" + ZipName + extension );

                    return true;
                }
            }
            

               
                return false;
            
        }

        //Password Button
        private void AddPasswordButton_Click(object sender, EventArgs e)
        {
            Password = PasswordTextBox.Text;
            PasswordTextBox.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ZIPer_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //for computer on network

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BrowserTextBox.Enabled = true;
                textBox2.Text = openFileDialog1.FileName.ToString();


                SelectedFileList.Items.Add(openFileDialog1.FileName);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BrowserTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            Password = PasswordTextBox.Text;
          

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            extension = ".zip";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            extension = ".rar";
        }

        private void Restart_button(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
