using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbacusSUPP
{
    public static class OperaterLogin
    {
        public static Login operater { get; set; }
        public static List<int> seen_tasks { get; set; }
        public static Settings podesavanja { get; set; } // ovo se ne koristi vise
        public static List<Komentar> stara_kom_lista { get; set; }
        public static List<Task> main_lista { get; set; }
        public static bool NotifOverride { get; set; }
        
    }
    

}
