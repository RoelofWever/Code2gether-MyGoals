using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;



//REMARK
// in design time the following properties are set for TcMain
// to hide the tabs from the tabcontrol
// TcMain.Appearance = TabAppearance.FlatButtons;
// TcMain.ItemSize = new Size(0, 1);
// they are set again in the form loaded to make sure hey stay hidden



namespace MyGoals
{

    public partial class Mainform : Form
    {
        
        private const string ProgressBarPrefix = "Pb";
        private const string CheckListBoxPrefix = "Clb";
        private const string ButtonPrefix = "Btn";

        private string GetXMlFileName()
        {
            var filename = "Goals.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, filename);
        }

        private class MyListboxItem
        {
            public string Caption { get; set; }
            public int Index { get; set; }
        }

        // use a BindingList so we can display steps in a listbox
        private readonly BindingList<MyListboxItem> MyLbItems = new BindingList<MyListboxItem>();

        public Mainform()
        {
            InitializeComponent();
            LbGoalSteps.DataSource = MyLbItems;
            LbGoalSteps.DisplayMember = "Caption";
            LbGoalSteps.ValueMember = "Index";
        }


        // Create a step and add it to our own list
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MyLbItems.Add(new MyListboxItem { Index = MyLbItems.Count, Caption = TbStep.Text });
            TbStep.Clear();
            TbStep.Focus();
            EnableBtnDone();
        }

        private void EnableBtnDone()
        {
            BtnStart.Enabled = MyLbItems.Count > 0 && !string.IsNullOrEmpty(TbNameOfGoal.Text);
        }

