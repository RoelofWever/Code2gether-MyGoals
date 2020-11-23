
namespace MyGoals
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TcMain = new System.Windows.Forms.TabControl();
            this.TpOverview = new System.Windows.Forms.TabPage();
            this.TcGoals = new System.Windows.Forms.TabControl();
            this.TpCreateGoal = new System.Windows.Forms.TabPage();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TbStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbNameOfGoal = new System.Windows.Forms.TextBox();
            this.LbGoalSteps = new System.Windows.Forms.ListBox();
            this.LblNameOfGoal = new System.Windows.Forms.Label();
            this.TcMain.SuspendLayout();
            this.TpOverview.SuspendLayout();
            this.TpCreateGoal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TcMain
            // 
            this.TcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcMain.Controls.Add(this.TpOverview);
            this.TcMain.Controls.Add(this.TpCreateGoal);
            this.TcMain.ItemSize = new System.Drawing.Size(100, 22);
            this.TcMain.Location = new System.Drawing.Point(0, 0);
            this.TcMain.Name = "TcMain";
            this.TcMain.Padding = new System.Drawing.Point(3, 3);
            this.TcMain.SelectedIndex = 0;
            this.TcMain.Size = new System.Drawing.Size(524, 391);
            this.TcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TcMain.TabIndex = 4;
            // 
            // TpOverview
            // 
            this.TpOverview.Controls.Add(this.TcGoals);
            this.TpOverview.Location = new System.Drawing.Point(4, 26);
            this.TpOverview.Name = "TpOverview";
            this.TpOverview.Padding = new System.Windows.Forms.Padding(3);
            this.TpOverview.Size = new System.Drawing.Size(516, 361);
            this.TpOverview.TabIndex = 0;
            this.TpOverview.Text = "Overview";
            this.TpOverview.UseVisualStyleBackColor = true;
            // 
            // TcGoals
            // 
            this.TcGoals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcGoals.Location = new System.Drawing.Point(0, 0);
            this.TcGoals.Name = "TcGoals";
            this.TcGoals.SelectedIndex = 0;
            this.TcGoals.Size = new System.Drawing.Size(512, 357);
            this.TcGoals.TabIndex = 6;
            // 
            // TpCreateGoal
            // 
            this.TpCreateGoal.BackColor = System.Drawing.Color.DarkGray;
            this.TpCreateGoal.Controls.Add(this.BtnStart);
            this.TpCreateGoal.Controls.Add(this.BtnAdd);
            this.TpCreateGoal.Controls.Add(this.TbStep);
            this.TpCreateGoal.Controls.Add(this.label2);
            this.TpCreateGoal.Controls.Add(this.label1);
            this.TpCreateGoal.Controls.Add(this.TbNameOfGoal);
            this.TpCreateGoal.Controls.Add(this.LbGoalSteps);
            this.TpCreateGoal.Controls.Add(this.LblNameOfGoal);
            this.TpCreateGoal.Location = new System.Drawing.Point(4, 26);
            this.TpCreateGoal.Name = "TpCreateGoal";
            this.TpCreateGoal.Padding = new System.Windows.Forms.Padding(3);
            this.TpCreateGoal.Size = new System.Drawing.Size(516, 361);
            this.TpCreateGoal.TabIndex = 1;
            this.TpCreateGoal.Text = "Create a goal";
            // 
            // BtnStart
            // 
            this.BtnStart.Enabled = false;
            this.BtnStart.Location = new System.Drawing.Point(377, 319);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 5;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Enabled = false;
            this.BtnAdd.Location = new System.Drawing.Point(377, 41);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TbStep
            // 
            this.TbStep.BackColor = System.Drawing.SystemColors.Menu;
            this.TbStep.Location = new System.Drawing.Point(132, 42);
            this.TbStep.Name = "TbStep";
            this.TbStep.Size = new System.Drawing.Size(239, 20);
            this.TbStep.TabIndex = 2;
            this.TbStep.TextChanged += new System.EventHandler(this.TbStep_TextChanged);
            this.TbStep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbStep_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Steps to reach goal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Steps to reach goal";
            // 
            // TbNameOfGoal
            // 
            this.TbNameOfGoal.BackColor = System.Drawing.SystemColors.Menu;
            this.TbNameOfGoal.Location = new System.Drawing.Point(132, 16);
            this.TbNameOfGoal.Name = "TbNameOfGoal";
            this.TbNameOfGoal.Size = new System.Drawing.Size(239, 20);
            this.TbNameOfGoal.TabIndex = 1;
            this.TbNameOfGoal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbNameOfGoal_KeyDown);
            // 
            // LbGoalSteps
            // 
            this.LbGoalSteps.BackColor = System.Drawing.SystemColors.Menu;
            this.LbGoalSteps.FormattingEnabled = true;
            this.LbGoalSteps.Location = new System.Drawing.Point(132, 65);
            this.LbGoalSteps.Name = "LbGoalSteps";
            this.LbGoalSteps.Size = new System.Drawing.Size(239, 277);
            this.LbGoalSteps.TabIndex = 4;
            // 
            // LblNameOfGoal
            // 
            this.LblNameOfGoal.AutoSize = true;
            this.LblNameOfGoal.Location = new System.Drawing.Point(23, 23);
            this.LblNameOfGoal.Name = "LblNameOfGoal";
            this.LblNameOfGoal.Size = new System.Drawing.Size(70, 13);
            this.LblNameOfGoal.TabIndex = 0;
            this.LblNameOfGoal.Text = "Name of goal";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 397);
            this.Controls.Add(this.TcMain);
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My goals";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TcMain.ResumeLayout(false);
            this.TpOverview.ResumeLayout(false);
            this.TpCreateGoal.ResumeLayout(false);
            this.TpCreateGoal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TcMain;
        private System.Windows.Forms.TabPage TpOverview;
        private System.Windows.Forms.TabPage TpCreateGoal;
        private System.Windows.Forms.TextBox TbStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbNameOfGoal;
        private System.Windows.Forms.ListBox LbGoalSteps;
        private System.Windows.Forms.Label LblNameOfGoal;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TabControl TcGoals;
        private System.Windows.Forms.Button BtnStart;
    }
}

