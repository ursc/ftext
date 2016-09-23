namespace ftext
{
    partial class Form1
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.foundDataGridView = new System.Windows.Forms.DataGridView();
            this.ColLayout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.findTextBox = new System.Windows.Forms.WatermarkTextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.caseCheckBox = new System.Windows.Forms.CheckBox();
            this.rxCheckBox = new System.Windows.Forms.CheckBox();
            this.historyDataGridView = new System.Windows.Forms.DataGridView();
            this.ColHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scaleTrackBar = new System.Windows.Forms.TrackBar();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.foundDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // foundDataGridView
            // 
            this.foundDataGridView.AllowUserToAddRows = false;
            this.foundDataGridView.AllowUserToResizeRows = false;
            this.foundDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foundDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foundDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLayout,
            this.ColObject,
            this.ColText});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.foundDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.foundDataGridView.Location = new System.Drawing.Point(4, 4);
            this.foundDataGridView.MultiSelect = false;
            this.foundDataGridView.Name = "foundDataGridView";
            this.foundDataGridView.ReadOnly = true;
            this.foundDataGridView.RowHeadersVisible = false;
            this.foundDataGridView.RowHeadersWidth = 40;
            this.foundDataGridView.RowTemplate.Height = 18;
            this.foundDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.foundDataGridView.Size = new System.Drawing.Size(588, 454);
            this.foundDataGridView.TabIndex = 0;
            this.foundDataGridView.SelectionChanged += new System.EventHandler(this.foundDataGridView_SelectionChanged);
            // 
            // ColLayout
            // 
            this.ColLayout.FillWeight = 150F;
            this.ColLayout.HeaderText = "Layout";
            this.ColLayout.Name = "ColLayout";
            this.ColLayout.ReadOnly = true;
            this.ColLayout.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLayout.ToolTipText = "Layout";
            this.ColLayout.Width = 150;
            // 
            // ColObject
            // 
            this.ColObject.FillWeight = 110F;
            this.ColObject.HeaderText = "Object";
            this.ColObject.Name = "ColObject";
            this.ColObject.ReadOnly = true;
            this.ColObject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColObject.ToolTipText = "Object";
            this.ColObject.Width = 110;
            // 
            // ColText
            // 
            this.ColText.FillWeight = 300F;
            this.ColText.HeaderText = "Text";
            this.ColText.Name = "ColText";
            this.ColText.ReadOnly = true;
            this.ColText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColText.ToolTipText = "Text";
            this.ColText.Width = 300;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.findTextBox);
            this.flowLayoutPanel1.Controls.Add(this.findButton);
            this.flowLayoutPanel1.Controls.Add(this.caseCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.rxCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.historyDataGridView);
            this.flowLayoutPanel1.Controls.Add(this.scaleTrackBar);
            this.flowLayoutPanel1.Controls.Add(this.errorLabel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(596, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(186, 426);
            this.flowLayoutPanel1.TabIndex = 11;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // findTextBox
            // 
            this.findTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.findTextBox.ForeColor = System.Drawing.Color.Gray;
            this.findTextBox.Location = new System.Drawing.Point(3, 3);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(180, 23);
            this.findTextBox.TabIndex = 6;
            this.findTextBox.Text = "Find what ...";
            this.findTextBox.WatermarkActive = true;
            this.findTextBox.WatermarkText = "Find what ...";
            this.findTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findTextBox_KeyDown);
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.findButton.Location = new System.Drawing.Point(3, 30);
            this.findButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(180, 23);
            this.findButton.TabIndex = 7;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // caseCheckBox
            // 
            this.caseCheckBox.Checked = true;
            this.caseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.caseCheckBox.Location = new System.Drawing.Point(3, 57);
            this.caseCheckBox.Name = "caseCheckBox";
            this.caseCheckBox.Size = new System.Drawing.Size(180, 19);
            this.caseCheckBox.TabIndex = 4;
            this.caseCheckBox.Text = "Ignore case";
            this.caseCheckBox.UseVisualStyleBackColor = true;
            // 
            // rxCheckBox
            // 
            this.rxCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rxCheckBox.Location = new System.Drawing.Point(3, 82);
            this.rxCheckBox.Name = "rxCheckBox";
            this.rxCheckBox.Size = new System.Drawing.Size(180, 19);
            this.rxCheckBox.TabIndex = 5;
            this.rxCheckBox.Text = "Regular expression";
            this.rxCheckBox.UseVisualStyleBackColor = true;
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AllowUserToAddRows = false;
            this.historyDataGridView.AllowUserToResizeRows = false;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.ColumnHeadersVisible = false;
            this.historyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColHistory});
            this.historyDataGridView.Location = new System.Drawing.Point(3, 107);
            this.historyDataGridView.MultiSelect = false;
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.ReadOnly = true;
            this.historyDataGridView.RowHeadersVisible = false;
            this.historyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyDataGridView.Size = new System.Drawing.Size(180, 250);
            this.historyDataGridView.TabIndex = 12;
            this.historyDataGridView.SelectionChanged += new System.EventHandler(this.historyDataGridView_SelectionChanged);
            this.historyDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.historyDataGridView_UserDeletingRow);
            // 
            // ColHistory
            // 
            this.ColHistory.FillWeight = 150F;
            this.ColHistory.HeaderText = "History";
            this.ColHistory.Name = "ColHistory";
            this.ColHistory.ReadOnly = true;
            this.ColHistory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColHistory.Width = 150;
            // 
            // scaleTrackBar
            // 
            this.scaleTrackBar.LargeChange = 2;
            this.scaleTrackBar.Location = new System.Drawing.Point(3, 363);
            this.scaleTrackBar.Minimum = 1;
            this.scaleTrackBar.Name = "scaleTrackBar";
            this.scaleTrackBar.Size = new System.Drawing.Size(180, 45);
            this.scaleTrackBar.TabIndex = 12;
            this.scaleTrackBar.Value = 10;
            this.scaleTrackBar.ValueChanged += new System.EventHandler(this.scaleTrackBar_ValueChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.errorLabel.Location = new System.Drawing.Point(3, 411);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(180, 15);
            this.errorLabel.TabIndex = 12;
            this.errorLabel.Text = "zoom error";
            this.errorLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.foundDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Search text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.foundDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.DataGridView foundDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox caseCheckBox;
        private System.Windows.Forms.CheckBox rxCheckBox;
        private System.Windows.Forms.WatermarkTextBox findTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.DataGridView historyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHistory;
        private System.Windows.Forms.TrackBar scaleTrackBar;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColText;

    }
}
