using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using test;
using Twitter;

namespace FlatUI.Examples
{
    public partial class Twitter : Form
    {
        private Boolean ProgressOngoing = false;

        public Twitter()
        {
            InitializeComponent();
            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
            this.FlatAlertBox.Visible = true;
            this.FlatAlertBox.Text = "Welcome To Twitter Auto Voter.";
            OnFinish += Twitter_OnFinish;
            LoadAccounts();
            LoadOptions();
            TxtPostID.Text = Options.PostId;
            TxtFrom.Text = Options.From.ToString();
            TxtTo.Text = Options.To.ToString();
            IntInterval.Value = Options.Interval;
            IntVoteOption.Value = Options.Option;

        }

        private void Twitter_OnFinish(object sender, EventArgs e)
        {
            EnabledComp();
        }

        public static event EventHandler<EventArgs> OnFinish;


        private void DisabledComp()
        {
            TxtPostID.Enabled = TxtTo.Enabled = TxtFrom.Enabled = BtnAddAccounts.Enabled = BtnDeleteAccounts.Enabled = BtnRemoveCookies.Enabled = IntInterval.Enabled = IntVoteOption.Enabled = false;
            ProgressButton.Text = "Stop";
            ProgressButton.Refresh();
        }
        private void EnabledComp()
        {
            TxtPostID.Enabled = TxtTo.Enabled = TxtFrom.Enabled = BtnAddAccounts.Enabled = BtnDeleteAccounts.Enabled = BtnRemoveCookies.Enabled = IntInterval.Enabled = IntVoteOption.Enabled = true;
            ProgressButton.Text = "Start";
            ProgressButton.Refresh();
        }
        static Thread Job;
        private void ProgressButton_Click(object sender, EventArgs e)
        {
            if (ProgressButton.Text == "Stop")
            {
                if (Job != null)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    Job.Suspend();
                    EnabledComp();
                    ProgressButton.Text = "Resume";
                    ProgressButton.Refresh();
#pragma warning restore CS0618 // Type or member is obsolete
                    return;
                }
            }
            else
            {
                if (Job != null)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    Job.Resume();
                    ProgressButton.Text = "Stop";
                    DisabledComp();
#pragma warning restore CS0618 // Type or member is obsolete
                    return;
                }
            }

            try
            {
                new Uri(TxtPostID.Text);
            }
            catch (Exception)
            {
                this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                this.FlatAlertBox.Visible = true;
                this.FlatAlertBox.Text = "Please enter Post ID";
                return;

            }
            if (IntVoteOption.Value <= 0)
            {
                this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                this.FlatAlertBox.Visible = true;
                this.FlatAlertBox.Text = "Please enter Vote Option";
                return;
            }
            if (AccountsData.Count <= 0)
            {
                this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                this.FlatAlertBox.Visible = true;
                this.FlatAlertBox.Text = "Please add Accounts";
                return;
            }
            if (!int.TryParse(TxtFrom.Text, out int validFrom))
                TxtFrom.Text = "0";
            if (!int.TryParse(TxtTo.Text, out int validTo))
                TxtTo.Text = AccountsData.Count.ToString();

            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
            this.FlatAlertBox.Visible = true;
            this.FlatAlertBox.Text = "Start ...";

