namespace SpotifyRecorder
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RecordButton = new System.Windows.Forms.Button();
            this.FetchTitleTimer = new System.Windows.Forms.Timer(this.components);
            this.FetchInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.TrackWatchdog = new System.Windows.Forms.Timer(this.components);
            this.PlaylistModeCheckBox = new System.Windows.Forms.CheckBox();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_UpdaterTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ArtworkPB = new System.Windows.Forms.PictureBox();
            this.GitHubRepLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ArtworkPB)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(12, 316);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(97, 23);
            this.RecordButton.TabIndex = 0;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.Record_Click);
            // 
            // FetchTitleTimer
            // 
            this.FetchTitleTimer.Enabled = true;
            this.FetchTitleTimer.Interval = 150;
            this.FetchTitleTimer.Tick += new System.EventHandler(this.FetchTitleTimer_Tick);
            // 
            // FetchInfoTimer
            // 
            this.FetchInfoTimer.Enabled = true;
            this.FetchInfoTimer.Interval = 250;
            // 
            // TrackWatchdog
            // 
            this.TrackWatchdog.Enabled = true;
            this.TrackWatchdog.Interval = 250;
            this.TrackWatchdog.Tick += new System.EventHandler(this.TrackWatchdog_Tick);
            // 
            // PlaylistModeCheckBox
            // 
            this.PlaylistModeCheckBox.AutoSize = true;
            this.PlaylistModeCheckBox.Checked = true;
            this.PlaylistModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlaylistModeCheckBox.Location = new System.Drawing.Point(115, 320);
            this.PlaylistModeCheckBox.Name = "PlaylistModeCheckBox";
            this.PlaylistModeCheckBox.Size = new System.Drawing.Size(88, 17);
            this.PlaylistModeCheckBox.TabIndex = 2;
            this.PlaylistModeCheckBox.Text = "Playlist Mode";
            this.PlaylistModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SongNameLabel.Location = new System.Drawing.Point(12, 275);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(260, 23);
            this.SongNameLabel.TabIndex = 5;
            this.SongNameLabel.Text = "TheBitBrine\'s Spotify Recorder v0.1";
            this.SongNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 1);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // UI_UpdaterTimer
            // 
            this.UI_UpdaterTimer.Enabled = true;
            this.UI_UpdaterTimer.Interval = 350;
            this.UI_UpdaterTimer.Tick += new System.EventHandler(this.UI_UpdaterTimer_Tick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ArtworkPB
            // 
            this.ArtworkPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArtworkPB.Image = global::SpotifyRecorder.Properties.Resources.vinyl;
            this.ArtworkPB.InitialImage = global::SpotifyRecorder.Properties.Resources.vinyl;
            this.ArtworkPB.Location = new System.Drawing.Point(12, 12);
            this.ArtworkPB.Name = "ArtworkPB";
            this.ArtworkPB.Size = new System.Drawing.Size(258, 258);
            this.ArtworkPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArtworkPB.TabIndex = 4;
            this.ArtworkPB.TabStop = false;
            // 
            // GitHubRepLink
            // 
            this.GitHubRepLink.AutoSize = true;
            this.GitHubRepLink.Cursor = System.Windows.Forms.Cursors.Default;
            this.GitHubRepLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GitHubRepLink.Location = new System.Drawing.Point(209, 321);
            this.GitHubRepLink.Name = "GitHubRepLink";
            this.GitHubRepLink.Size = new System.Drawing.Size(63, 13);
            this.GitHubRepLink.TabIndex = 7;
            this.GitHubRepLink.TabStop = true;
            this.GitHubRepLink.Text = "GitHub Rep";
            this.GitHubRepLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.GitHubRepLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubRepLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 351);
            this.Controls.Add(this.GitHubRepLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SongNameLabel);
            this.Controls.Add(this.ArtworkPB);
            this.Controls.Add(this.PlaylistModeCheckBox);
            this.Controls.Add(this.RecordButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheBitBrine\'s Spotify Recorder ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ArtworkPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Timer FetchTitleTimer;
        private System.Windows.Forms.Timer FetchInfoTimer;
        private System.Windows.Forms.Timer TrackWatchdog;
        private System.Windows.Forms.CheckBox PlaylistModeCheckBox;
        private System.Windows.Forms.PictureBox ArtworkPB;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer UI_UpdaterTimer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel GitHubRepLink;
    }
}

