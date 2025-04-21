//
// Developed by BA55H4QR
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FortEditX
{
    public partial class Form1 : Form
    {
        private TextBox[] textBoxes = new TextBox[9]; private Button applyBtn; private string filePath; private string[] settingsKeys = {
            "bMotionBlur", "bShowGrass", "bUseGPUCrashDebugging", "bStopRenderingInBackground", "bLatencyTweak1",
            "LatencyTweak2", "bDisableMouseAcceleration", "FrameRateLimit", "AudioQualityLevel"
        };
        public Form1()
        {
            InitializeComponent(); string pc = Environment.UserName;
            filePath = $"C:\\Users\\{pc}\\AppData\\Local\\FortniteGame\\Saved\\Config\\WindowsClient\\GameUserSettings.ini";
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i] = new TextBox { Top = 10 + (i * 30), Left = 10, Width = 200 }; Controls.Add(textBoxes[i]);
            }
            applyBtn = new Button { Text = "Apply", Top = 280, Left = 10 }; applyBtn.Click += ApplyChanges; Controls.Add(applyBtn); LoadFileContent();
        }
        private void LoadFileContent()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.IsReadOnly)
                    {
                        fileInfo.IsReadOnly = false;
                    }
                    string content = File.ReadAllText(filePath); for (int i = 0; i < settingsKeys.Length; i++)
                    {
                        Match match = Regex.Match(content, $"{settingsKeys[i]}=(.*)");
                        if (match.Success)
                        {
                            string newValue = match.Value; switch (settingsKeys[i])
                            {
                                case "bMotionBlur":
                                case "bUseGPUCrashDebugging":
                                case "bStopRenderingInBackground":
                                case "bLatencyTweak1":
                                case "bShowGrass":
                                    newValue = "False";
                                    break;
                                case "LatencyTweak2":
                                    newValue = "0";
                                    break;
                                case "bDisableMouseAcceleration":
                                    newValue = "True";
                                    break;
                                case "FrameRateLimit":
                                    if (float.TryParse(match.Groups[1].Value, out float fps))
                                    {
                                        newValue = (fps - 3).ToString("F6");
                                    }
                                    break;
                                case "AudioQualityLevel":
                                    newValue = "1";
                                    break;
                            }
                            textBoxes[i].Text = settingsKeys[i] + "=" + newValue;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File not found..", "Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Process.Start(new ProcessStartInfo("https://telegra.ph/Oops-Something-Went-Wrong-03-22") { UseShellExecute = true });
                    Environment.Exit(0);
                }
            }                   
            catch (Exception ex){MessageBox.Show("Error: " + ex.Message);}
        }
        private void ApplyChanges(object sender, EventArgs e)
        {
            try
            {
                string content = File.ReadAllText(filePath); for (int i = 0; i < settingsKeys.Length; i++)
                {
                    content = Regex.Replace(content, $"{settingsKeys[i]}=.*", textBoxes[i].Text);
                }
                File.WriteAllText(filePath, content); FileInfo fileInfo = new FileInfo(filePath); fileInfo.IsReadOnly = true;
                MessageBox.Show("Changes accepted and file read-only again.","Awesome! successfully saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) {MessageBox.Show("Error: " + ex.Message);}
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/@leStripeZ") { UseShellExecute = true });
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/@GTABOSS9AN9") { UseShellExecute = true });
            Process.Start(new ProcessStartInfo("https://www.instagram.com/giovanni.marucchio") { UseShellExecute = true }); 
            Process.Start(new ProcessStartInfo("https://www.facebook.com/giovanni.marucchio") { UseShellExecute = true });
            Process.Start(new ProcessStartInfo("https://github.com/BA55H4XQR1337") { UseShellExecute = true });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("To use this tool, simply click the 'Apply' button. The program has already automatically adjusted all the settings as shown in the video, so you don't need to make any changes yourself.","How to Use",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vm.tiktok.com/ZNddTyGAr/") { UseShellExecute = true });
        }
    }
}
