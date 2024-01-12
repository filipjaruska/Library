public class ChildFormOpener
{
    private Form _currentChildForm;
    private Panel panelToFill;

    // The constructor takes a Panel as a parameter and stores it in the panelToFill field.
    public ChildFormOpener(Panel panel)
    {
        panelToFill = panel;
    }

    // The OpenChildForm method opens a specified child form in the panelToFill.
    // If there is already a child form open, it closes that form before opening the new one.
    // It also sets the child form's TopLevel property to false, its FormBorderStyle to None, and its Dock to Fill.
    // Finally, it brings the child form to the front and shows it.
    public Form OpenChildForm(Form childForm, Form _currentChildForm)
    {
        // If there is already a child form open, close it
        if (_currentChildForm != null)
        {
            _currentChildForm.Close();
        }
        // Store the new child form in the _currentChildForm field
        _currentChildForm = childForm;

        // Set the child form's properties
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        // Add the child form to the panelToFill's controls
        panelToFill.Controls.Add(childForm);
        // Store the child form in the panelToFill's Tag property
        panelToFill.Tag = childForm;
        // Bring the child form to the front
        childForm.BringToFront();
        // Show the child form
        childForm.Show();

        return _currentChildForm;
    }
}