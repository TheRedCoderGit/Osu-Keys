using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osu_Keys.Json_Structs {
    class Config {
        public bool vertical { get; set; }
        public bool always_on_top { get; set; }
        public bool draw_border = true;
        public string[] keys { get; set; }
        public override string ToString() {
            return "Vertical: " + vertical + "\nAlways on top: " + always_on_top + "\nDraw Border: " + draw_border + "\nKeys: " + string.Join(",", keys);
        }
    }
}