        private void TbStep_TextChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = (sender as TextBox).Text != "";
        }

        private void TbStep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAdd_Click(null, null); 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadXml();
            // if ther is no xml then there are no Goals to show 
            // so let the users create one first
            if (TcGoals.TabPages.Count == 0)
                TcMain.SelectedIndex = 1;
        }

        // create a tabpage with a few controls so the use can adjust the progress
        private TabPage MakeGoalTabPage( string Caption, int Index)
        {
            TabPage _tpTmp = new TabPage()
            {
                Text = Caption,
                BackColor = Color.DarkGray,
        };

            ProgressBar Pb = new ProgressBar()
            {
                Name = ProgressBarPrefix + Index.ToString(),
                Parent = _tpTmp,
                Left = 10,
                Top = 10,
                Height = 15,
                Width = 450,
            };
            CheckedListBox Clb = new CheckedListBox()
            {
                Name = CheckListBoxPrefix + Index.ToString(),
                BackColor = SystemColors.Menu,
                Parent = _tpTmp,
                Left = 10,
                Top = 38,
                Width = 237,
                Height = 277,
            };

            Button Btn = new Button()
            {
                Name = ButtonPrefix + Index.ToString(),
                UseVisualStyleBackColor = true,
                Parent = _tpTmp,
                Left = 250,
                Top = 290,
                Text = "Done",
                Enabled = false,
            };

            // add the steps to the checklistbox
            for (int i = 0; i < MyLbItems.Count; i++)
            {
                Clb.Items.Add(MyLbItems[i].Caption);
            }

            Clb.ItemCheck += new ItemCheckEventHandler(this.ItemChecked);
            Pb.Maximum = Clb.Items.Count;
            Btn.Click += CloseTab;
            return _tpTmp;
        }

        // user checked a step of a goal
        private void ItemChecked(object sender, ItemCheckEventArgs e)
        {
            // find the active tabpage
            // this could also be done by this
            // TabPage _tpTmp = tcGoals.SelectedTab;
            TabPage _tpTmp = ((CheckedListBox)sender).Parent as TabPage;

            // get the name of the component that triggerd this event 
            // we know it has to be a CheckedListBox because thats the control we added the event to
            string _componentname = ((CheckedListBox)sender).Name;
            // now find the progressbar on the tabpage change the component prefix to the one used for the progressbar
            ProgressBar Pb = (ProgressBar)_tpTmp.Controls.Find(_componentname.Replace(CheckListBoxPrefix, ProgressBarPrefix), false).FirstOrDefault();

            // find out how many checkboxes are checked
            // the amount will be the amout before the user did something

            // from MS Documentation
            // Remarks
            //  The check state is not updated until after the ItemCheck event occurs.

            var _amountChecked = ((CheckedListBox)sender).CheckedItems.Count;
            // Did the user add or remove a check?
            if (e.NewValue == CheckState.Checked)
            {
                _amountChecked++;
            }
            else
            {
                _amountChecked--;
            }

            // Adjust the progressbar acordingly
            if (Pb != null)
            {
                Pb.Value = _amountChecked;
            }
            Button btn = (Button)_tpTmp.Controls.Find(_componentname.Replace(CheckListBoxPrefix, ButtonPrefix), false).FirstOrDefault();
            btn.Enabled = Pb.Value == Pb.Maximum;
        }

        // user has defined a goal put it in view so the user can keep track of its progress
        private void BtnDone_Click(object sender, EventArgs e)
        {
            TcMain.SelectedIndex = 0;
            TcGoals.TabPages.Add(MakeGoalTabPage(TbNameOfGoal.Text, TcGoals.TabPages.Count));
        }

        // save all goals to a XML file so we can load them again the next time
        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            // and save it 
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = ("    "),
                CloseOutput = true,
                OmitXmlDeclaration = true
            };

            // with the using we don't have to worry about disposing the things we created they will be desposed once they are out of scope
            using (XmlWriter writer = XmlWriter.Create(GetXMlFileName(), settings))
            {
                writer.WriteStartElement("Goals");
                for (int idx = 0; idx < TcGoals.TabPages.Count; idx++)
                {
                    writer.WriteStartElement("Goal");
                    writer.WriteElementString("Name", TcGoals.TabPages[idx].Text);
                    CheckedListBox Clb = (CheckedListBox)TcGoals.TabPages[idx].Controls.Find(CheckListBoxPrefix + idx.ToString(), false).FirstOrDefault();
                    if (Clb != null)
                    {
                        writer.WriteStartElement("Steps");
                        for (int idy = 0; idy < Clb.Items.Count; idy++)
                        {
                            writer.WriteStartElement("Step");
                            writer.WriteElementString("Name", Clb.Items[idy].ToString());
                            writer.WriteElementString("Done", Clb.GetItemChecked(idy).ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.Flush();
            }
        }

        private void LoadXml()
        {
            if (File.Exists(GetXMlFileName()))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GetXMlFileName());
                XmlNode root = doc.FirstChild;

                //Display the contents of the child nodes.
                if (root.HasChildNodes)
                {
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {
                        if (root.ChildNodes[i].HasChildNodes)
                        {
                            TabPage _tp = MakeGoalTabPage(root.ChildNodes[i].ChildNodes[0].InnerText, TcGoals.TabPages.Count);
                            ProgressBar _pb = (ProgressBar)_tp.Controls.Find(ProgressBarPrefix + TcGoals.TabPages.Count.ToString(), true).FirstOrDefault();
                            CheckedListBox _clb = (CheckedListBox)_tp.Controls.Find(CheckListBoxPrefix + TcGoals.TabPages.Count.ToString(), true).FirstOrDefault();
                            for (int J = 0; J < root.ChildNodes[i].ChildNodes.Count; J++)
                            {
                                if (_pb != null && _clb != null)
                                {
                                    _pb.Maximum = root.ChildNodes[i].ChildNodes[J].ChildNodes.Count;
                                    for (int Y = 0; Y < root.ChildNodes[i].ChildNodes[J].ChildNodes.Count; Y++)
                                    {
                                        if (root.ChildNodes[i].ChildNodes[J].ChildNodes[Y].ChildNodes.Count > 0)
                                        {
                                            _clb.Items.Add(root.ChildNodes[i].ChildNodes[J].ChildNodes[Y].ChildNodes[0].InnerText,
                                                           bool.Parse(root.ChildNodes[i].ChildNodes[J].ChildNodes[Y].ChildNodes[1].InnerText));
                                        }
                                    }
                                }
                            }
                            TcGoals.TabPages.Add(_tp);
                        }
                    }
                }
            }
        }

        // let the user add a new goal but make sure everything is cleared first
        private void CreateGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TbNameOfGoal.Clear();
            TbStep.Clear();
            MyLbItems.Clear();
            TcMain.SelectedIndex = 1;
        }

        private void TbNameOfGoal_KeyDown(object sender, KeyEventArgs e)
        {
            EnableBtnDone();
        }

        private void CloseTab(object sender, EventArgs e)
        {
            TcGoals.SelectedTab.Dispose();
        }
    }
}
