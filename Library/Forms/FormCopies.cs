using Library.Components;
using Library.Data;

namespace Library.Forms
{
    public partial class FromCopies : Form
    {
        // A bool to track if any changes have been made.
        private bool _changesMade = false;

        // The constructor initializes the form and sets up the ComboBox and DataGridView.
        public FromCopies()
        {
            InitializeComponent();

            // Set up the ComboBox with the library branches from the database.
            using (var context = new AppDbContext())
            {
                comboBoxBranches.DisplayMember = "BranchName";
                comboBoxBranches.ValueMember = "BranchId";
                comboBoxBranches.DataSource = context.LibraryBranches.ToList();
            }

            // Apply the default style to the DataGridView.
            DataGridStyle.DefaultStyle(dataGridView1);
            dataGridView1.Columns["CopyId"]!.ReadOnly = true;
            dataGridView1.Columns["BookId"]!.ReadOnly = true;
        }

        // Handle the SelectedIndexChanged event of the ComboBox by updating the DataGridView.
        private void comboBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a ComboBoxHandler and subscribe it to the SelectedIndexChanged event.
            ComboBoxHandler comboBoxHandler = new ComboBoxHandler(comboBoxBranches, dataGridView1);
            comboBoxBranches.SelectedIndexChanged += comboBoxHandler.HandleSelectedIndexChanged;

            // Call the event handler manually for the initial display.
            comboBoxHandler.HandleSelectedIndexChanged(comboBoxBranches, EventArgs.Empty);
        }

        // Handle the CellContentClick event of the DataGridView by enabling the save button.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _changesMade = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create a ButtonHandler and subscribe it to the Click event.
            ButtonHandler buttonHandler = new ButtonHandler(btnSave, dataGridView1, _changesMade);
            btnSave.Click += buttonHandler.HandleSaveClick;

            // Call the event handler manually to save the changes.
            buttonHandler.HandleSaveClick(sender, e);
        }
    }
}