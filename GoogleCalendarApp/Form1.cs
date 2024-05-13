using System;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Newtonsoft.Json;
using System.Threading;
using Microsoft.Win32;
using System.ComponentModel;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions;
using System.Drawing.Printing;
using System.Linq;
using System.Drawing.Text;
using System.Timers;

namespace GoogleCalendarApp
{
    public partial class Form1 : Form
    {
        NotifyIcon notifyIcon;
        private string AuthJsonFile;
        private string MailAdress;
        List<CheckBox> CheckBoxList = new List<CheckBox>();

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }

        [ComImport]
        [Guid("B92B56A9-8B55-4E14-9A89-0199BBB6F93B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IDesktopWallpaper
        {
            HRESULT SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.LPWStr)] string wallpaper);
            HRESULT GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.LPWStr)] ref string wallpaper);
            HRESULT GetMonitorDevicePathAt(uint monitorIndex, [MarshalAs(UnmanagedType.LPWStr)] ref string monitorID);
            HRESULT GetMonitorDevicePathCount(ref uint count);
            HRESULT GetMonitorRECT([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.Struct)] ref RECT displayRect);
            HRESULT SetBackgroundColor(uint color);
            HRESULT GetBackgroundColor(ref uint color);
            HRESULT SetPosition(DESKTOP_WALLPAPER_POSITION position);
            HRESULT GetPosition(ref DESKTOP_WALLPAPER_POSITION position);
            HRESULT SetSlideshowOptions(DESKTOP_SLIDESHOW_OPTIONS options, uint slideshowTick);
            [PreserveSig]
            HRESULT GetSlideshowOptions(out DESKTOP_SLIDESHOW_OPTIONS options, out uint slideshowTick);
            HRESULT AdvanceSlideshow([MarshalAs(UnmanagedType.LPWStr)] string monitorID, DESKTOP_SLIDESHOW_DIRECTION direction);
            HRESULT GetStatus(ref DESKTOP_SLIDESHOW_STATE state);
            HRESULT Enable(bool benable);
        }

        public enum DESKTOP_WALLPAPER_POSITION
        {
            DWPOS_CENTER = 0,
            DWPOS_TILE = 1,
            DWPOS_STRETCH = 2,
            DWPOS_FIT = 3,
            DWPOS_FILL = 4,
            DWPOS_SPAN = 5
        }

        public enum DESKTOP_SLIDESHOW_OPTIONS
        {
            DSO_SHUFFLEIMAGES = 0x1
        }

        public enum DESKTOP_SLIDESHOW_STATE
        {
            DSS_ENABLED = 0x1,
            DSS_SLIDESHOW = 0x2,
            DSS_DISABLED_BY_REMOTE_SESSION = 0x4
        }

        public enum DESKTOP_SLIDESHOW_DIRECTION
        {
            DSD_FORWARD = 0,
            DSD_BACKWARD = 1
        }


        [ComImport, Guid("C2CF3110-460E-4fc1-B9D0-8A1C0C9CC4BD")]
        public class DesktopWallpaperClass
        {
        }

        public enum HRESULT : int
        {
            S_OK = 0,
            S_FALSE = 1,
            E_NOINTERFACE = unchecked((int)0x80004002),
            E_NOTIMPL = unchecked((int)0x80004001),
            E_FAIL = unchecked((int)0x80004005)
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        string fonts = null;
        Color fontColor;
        System.Timers.Timer timer = new System.Timers.Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            IDesktopWallpaper pDesktopWallpaper = (IDesktopWallpaper)(new DesktopWallpaperClass());
            int position = 0;
            uint monitorCount = 0;
            pDesktopWallpaper.GetMonitorDevicePathCount(ref monitorCount);
            for (uint i = 0; i < monitorCount; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = "Display" + (i + 1).ToString();
                string DisplayTag = null;
                HRESULT hr = pDesktopWallpaper.GetMonitorDevicePathAt(i, ref DisplayTag);
                checkBox.Tag = DisplayTag;
                Console.WriteLine(DisplayTag);
                CheckBoxList.Add(checkBox);
                CheckBoxPanel.Controls.Add(checkBox);
                CheckBoxPanel.Controls.SetChildIndex(checkBox, position);
                position++;
            }
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] ffArray = fonts.Families;
            foreach (FontFamily ff in ffArray)
            {
                fontBox.Items.Add(ff.Name);
            }

            timer.Elapsed += (__sender, __e) =>
            {
                getEvent_Click(sender, new EventArgs());
            };
            string currentPath = Environment.CurrentDirectory;
            if (startFlag && System.IO.File.Exists(currentPath + "/imagesettings.json") && System.IO.File.Exists(currentPath + "/settings.json") && System.IO.File.Exists(currentPath + "/BackGroundImage.png"))
            {
                timer.Start();
            }
        }

        private void formOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        public class usrSettings
        {
            public string AuthJsonFilePath;
            public string UserMailAdress;
        }

        public class imageSettings
        {
            public string Font_;
            public Color Color_;
        }

        private void AuthJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.InitialDirectory = @"C:";
            ofDialog.Title = "Google から得た認証情報のJSONファイル";
            ofDialog.Multiselect = false;
            ofDialog.Filter = "JSONファイル(*.json)|*.json";
            ofDialog.RestoreDirectory = true;
            DialogResult dialogResult = ofDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                AuthJsonFile = ofDialog.FileName;
            }

            ofDialog.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usrSettings usrSettings = new usrSettings
            {
                AuthJsonFilePath = AuthJsonFile,
                UserMailAdress = mailAdress.Text
            };
            string json = JsonConvert.SerializeObject(usrSettings);
            string filePath = "settings.json";
            File.WriteAllText(filePath, json);

        }

        private void mailAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public IList<Event> GetEvents(string serviceAccountEmail, string credentialsPath)
        {
            // 認証情報を読み込む
            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(CalendarService.Scope.Calendar);
            }

            // CalendarService オブジェクトを作成
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Your Application Name"
            });

            // 予定を取得
            EventsResource.ListRequest request = service.Events.List(serviceAccountEmail);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10; // 取得する予定の最大数

            // 予定を取得して返す
            Events events = request.Execute();
            return events.Items;
        }
        private bool startFlag = false;
        private void getEvent_Click(object sender, EventArgs e)
        {
            IDesktopWallpaper pDesktopWallpaper = (IDesktopWallpaper)(new DesktopWallpaperClass());
            string ID=null;
            pDesktopWallpaper.GetMonitorDevicePathAt(1, ref ID);
            string json = File.ReadAllText("settings.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            string Path = data.AuthJsonFilePath;
            string eMail = data.UserMailAdress;
            var events = GetEvents(eMail, Path);
            foreach (CheckBox checkBox in CheckBoxList)
            {
                if (checkBox.Checked == true)
                {
                    createImage(events, (string)checkBox.Tag);
                }
            }
            if (!startFlag)
            {
                timer.Start();

                startFlag = true;
            }
            
        }

        private void createImage(IList<Event> @event,string monitorID)
        {
            RECT monitorRECT = new RECT();
            IDesktopWallpaper pDesktopWallpaper = (IDesktopWallpaper)(new DesktopWallpaperClass());
            string currentPath = Environment.CurrentDirectory;
            pDesktopWallpaper.GetMonitorRECT(monitorID,ref monitorRECT);
            int monitor_width = monitorRECT.right-monitorRECT.left;
            int monitor_height = monitorRECT.bottom-monitorRECT.top;
            int width = 3840;
            int height = 2160;
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
            FontFamily[] ffs = ifc.Families;

            using (Image backGroundImage = Image.FromFile(currentPath+"/BackGroundImage.png")) {
                graphics.DrawImage(backGroundImage,0,0,width,height);
                Font textFont = new Font(fonts, 150);
                Brush brush = new SolidBrush(fontColor);
                if (@event[0] != null)
                {
                    graphics.DrawString(@event[0].Summary.ToString(), textFont, brush, 150, 260);
                    textFont = new Font(fonts, 90);
                    graphics.DrawString(@event[0].Start.DateTime.ToString(), textFont, brush, 2500, 260);
                }

                if (@event[1] != null)
                {
                    graphics.DrawString(@event[1].Summary.ToString(), textFont, brush, 150, 860);
                    textFont = new Font(fonts, 90);
                    graphics.DrawString(@event[1].Start.DateTime.ToString(), textFont, brush, 2500, 860);
                }

                if (@event[2] != null)
                {
                    graphics.DrawString(@event[2].Summary.ToString(), textFont, brush, 150, 1300);
                    textFont = new Font(fonts, 90);
                    graphics.DrawString(@event[2].Start.DateTime.ToString(), textFont, brush, 2500, 1300);
                }
            }
            
            graphics.Dispose();
            image.Save(currentPath + "/tempImage.png", System.Drawing.Imaging.ImageFormat.Png);
            ResizeImageWhileMaintainingAspectRatio(@currentPath + "/tempImage.png", @currentPath+"/"+ monitor_width.ToString()+monitor_height.ToString() + "WALL.png", System.Drawing.Imaging.ImageFormat.Png, monitor_width, monitor_height);
            image.Dispose();
            
            HRESULT hr2 = pDesktopWallpaper.SetWallpaper(monitorID, @currentPath + "/" + monitor_width.ToString() + monitor_height.ToString() + "WALL.png");
        }

        private void SettingsSubmit_Click(object sender, EventArgs e)
        {
            fonts = fontBox.Text;
            fontColor = cd.Color;
            imageSettings imageSettings = new imageSettings
            {
                Font_= fonts,
                Color_= fontColor,
            };
            string json = JsonConvert.SerializeObject(imageSettings);
            string filePath = "imagesettings.json";
            File.WriteAllText(filePath, json);

        }

        ColorDialog cd = new ColorDialog();

        private void ColorDialog_Click(object sender, EventArgs e)
        {
            
            cd.Color = Color.Black;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ColorDialog.BackColor = cd.Color;
            }
        }

        private void ResizeImageWhileMaintainingAspectRatio(string sourceFile,
    string destinationFile,
    System.Drawing.Imaging.ImageFormat imageFormat,
    int width,
    int height)
        {
            // サイズ変更する画像ファイルを開く
            using (Image image = Image.FromFile(sourceFile))
            {
                // 変更倍率を取得する
                float scale = Math.Min((float)width / (float)image.Width, (float)height / (float)image.Height);

                // サイズ変更した画像を作成する
                using (Bitmap bitmap = new Bitmap(width, height))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // 変更サイズを取得する
                    int widthToScale = (int)(image.Width * scale);
                    int heightToScale = (int)(image.Height * scale);

                    // 背景色を塗る
                    SolidBrush solidBrush = new SolidBrush(Color.Black);
                    graphics.FillRectangle(solidBrush, new RectangleF(0, 0, width, height));

                    // サイズ変更した画像に、左上を起点に変更する画像を描画する
                    graphics.DrawImage(image, 0, 0, widthToScale, heightToScale);

                    // サイズ変更した画像を保存する
                    bitmap.Save(destinationFile, imageFormat);
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void finishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
