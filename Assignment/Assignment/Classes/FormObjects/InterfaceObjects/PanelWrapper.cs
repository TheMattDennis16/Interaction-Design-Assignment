using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment.Classes.InterfaceObjects
{
    public class PanelWrapper
    {
        public PanelWrapper()
        {
            newPnl = new Panel();
            objects = new Dictionary<string, dynamic>();
        }

        public Panel newPnl;
        public Dictionary<string, dynamic> objects;
    }
}