            if (!this.ProgressOngoing)
            {
                DisabledComp();
                this.ProgressOngoing = true;
                this.FlatProgressBar.Value = 0;
                int.TryParse(TxtTo.Text, out int VoteNumber);
                int.TryParse(TxtFrom.Text, out int from);
                SetText($"Twitter Auto Voter ({(VoteNumber == 0 ? (AccountsData.Count - from) : (VoteNumber - from))} / 0)");
                DoWork();

            }
        }



        void DoWork()
        {
            int.TryParse(TxtTo.Text, out int VoteNumber);
            int.TryParse(TxtFrom.Text, out int From);

            FlatProgressBar.Maximum = VoteNumber == 0 ? AccountsData.Count - From : VoteNumber - From;
            FlatProgressBar.Value = 0;
            long Number = VoteNumber - From;
            var Interval = IntInterval.Value;
            string uri = TxtPostID.Text;
            int selected_choice = (int)IntVoteOption.Value;
            Options.From = From;
            Options.To = VoteNumber;
            Options.Interval = (int)Interval;
            Options.Option = selected_choice;
            Options.PostId = uri;
            SaveOptions();
            Job = new Thread(() =>
            {
                for (int i = From; i < AccountsData.Count; i++)
                {
                    var data = AccountsData[i];
                    this.Invoke((MethodInvoker)delegate
                    {
                        Options.From++;
                        SaveOptions();
                    });

                    try
                    {
                        if (Number > 0 && Success >= Number)
                            break;
                        var twitter = new TwitterClient(data.UserName, data.Password, data.Verify);
                        twitter.CheckCookies();
                        bool success = false;
                        if (twitter.CookiesFound)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.RTStatus.AppendText($"\n[{DateTime.Now}] Cookies Found " + data.UserName);
                                success = true;
                            });
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.RTStatus.AppendText($"[{DateTime.Now}] Start Login Process");
                            });
                            success = twitter.Login();
                            if (success)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.RTStatus.AppendText($"\n[{DateTime.Now}] Success Login To " + data.UserName);
                                });
                            }
                        }
                        if (success)
                        {

                            twitter.Vote(uri, selected_choice);
                            Success++;
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.RTStatus.AppendText($"\n[{DateTime.Now}] Success Vote");
                            });
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.RTStatus.AppendText($"[{DateTime.Now}] Failed Vote");
                            });
                            Failed++;
                        }

                    }
                    catch (Exception)
                    {
                        Failed++;

                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.FlatProgressBar.Increment(1);
                    });
                    SetText($"Twitter Auto Voter ({this.FlatProgressBar.Value} / {(Number == 0 ? AccountsData.Count - From : Number - From)}) || Success= {Success} || Failed= {Failed}");

                    if (Interval > 0)
                        Thread.Sleep((int)Interval * 1000);
                }

                this.Invoke((MethodInvoker)delegate
                {
                    EnabledComp();
                    this.ProgressOngoing = false;
                    Success = Failed = 0;
                });



                Job = null;

            });
            Job.Start();

        }
        public static int Success = 0;
        public static int Failed = 0;

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (FormSkin.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                FormSkin.Invoke(d, new object[] { text });
            }
            else
            {
                FormSkin.Text = text;
                FormSkin.Refresh();
            }
        }
        private void SpawnAlertButton_Click(object sender, EventArgs e)
        {
            this.FlatAlertBox.Visible = false;
            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
            this.FlatAlertBox.Visible = true;
        }

        public static List<AccountInfo> AccountsData { get; set; } = new List<AccountInfo>();

        private void BtnAddAccounts_Click(object sender, EventArgs e)
        {
            if (FDList.ShowDialog() == DialogResult.OK)
            {
                AccountsData.Clear();
                string ext = Path.GetExtension(FDList.FileName);
                if (ext == ".txt")
                {
                    try
                    {
                        int Linecounter = 0;
                        int counter = 0;
                        string line;
                        StreamReader file = new StreamReader(FDList.FileName, System.Text.Encoding.UTF8, true);
                        while ((line = file.ReadLine()) != null)
                        {
                            Linecounter++;
                            if (!string.IsNullOrEmpty(line) && line.Split(':').Length >= 3)
                            {
                                string[] dataarr = line.Split(':');
                                if (dataarr[0].Length < 3 || dataarr[1].Length < 3 || dataarr[2].Length < 6)
                                    continue;
                                AccountsData.Add(new AccountInfo { UserName = dataarr[0], Password = dataarr[1], Verify = dataarr[2] });
                                counter++;
                            }

                        }
                        file.Close();

                        if (counter == Linecounter)
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data Success ...";
                        }
                        else
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Info;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data From {Linecounter} Line .";
                        }
                        TxtCount.Text = AccountsData.Count.ToString();
                        LoadAccountsList();
                    }
                    catch (Exception)
                    {
                        this.FlatAlertBox.Visible = false;
                        this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                        this.FlatAlertBox.Visible = true;
                        this.FlatAlertBox.Text = $"Error Invalid List File .";
                    }
                }
                else if (ext == ".xls" || ext == ".xlsx")
                {
                    try
                    {
                        int Linecounter = 0;
                        int counter = 0;
                        Microsoft.Office.Interop.Excel.Application xlApp = xlApp = new Microsoft.Office.Interop.Excel.Application();
                        Workbook xlWorkBook = xlApp.Workbooks.Open(FDList.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Range UsedRange = xlWorkSheet.UsedRange;
                        int lastUsedRow = UsedRange.Row + UsedRange.Rows.Count - 1;
                        foreach (Range row in UsedRange.Rows)
                        {
                            string UserName = (string)(row.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range).Value2;
                            string Password = (string)(row.Cells[1, 2] as Microsoft.Office.Interop.Excel.Range).Value2;
                            string Hotmail = (string)(row.Cells[1, 3] as Microsoft.Office.Interop.Excel.Range).Value2;
                            if (!string.IsNullOrEmpty(UserName) && UserName.Length >= 3 &&
                                !string.IsNullOrEmpty(Password) && Password.Length >= 3 &&
                                !string.IsNullOrEmpty(Hotmail) && Hotmail.Length >= 3)
                            {
                                AccountsData.Add(new AccountInfo { UserName = UserName, Password = Password, Verify = Hotmail });
                                counter++;
                            }
                            Linecounter++;
                        }

                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);
                        Marshal.ReleaseComObject(xlApp);
                        if (counter == Linecounter)
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data Success ...";
                        }
                        else
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Info;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data From {Linecounter} Line .";
                        }
                        TxtCount.Text = AccountsData.Count.ToString();
                        LoadAccountsList();
                    }
                    catch (Exception)
                    {
                        this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                        this.FlatAlertBox.Visible = true;
                        this.FlatAlertBox.Text = $"Error Invalid List File .";
                    }
                }
                else if (ext == ".csv")
                {
                    try
                    {
                        int Linecounter = 0;
                        int counter = 0;
                        string line;
                        StreamReader file = new StreamReader(FDList.FileName, System.Text.Encoding.UTF8, true);
                        while ((line = file.ReadLine()) != null)
                        {
                            Linecounter++;
                            if (!string.IsNullOrEmpty(line) && line.Split(',').Length >= 3)
                            {
                                string[] dataarr = line.Split(',');
                                if (dataarr[0].Length < 3 || dataarr[1].Length < 3 || dataarr[2].Length < 6)
                                    continue;
                                AccountsData.Add(new AccountInfo { UserName = dataarr[0], Password = dataarr[1], Verify = dataarr[2] });
                                counter++;
                            }

                        }
                        file.Close();

                        if (counter == Linecounter)
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data Success ...";
                        }
                        else
                        {
                            this.FlatAlertBox.Visible = false;
                            this.FlatAlertBox.kind = FlatAlertBox._Kind.Info;
                            this.FlatAlertBox.Visible = true;
                            this.FlatAlertBox.Text = $"Load {counter} Accounts Data From {Linecounter} Line .";
                        }
                        TxtCount.Text = AccountsData.Count.ToString();
                        LoadAccountsList();
                    }
                    catch (Exception)
                    {
                        this.FlatAlertBox.Visible = false;
                        this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                        this.FlatAlertBox.Visible = true;
                        this.FlatAlertBox.Text = $"Error Invalid List File .";
                    }
                }
            }

        }

        private void RemoveCookies()
        {
            try
            {
                Directory.Delete("Cookies", true);
                this.FlatAlertBox.Visible = false;
                this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
                this.FlatAlertBox.Visible = true;
                this.FlatAlertBox.Text = $"Delete Success.";
            }
            catch (Exception)
            {
                this.FlatAlertBox.Visible = false;
                this.FlatAlertBox.kind = FlatAlertBox._Kind.Error;
                this.FlatAlertBox.Visible = true;
                this.FlatAlertBox.Text = $"Error Path Not Found.";
            }

        }

        private void LoadAccountsList()
        {
            SaveAccounts();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Validator");
            AccountsData.ForEach(s =>
            {
                var row = dt.NewRow();
                row[0] = s.UserName;
                row[1] = s.Password;
                row[2] = s.Verify;
                dt.Rows.Add(row);
            });
            AccountsList.DataSource = dt;
            this.AccountsList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.AccountsList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.AccountsList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        void SaveAccounts()
        {
            try
            {
                using (StreamWriter file = File.CreateText(@"data.dat"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, AccountsData);
                }

            }
            catch (Exception ex)
            {

            }
        }
        public RunOptions Options { get; set; }
        public class RunOptions
        {
            public string PostId { get; set; }
            public int Option { get; set; }
            public int From { get; set; }
            public int To { get; set; }
            public int Interval { get; set; }
        }
        void SaveOptions()
        {
            try
            {
                using (StreamWriter file = File.CreateText(@"options.dat"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, Options);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void LoadOptions()
        {
            try
            {
                var txt = System.IO.File.ReadAllText("options.dat");
                Options = JsonConvert.DeserializeObject<RunOptions>(txt);
                if (Options == null)
                    Options = new RunOptions();

            }
            catch (Exception)
            {
                Options = new RunOptions();
            }
        }

        public void LoadAccounts()
        {
            try
            {
                var txt = System.IO.File.ReadAllText("data.dat");
                AccountsData = JsonConvert.DeserializeObject<List<AccountInfo>>(txt);
                if (AccountsData == null)
                    AccountsData = new List<AccountInfo>();
                TxtCount.Text = AccountsData.Count.ToString();
                LoadAccountsList();

            }
            catch (Exception)
            {
                AccountsData = new List<AccountInfo>();
            }
        }

        private void BtnDeleteAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure Delete Accounts ?", "Delete Accounts", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("Username");
                    dt.Columns.Add("Password");
                    dt.Columns.Add("Validator");
                    AccountsList.DataSource = dt;
                    AccountsData.Clear();
                    TxtCount.Text = "0";
                    this.FlatAlertBox.Visible = false;
                    this.FlatAlertBox.kind = FlatAlertBox._Kind.Success;
                    this.FlatAlertBox.Visible = true;
                    this.FlatAlertBox.Text = $"Delete Success.";
                    SaveAccounts();
                }

            }
            catch (Exception)
            {

            }
        }

        private void BtnRemoveCookies_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Remove Cookies ?", "Remove Cookies", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RemoveCookies();
            }
        }
    }
}
