public class ButtonHandler
{
    private Button btnSave;
    private DataGridView dataGridView1;
    private bool _changesMade;

    // The constructor takes a Button, a DataGridView, and a boolean flag as parameters and stores them in the btnSave, dataGridView1, and _changesMade fields.
    public ButtonHandler(Button saveButton, DataGridView dataGridView, bool changesMade)
    {
        btnSave = saveButton;
        dataGridView1 = dataGridView;
        _changesMade = changesMade;
    }

    // The HandleSaveClick method is intended to be used as an event handler for the Click event of the Button.
    // It asks the user for confirmation, and if the user confirms and any changes have been made, it saves the changes and disables the Button.
    public void HandleSaveClick(object sender, EventArgs e)
    {
        // Ask the user for confirmation
        DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        // If the user does not confirm, return
        if (dialogResult != DialogResult.Yes) return;
        // If any changes have been made
        if (_changesMade)
        {
            // Save the changes
            DataSaver dataSaver = new DataSaver(dataGridView1);
            dataSaver.SaveChanges();
            // Reset the changes made flag and disable the Button
            _changesMade = false;
            btnSave.Enabled = false;
        }
    }
}