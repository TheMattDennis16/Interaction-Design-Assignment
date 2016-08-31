using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Classes.InterfaceObjects
{
    class ItemBinding
    {
        private static PictureBox boundObj;
        private static object boundClass;
        private static bool hasBound;
        public static bool block = false;
        private static System.Drawing.Point boundImageLocation;
        private static Form1 frm = (Form1)Application.OpenForms["Form1"];

        public static void bindItemToCursor(PictureBox obj, object fullObj)
        {
            if(!block)
            {
                if(hasBound)
                {
                    unbindItem();
                }
                else
                {
                    obj.BringToFront();
                    boundObj = obj;
                    boundClass = fullObj;
                    boundImageLocation = obj.Location;
                    hasBound = true;
                }
            }
        }

        public static void blockAction()
        {
            block = true;
            unbindItem();
        }

        public static bool hasBoundItem()
        {
            return hasBound;
        }


        public static void unbindItem(bool force = false)
        {
            if(hasBound)
            {
                if(!force && (boundClass is FormObjects.ObjectSpecific.Egg ||
                    boundClass is FormObjects.ObjectSpecific.FlourAmount ||
                    boundClass is FormObjects.ObjectSpecific.SugarAmount))
                {
                    ErrorLogic.Error.showErrorDialog(Properties.Resources.CANT_UNBIND, 5);
                }
                else
                {
                    var marker = frm.formObj["marker"] as FormObjects.ObjectSpecific.InteractionMarker;
                    marker.hide();
                    boundObj.Location = boundImageLocation;
                    boundObj = null;
                    hasBound = false;
                    boundImageLocation = new System.Drawing.Point(0, 0);
                }
            }
        }

        public static PictureBox getBoundItem()
        {
            if(hasBound)
            {
                return boundObj;
            }
            return null;
        }

        public static object getBoundClass()
        {
            if(hasBound)
            {
                return boundClass;
            }
            return null;
        }
    }
}
