using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Osu_Keys.Properties;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Osu_Keys.Json_Structs;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Osu_Keys {

    class Key : Label {

        public static bool drawBorder = true;
        public static bool isVertical = true;
        public static List<Key> Keys = new List<Key>();
        public static List<String> _keys = new List<String>();
        public static int position = 0;
        private static Form f;
        private Point Original;
        private Bitmap OriginalImage;
        private Bitmap[] Shrinked;
        private Bitmap[] ShrinkedPressed;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        public Key(Form f, ContextMenuStrip cms)
            : base() {
            //this.BackColor = System.Drawing.Color.White;
            object O = Resources.ResourceManager.GetObject("inputoverlay-key");
            Image = (Bitmap)O;
            OriginalImage = (Bitmap)O;
            Shrinked = new Bitmap[5];
            for (int i = 0; i < 5; i++) {
                Bitmap newImage = new Bitmap(50 - i * 2, 50 - i * 2);
                using (Graphics gr = Graphics.FromImage(newImage)) {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(OriginalImage, new Rectangle(0, 0, 50 - i * 2, 50 - i * 2));
                }
                Bitmap bmp = newImage;
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();
                for (int y = 0; y < lockBitmap.Height; y++) {
                    for (int x = 0; x < lockBitmap.Width; x++) {
                        Color c = lockBitmap.GetPixel(x, y);
                        if (c.A < 255)
                            lockBitmap.SetPixel(x, y, Color.Transparent);
                    }
                }
                lockBitmap.UnlockBits();
                Shrinked[i] = bmp;
            }
            Image = Shrinked[0];
            ShrinkedPressed = new Bitmap[5];
            for (int i = 0; i < 5; i++) {
                Bitmap newImage = new Bitmap(50 - i * 2, 50 - i * 2);
                using (Graphics gr = Graphics.FromImage(newImage)) {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(OriginalImage, new Rectangle(0, 0, 50 - i * 2, 50 - i * 2));
                }
                Bitmap bmp = newImage;
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap.LockBits();
                Color mask = Color.Yellow;
                for (int y = 0; y < lockBitmap.Height; y++) {
                    for (int x = 0; x < lockBitmap.Width; x++) {
                        Color c = lockBitmap.GetPixel(x, y);
                        if (c.A < 255)
                            lockBitmap.SetPixel(x, y, Color.Transparent);
                        else if (c.A > 0 && !(c.R < 10 && c.G < 10 && c.B < 10)) {
                            lockBitmap.SetPixel(x, y, Key.Blend(mask, lockBitmap.GetPixel(x, y), 10));
                        }
                    }
                }
                lockBitmap.UnlockBits();
                ShrinkedPressed[i] = bmp;
            }
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = cms;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Original = isVertical ? new Point(0, position * 52) : new Point(position * 52, 0);
            this.Location = Original;
            this.Name = "Key" + position;
            this.Size = new System.Drawing.Size(50, 50);
            this.MinimumSize = this.Size;
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.AutoSize = true;
            this.TabIndex = 2;
            try {
                this.Text = _keys[position];
            } catch {
                _keys.Add("null");
                this.Text = _keys[position] + "";
            }
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this._MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this._PreviewKeyDown);
            try {
                Keys.Insert(position, this);
            } catch {
                Keys.Add(this);
            }
            f.Controls.Add(this);
            Key.f = f;
            position++;
        }

        public static void UpdateKeys() {
            position = 0;
            foreach (Key k in Keys) {
                k.Original = isVertical ? new Point(0, position * 52) : new Point(position * 52, 0);
                k.Location = k.Original;
                k.Name = "Key" + position;
                k.Update();
                k.Refresh();
                _keys[position] = k.Text;
                position++;
            }
            Key.save();
        }

        private int Tint = 255;
        private int Shrink = 0;
        private int LastShrink = 0;
        private bool pressed = false;
        private bool lastPressed = false;
        public void _Update() {
            if (pressed)
                Shrink = Math.Min(4, Shrink + 1);

            foreach (Control c in f.Controls)
                if (c.Name.Equals("label1"))
                    ((Label)c).Text = Tint + "";
            //BackColor = Color.FromArgb(255, 255, 255, Tint);
            Tint = 255;
            if (LastShrink != Shrink) {
                this.MinimumSize = new Size(50 - 2 * Shrink, 50 - 2 * Shrink);
                this.Image = pressed ? ShrinkedPressed[Shrink] : Shrinked[Shrink];
                //Region.Dispose();
                //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
                this.Location = new Point(Original.X + Shrink, Original.Y + Shrink);
            }
            LastShrink = Shrink;
            if (lastPressed && !pressed && Shrink < 5)
                Shrink = 5;
            if (!lastPressed && pressed && Shrink > -1)
                Shrink = 0;
            if (!pressed)
                Shrink = Math.Max(0, Shrink - 1);
            lastPressed = pressed;
            pressed = false;
        }

        public void OnKeyPress() {
            Tint = 0;
            pressed = true;
        }

        public void _MouseClick(object sender, MouseEventArgs e) {
            Focus();
            ForeColor = Color.Red;
            foreach (Key k in Keys)
                if (k != this)
                    k.ForeColor = Color.Black;
        }

        private Point lastP;
        public void _MouseDown(object sender, MouseEventArgs e) {
            lastP = e.Location;
            LoseFocus();
            foreach (Key k in Keys)
                k.ForeColor = Color.Black;
        }

        public void _MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                f.Left += e.X - lastP.X;
                f.Top += e.Y - lastP.Y;
            }
        }

        public void _PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (ForeColor == Color.Red) {
                try {
                    string txt = (KeyEventUtility.GetCharFromKey(KeyInterop.KeyFromVirtualKey(e.KeyValue)) + "").ToUpper();
                    if (String.IsNullOrEmpty(txt) || String.IsNullOrWhiteSpace(txt))
                        txt = "null";
                    _keys[MyPosition()] = txt;
                    this.Text = _keys[MyPosition()];
                } catch { }
                save();
                ForeColor = Color.Black;
                LoseFocus();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            return;
            if (!drawBorder)
                return;
            int xy = 0;
            int width = this.ClientSize.Width - 1;
            int height = this.ClientSize.Height - 1;
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i < 2; i++)
                e.Graphics.DrawRectangle(pen, xy + i, xy + i, width - (i << 1) - 1, height - (i << 1) - 1);
            e.Graphics.DrawRectangle(pen, 1, 1, 3, 1);
            e.Graphics.DrawRectangle(pen, 1, 1, 1, 3);
            e.Graphics.DrawRectangle(pen, width - 1 - 4, 1, 3, 1);
            e.Graphics.DrawRectangle(pen, width - 1 - 2, 1, 1, 3);
            e.Graphics.DrawRectangle(pen, width - 1 - 4, height - 3, 3, 1);
            e.Graphics.DrawRectangle(pen, width - 1 - 2, height - 5, 1, 3);
            e.Graphics.DrawRectangle(pen, 1, height - 3, 3, 1);
            e.Graphics.DrawRectangle(pen, 1, height - 5, 1, 3);
        }

        private static Color Blend(Color color, Color backColor, double amount) {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        private int MyPosition() {
            int my_position = -1;
            for (int i = 0; i < Keys.ToArray().Length; i++)
                if (Keys[i] == this) {
                    my_position = i;
                    break;
                }
            return my_position;
        }

        private void LoseFocus() {
            ((Label)Form.ActiveForm.Controls["NoFocus"]).Focus();
        }

        private String ControlName(object control) {
            try {
                return ((Control)control).Name;
            } catch {
                return "Error";
            }
        }

        public static void save() {
            Config defaultCfg = new Config {
                vertical = isVertical,
                always_on_top = f.TopMost,
                draw_border = drawBorder,
                keys = _keys.ToArray()
            };
            string outString = JsonConvert.SerializeObject(defaultCfg, Formatting.Indented);
            File.WriteAllText("Osu!Keys.json", outString);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // Key
            // 
            this.Image = global::Osu_Keys.Properties.Resources.inputoverlay_key;
            this.ResumeLayout(false);

        }
    }
}
