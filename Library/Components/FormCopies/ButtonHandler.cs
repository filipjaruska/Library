using System;
using System.Windows.Forms;
using Library.Forms;

public class ButtonHandler
{
    private Button btnSave;
    private DataGridView dataGridView1;
    private bool _changesMade;

    public ButtonHandler(Button saveButton, DataGridView dataGridView, bool changesMade)
    {
        btnSave = saveButton;
        dataGridView1 = dataGridView;
        _changesMade = changesMade;
    }

    public void HandleSaveClick(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult != DialogResult.Yes) return;
        if (_changesMade)
        {
            DataSaver dataSaver = new DataSaver(dataGridView1);
            dataSaver.SaveChanges();
            _changesMade = false;
            btnSave.Enabled = false;
        }
    }
}