using NAudio.Lame;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SpotifyAPI;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using TagLib;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MaterialSkin.Controls;
using MaterialSkin;

namespace SpotifyRecorder
{
    public partial class Form1 : MaterialForm
    {
        public static LameMP3FileWriter Writer;
        public static IWaveIn waveIn;
        public string ExportFolder;
        public int BitRate = 320;

        //-----Track Info-----
        public string Artist;
        public string Album;
        public string TrackName;
        public Bitmap Artwork;

        //-----UI STUFF-----
        public string SongNameFromWindowTitle = ""; //We need to read it for MP3 file name from the window title becuase local API is not fast enough.
        public bool Busy = false;
        public bool Playing = false;
        public bool RecordPressed = false;
        public bool RecordingCompleted = false;

        //-----Spotify API-----
        public static SpotifyLocalAPI SpotifyAPI;
        public StatusResponse Status;

        //-----Stats-----
        public int TotalCount = 0;
        public List<string> RecordedSongs = new List<string>();

        //-----Threads-----
        Thread MainThread;
        ThreadStart MainThreadStart;


        #region UI.Methods
        public Form1()
        {
            InitializeComponent();

            //Initializing Material Skin Colorscheme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            FetchNameFromTitle();
            FireUpTheLocalAPI();
            FetchTrackInfo();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try /*To Kill Possible Remaining Threads*/
            {
                MainThread.Interrupt();
                MainThread.Abort();
                System.Environment.Exit(0);
            }
            catch
            { /*Doesn't Matter*/}
        }



        private void GitHubLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/thebitbrine/spotify-recorder");
        }

