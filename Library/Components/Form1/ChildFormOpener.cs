public class ChildFormOpener
{
    private Form _currentChildForm;
    private Panel panelToFill;

    public ChildFormOpener(Panel panel)
    {
        panelToFill = panel;
    }

    public Form OpenChildForm(Form childForm)
    {
        if (_currentChildForm != null)
        {
            _currentChildForm.Close();
        }
        _currentChildForm = childForm;

        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        panelToFill.Controls.Add(childForm);
        panelToFill.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();

        return _currentChildForm;
    }
}