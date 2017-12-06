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
            this.FetchTitleTimer = new System.Windows.Forms.Timer(this.components);
            this.FetchInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.TrackWatchdog = new System.Windows.Forms.Timer(this.components);
            this.PlaylistModeCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.SongNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.UI_UpdaterTimer = new System.Windows.Forms.Timer(this.components);
            this.ExportLocationBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.RecordButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.GitHubLink = new System.Windows.Forms.PictureBox();
            this.ArtworkPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GitHubLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtworkPB)).BeginInit();
            this.SuspendLayout();
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
            this.PlaylistModeCheckBox.Depth = 0;
            this.PlaylistModeCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.PlaylistModeCheckBox.Location = new System.Drawing.Point(113, 372);
            this.PlaylistModeCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.PlaylistModeCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PlaylistModeCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PlaylistModeCheckBox.Name = "PlaylistModeCheckBox";
            this.PlaylistModeCheckBox.Ripple = true;
            this.PlaylistModeCheckBox.Size = new System.Drawing.Size(113, 30);
            this.PlaylistModeCheckBox.TabIndex = 2;
            this.PlaylistModeCheckBox.Text = "Playlist Mode";
            this.PlaylistModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.Depth = 0;
            this.SongNameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.SongNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SongNameLabel.Location = new System.Drawing.Point(7, 333);
            this.SongNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(260, 23);
            this.SongNameLabel.TabIndex = 5;
            this.SongNameLabel.Text = "TheBitBrine\'s Spotify Recorder v0.2";
            this.SongNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 363);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 1);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // UI_UpdaterTimer
            // 
            this.UI_UpdaterTimer.Enabled = true;
            this.UI_UpdaterTimer.Interval = 350;
            this.UI_UpdaterTimer.Tick += new System.EventHandler(this.UI_UpdaterTimer_Tick);
            // 
            // ExportLocationBrowse
            // 
            this.ExportLocationBrowse.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // RecordButton
            // 
            this.RecordButton.Depth = 0;
            this.RecordButton.Location = new System.Drawing.Point(7, 374);
            this.RecordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Primary = true;
            this.RecordButton.Size = new System.Drawing.Size(100, 28);
            this.RecordButton.TabIndex = 8;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.Record_Click);
            // 
            // GitHubLink
            // 
            this.GitHubLink.Image = global::SpotifyRecorder.Properties.Resources.GitHubLogo;
            this.GitHubLink.Location = new System.Drawing.Point(238, 375);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(23, 23);
            this.GitHubLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GitHubLink.TabIndex = 9;
            this.GitHubLink.TabStop = false;
            this.GitHubLink.Click += new System.EventHandler(this.GitHubLink_Click);
            // 
            // ArtworkPB
            // 
            this.ArtworkPB.Image = global::SpotifyRecorder.Properties.Resources.vinyl;
            this.ArtworkPB.InitialImage = global::SpotifyRecorder.Properties.Resources.vinyl;
            this.ArtworkPB.Location = new System.Drawing.Point(7, 70);
            this.ArtworkPB.Name = "ArtworkPB";
            this.ArtworkPB.Size = new System.Drawing.Size(258, 258);
            this.ArtworkPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArtworkPB.TabIndex = 4;
            this.ArtworkPB.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(271, 409);
            this.Controls.Add(this.GitHubLink);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SongNameLabel);
            this.Controls.Add(this.ArtworkPB);
            this.Controls.Add(this.PlaylistModeCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheBitBrine\'s Spotify Recorder ";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GitHubLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtworkPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer FetchTitleTimer;
        private System.Windows.Forms.Timer FetchInfoTimer;
        private System.Windows.Forms.Timer TrackWatchdog;
        private MaterialSkin.Controls.MaterialCheckBox PlaylistModeCheckBox;
        private System.Windows.Forms.PictureBox ArtworkPB;
        private MaterialSkin.Controls.MaterialLabel SongNameLabel;
        private MaterialSkin.Controls.MaterialLabel label1;
        private System.Windows.Forms.Timer UI_UpdaterTimer;
        private System.Windows.Forms.FolderBrowserDialog ExportLocationBrowse;
        private MaterialSkin.Controls.MaterialRaisedButton RecordButton;
        private System.Windows.Forms.PictureBox GitHubLink;
    }
}