        private void Record_Click(object sender, EventArgs e)
        {
            FireUpTheLocalAPI();

            
            if (RecordPressed == false)
            {
                //Notify the user about low volume on Spotify Client
                if (Status.Volume < 1)
                {
                    MessageBox.Show("Please set your Spotify Player's volume to 100% for the best results.", "Low Volume", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Start Recording (Threaded)
                if (string.IsNullOrWhiteSpace(ExportFolder) == true)
                {
                    ExportLocationBrowse.ShowDialog();
                    ExportFolder = ExportLocationBrowse.SelectedPath;
                }
                if (string.IsNullOrWhiteSpace(ExportFolder) == false)
                {
                    RecordStarter();
                    RecordPressed = true;
                    RecordButton.Text = "Stop";
                }
            }
            else
            {
                SpotifyAPI.Pause();
                Restart();
            }
        }

        public void Restart()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C echo 1 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit();
        }
        
        #endregion

        #region FetchInfo
        public void FetchNameFromTitle()
        {
            Process[] AllPossibleProcesses = Process.GetProcessesByName("Spotify");
            foreach (var MainProcess in AllPossibleProcesses)
            {
                if (string.IsNullOrWhiteSpace(MainProcess.MainWindowTitle) == false)
                {
                    SongNameFromWindowTitle = MainProcess.MainWindowTitle;
                }
            }
        }

        public void FireUpTheLocalAPI()
        {
            if (SpotifyLocalAPI.IsSpotifyRunning() == false)
            {
                SpotifyLocalAPI.RunSpotify();
                while (SpotifyLocalAPI.IsSpotifyRunning() == false) { }
            }

            if (SpotifyLocalAPI.IsSpotifyWebHelperRunning() == false)
            {
                SpotifyLocalAPI.RunSpotifyWebHelper();
                while (SpotifyLocalAPI.IsSpotifyWebHelperRunning() == false) { }
            }

            if (SpotifyAPI != null)
            {
                Status = SpotifyAPI.GetStatus();
            }
            else
            {
                localConnect();
                Status = SpotifyAPI.GetStatus();
            }
        }
        
        public void localConnect()
        {
            SpotifyAPI = new SpotifyLocalAPI();
            if (!SpotifyLocalAPI.IsSpotifyRunning())
                return;
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
                return;
            if (!SpotifyAPI.Connect())
                return;
        }

        public void FetchTrackInfo()
        {
            try
            {
                Artist = Status.Track.ArtistResource.Name;
                Album = Status.Track.AlbumResource.Name;
                TrackName = Status.Track.TrackResource.Name;
                Artwork = Status.Track.GetAlbumArt(AlbumArtSize.Size640);
            }
            catch { }
        }
        #endregion
        
        #region Record & Tag

        public void RecordStarter()
        {
            FetchNameFromTitle();
            FireUpTheLocalAPI();
            FetchTrackInfo();
            MainThreadStart = new ThreadStart(Record);
            MainThread = new Thread(MainThreadStart);
            MainThread.IsBackground = true;
            MainThread.Start();
        }

        public void Record()
        {
            //Begin No-GC
            GC.KeepAlive(Writer);
            GC.KeepAlive(waveIn);

            FireUpTheLocalAPI();

            SpotifyAPI.Pause();

            //Time to sleep to prevent lower-level crashes dependent to LAME Library
            Thread.Sleep(5000);

            //Reset The Track Playing Position
            SpotifyAPI.Skip();
            Thread.Sleep(250); //Wait 250ms to prevent Spotify Player from losing its shit
            SpotifyAPI.Previous();
            SpotifyAPI.Pause();

            RecordingCompleted = false;
            Busy = true;
            FetchTrackInfo();
            string TempTrackName = TrackName;
            string TempArtist = Artist;
            string TempAlbum = Album;
            Bitmap TempArtwork = Artwork;
            Busy = false;

            waveIn = new WasapiLoopbackCapture();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.RecordingStopped += waveIn_RecordingStopped;

            SpotifyAPI.ListenForEvents = true;


            //READY?
            while (SpotifyAPI.GetStatus().Playing == false)
            {
                SpotifyAPI.Play();
                if (SpotifyAPI.GetStatus().Playing == false)
                    Thread.Sleep(100);
            }
            
            //AIM
            FetchNameFromTitle();
            while (SongNameFromWindowTitle == "Spotify") { }
            string TempName = SongNameFromWindowTitle;

            //Remove Illegal Characters From Path
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string Filename = ExportFolder + @"\" + r.Replace(TempName, "") + ".mp3";
            Writer = new LameMP3FileWriter(Filename, waveIn.WaveFormat, LAMEPreset.INSANE, null);


            //SHOOT!
            waveIn.StartRecording();


            while (TempName == SongNameFromWindowTitle) { FetchNameFromTitle(); }

            //Skip And Previous For Setting The Track's Time Position To 0 And Pause The Song Until It Exits
            SpotifyAPI.Skip();
            SpotifyAPI.Previous();
            SpotifyAPI.Pause();

            //Flush, Write And Exit
            waveIn.StopRecording();
            Thread.Sleep(750);

            Writer.Flush();
            waveIn.Dispose();
            Writer.Dispose();

            //Tag With Correct Info
            lock (TempArtwork)
            TagTheMP3(Filename, TempTrackName, TempArtist, TempAlbum, (Bitmap)TempArtwork.Clone());
            
            //Pull Da Trigga
            RecordingCompleted = true;
            

            //Finally Kill The Thread
            MainThread.Abort();
        }

        public void TagTheMP3(string Filename, string _TrackName, string _Artist, string _Album, Bitmap _Artwork)
        {
            Busy = true;
            //Initialize Info
            if(_Album == _TrackName) { _Album = "Single"; }
            Bitmap TagArtwork = new Bitmap(_Artwork);
            TagLib.File TagFile = TagLib.File.Create(Filename);
            TagFile.Tag.Title = _TrackName;
            TagFile.Tag.Album = _Album;
            TagFile.Tag.Artists = new string[] { _Artist };
            TagFile.Tag.Comment = "Ripped From Spotify By TheBitBrine's Spotify Recorder";

            //Artwork Stuff
            TagLib.Picture TempArtwork = new TagLib.Picture();
            TempArtwork.Type = TagLib.PictureType.FrontCover;
            TempArtwork.Description = "Cover";
            TempArtwork.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
            MemoryStream ms = new MemoryStream();
            TagArtwork.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            TempArtwork.Data = TagLib.ByteVector.FromStream(ms);
            TagFile.Tag.Pictures = new TagLib.IPicture[] { TempArtwork };

            //Finally Write To File & Close Memory Stream
            TagFile.Save();
            ms.Close();
            Busy = false;
        }

        private void SpotifyAPI_OnTrackChange(object sender, TrackChangeEventArgs e)
        {
            SpotifyAPI.Pause();
        }

        static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            // signal that recording has finished
            //stopRecording = true;
        }

        static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // write recorded data to MP3 writer
            if (Writer != null)
                Writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        #endregion

        #region Timers
        private void FetchTitleTimer_Tick(object sender, EventArgs e)
        {
            FetchNameFromTitle();
        }

        private void TrackWatchdog_Tick(object sender, EventArgs e)
        {
            if (RecordingCompleted == true && MainThread.IsAlive == false && PlaylistModeCheckBox.Checked == true)
               RecordStarter();
        }

        private void UI_UpdaterTimer_Tick(object sender, EventArgs e)
        {
            if (Artwork != null && Busy == false)
            {
                if(RecordPressed == true)
                ArtworkPB.Image = Artwork;

                if(SongNameFromWindowTitle == "Spotify")
                {
                    SongNameLabel.Text = Artist + " - " + TrackName + " (Paused)";
                }
                else
                SongNameLabel.Text = SongNameFromWindowTitle;
            }
        }
        #endregion

    }
}
