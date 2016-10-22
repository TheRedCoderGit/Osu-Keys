using Newtonsoft.Json;
using Osu_Keys.Json_Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Osu_Keys {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (!File.Exists("Osu!Keys.json")) {
                Config defaultCfg = new Config {
                    vertical = true,
                    always_on_top = false,
                    draw_border = true,
                    keys = new string[] { "Z", "X" }
                };
                string outString = JsonConvert.SerializeObject(defaultCfg, Formatting.Indented);
                File.WriteAllText("Osu!Keys.json", outString);
            }
            string jsonString = File.ReadAllText("Osu!Keys.json");
            Config cfg = JsonConvert.DeserializeObject<Config>(jsonString);
            MessageBox.Show(cfg.ToString(), "Osu!Keys - Config");

            // MessageBox.Show(String.Format("Loaded {0} Keys\r\n{1}", cfg.keys.Length, String.Join("\r\n", cfg.keys)), "Osu!Keys - Config");
            Key._keys = new List<string>(cfg.keys);
            TopMost = cfg.always_on_top;
            Key.isVertical = cfg.vertical;
            Key.drawBorder = cfg.draw_border;
            foreach (String k in Key._keys) {
                new Key(this, contextMenuStrip1);
            }
        }

        private String ControlName(object control) {
            try {
                return ((Control)control).Name;
            } catch {
                return "Error";
            }
        }

        private void addButtonToolStripMenuItem_Click(object sender, EventArgs e) {
            new Key(this, contextMenuStrip1);
        }

        private Control clicked;

        private void removeButtonToolStripMenuItem_Click(object sender, EventArgs e) {
            if (clicked == null)
                return;
            try {
                Key k = (Key)clicked;
                Key._keys.Remove(k.Text);
                Key.Keys.Remove(k);
                Key.UpdateKeys();
                Controls.Remove(k);
            } catch {
                MessageBox.Show("Error!", "Osu!Keys");
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e) {
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            clicked = cms.SourceControl;
            foreach (ToolStripMenuItem item in cms.Items) {
                item.Enabled = true;
                item.ToolTipText = null;
            }
            foreach (ToolStripMenuItem item in cms.Items)
                if (item.Name.Equals("removeButtonToolStripMenuItem") && Key.position <= 1) {
                    item.Enabled = false;
                    item.ToolTipText = "Can't remove any more keys!";
                }
        }

        public static bool[] keys = new bool[256];
        private void tickTimer_Tick(object sender, EventArgs e) {
            foreach (Key k in Key.Keys)
                k._Update();
            foreach (Key k in Key.Keys)
                if (keys[(int)k.Text[0]])
                    k.OnKeyPress();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            char c = (KeyEventUtility.GetCharFromKey(KeyInterop.KeyFromVirtualKey(e.KeyValue)) + "").ToUpper()[0];
            keys[(int)c] = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            char c = (KeyEventUtility.GetCharFromKey(KeyInterop.KeyFromVirtualKey(e.KeyValue)) + "").ToUpper()[0];
            keys[(int)c] = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) {
            Key.isVertical = true;
            Key.UpdateKeys();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            Key.isVertical = false;
            Key.UpdateKeys();
        }

        private void drawBorderToolStripMenuItem_Click(object sender, EventArgs e) {
            Key.drawBorder = true;
            Key.UpdateKeys();
        }

        private void dontDrawBorderToolStripMenuItem_Click(object sender, EventArgs e) {
            Key.drawBorder = false;
            Key.UpdateKeys();
        }
    }
}
