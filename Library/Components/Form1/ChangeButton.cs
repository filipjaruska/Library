using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components.Form1
{
    internal static class ChangeButton
    {
        private static Button _btnCurrent;
        private static Form _currentChildForm;
        public static Button HandleActivateButton(object btnSender, Color color)
        {
            if (btnSender == null) return null;
            HandleDisableButton(_btnCurrent);
            _btnCurrent = btnSender as Button;
            _btnCurrent.BackColor = Color.BlueViolet;
            _btnCurrent.ForeColor = color;
            _btnCurrent.TextAlign = ContentAlignment.MiddleCenter;
            _btnCurrent.TextImageRelation = TextImageRelation.TextBeforeImage;
            _btnCurrent.ImageAlign = ContentAlignment.MiddleRight;

            return _btnCurrent;
        }
        public static void HandleResetButton(Form _currentChildForm)
        {
            HandleDisableButton(_btnCurrent);

            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
        }
        public static void HandleDisableButton(Button btnCurrent)
        {
            if (btnCurrent == null) return;
            btnCurrent.BackColor = Color.SlateBlue;
            btnCurrent.ForeColor = Color.Black;
            btnCurrent.TextAlign = ContentAlignment.MiddleLeft;
            btnCurrent.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCurrent.ImageAlign = ContentAlignment.MiddleLeft;
        }
    }
}
