namespace BulkDeleteUtil.Components;

public class ExtensionInputBox : Panel {
	private int WidthFromExtsList = 0;
	private ExtensionsListBox exlbox;
	private int SelectedListIndex = 0;
	private List<char> specialChars = new List<char>() { '/', '\\', ':', '"', '<', '>', '|', '?' };
	private Button Add = new Button(){
		Text = "Add",
		Location = new Point(15, 55),
		Height = 30
	};
	private Button Remove = new Button(){
		Text = "Remove",
		Location = new Point(15, 95),
		Height = 30,
		Enabled = false
	};
	private CheckBox cb = new CheckBox(){
		Text = "Walk through directories",
		Location = new Point(15, 135),
		Width = 200
	};
	private TextBox tb = new TextBox(){ 
		Width = 150,
		Location = new Point(15, 15)
	};
	public ExtensionInputBox(ExtensionsListBox lbox) {
		exlbox = lbox;
		WidthFromExtsList = exlbox.Width;
		this.Location = new Point(WidthFromExtsList + 40, 110);
		this.Width = 260;
		this.Height = 180;
		Add.Click += AddItemToExtsList;
		Remove.Click += RemoveItemFromExtsList;		
		this.Controls.Add(tb);
		this.Controls.Add(Add);
		this.Controls.Add(Remove);
		this.Controls.Add(cb);
		this.BorderStyle = BorderStyle.FixedSingle;
		exlbox.SelectedIndexChanged += SelectedItemFromList;
	}
	public Button GetRemoveButton() => Remove;
	public CheckBox GetCheckBox() => cb;
	public string GetInputBoxValue() => tb.Text;
	private void AddItemToExtsList(object? sender, EventArgs e){
		if (tb.Text == "") {
			MessageBox.Show(
				"Extension cannot be empty.",
				MainForm.Title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);			
		} else if (!(specialChars.All(x => !tb.Text.Contains(x)))) {
			MessageBox.Show(
				"Extensions cannot contains special characters.",
				MainForm.Title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		} else {
			exlbox.AddItem(String.Concat(".", tb.Text), Remove);
		}
	}
	private void RemoveItemFromExtsList(object? sender, EventArgs e){
		int SelectedIndex = exlbox.SelectedIndex;
		if (SelectedIndex != -1) {
			exlbox.Items.RemoveAt(SelectedListIndex);
			Remove.Enabled = false;			
		} else {
			MessageBox.Show( 
				"Select an extension to delete",
				"Bulk Delete Utility",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}	
	}
	private void SelectedItemFromList(object? sender, EventArgs e){
		if (exlbox.SelectedIndex != -1) {
			SelectedListIndex = exlbox.SelectedIndex;
		}
		Remove.Enabled = true; // big hewp
	}
}
