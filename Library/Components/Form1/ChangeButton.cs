namespace Library.Components.Form1
{
    internal static class ChangeButton
    {
        private static Button _btnCurrent;
        private static Form _currentChildForm;

        // The HandleActivateButton method activates a specified button and deactivates the currently active button.
        // It returns the now active button.
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

        // The HandleResetButton method resets the currently active button and closes the currently open child form.
        public static void HandleResetButton(Form _currentChildForm)
        {
            HandleDisableButton(_btnCurrent);

            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
        }

        // The HandleDisableButton method deactivates a specified button.
        public static void HandleDisableButton(Button btnCurrent)
        {
            if (btnCurrent == null) return;
            btnCurrent.BackColor = Color.MediumPurple;
            btnCurrent.ForeColor = Color.Black;
            btnCurrent.TextAlign = ContentAlignment.MiddleLeft;
            btnCurrent.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCurrent.ImageAlign = ContentAlignment.MiddleLeft;
        }
    }
}