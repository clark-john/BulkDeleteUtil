/*namespace BulkDeleteUtil.Components;

using BulkDeleteUtil.FileSystem;

public class Events {
	private ExtensionInputBox exinp;
	private ExtensionsListBox exlbox;
	private DirectoryChooser dchooser;
	private Button Remove;
	private string SelectedDirectory;
	private int SelectedListIndex;
	private CheckBox cb;

	public Events(){
		exinp = new ExtensionInputBox();
		Remove = exinp.GetRemoveButton();
		cb = exinp.GetCheckBox();
		exlbox = new ExtensionsListBox();
		dchooser = new DirectoryChooser();
		SelectedDirectory = dchooser.GetSelectedDirectory();
		SelectedListIndex = exlbox.GetSelectedListIndex();
	}

	public void AddItemToExtsList(object? sender, EventArgs e){
		string value = exinp.GetInputBoxValue();
		string item = String.Concat(".", value);
		if (!exlbox.Items.Contains(item) && value != "") {
			exlbox.Items.Add(item);
		}
	}
	public void OpenFolderDialog(object? sender, EventArgs e) {
		// var dchooser = new DirectoryChooser();
			var ofd = dchooser.GetFolderDialog();
		ofd.ShowDialog();
		if (ofd.SelectedPath != "") {
			dchooser.SetSelectedDirectory(ofd.SelectedPath);
		}
	}
	public void SelectedItemFromList(object? sender, EventArgs e){
		if (exlbox.SelectedIndex != -1) {
			SelectedListIndex = exlbox.SelectedIndex;
		}
		Remove.Enabled = true;
	}
	public void DisableDeleteButton(object? sender, EventArgs e){
		Remove.Enabled = false;
	}
	public void ListBoxLostFocus(object? sender, EventArgs e){
		int SelectedIndex = exlbox.SelectedIndex;
		if (SelectedIndex != -1) {
			exlbox.SetSelected(SelectedIndex, false);
		}
	}
	public void DeleteItemFromExtsList(object? sender, EventArgs e){
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
	public void LookForCorrectInfo(object? sender, EventArgs e){
		if (SelectedDirectory == "") {
			MessageBox.Show(
				"Select a directory", 
				"Bulk Delete Utility", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);
		} else if (exlbox.Items.Count == 0) {
			MessageBox.Show(
				"Select extensions to delete", 
				"Bulk Delete Utility", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);			
		} else {
			// Delete files
			string DeleteMessage(string joinedFilesString) => String.Concat(
				"You're about to delete the following:\n\n",
				joinedFilesString,
				"\n\nDelete all of them?"
			);
			var files = FilesSelector.SelectFilesByExt(exlbox.Items, SelectedDirectory, cb.Checked);
			var allFiles = files;
			int totalFilesCount = files.Count;
			if (files.Count < 16) {
				DialogResult d = MessageBox.Show(
					DeleteMessage(
						String.Join("\n", files)
					), "Bulk Delete Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
				);
				if (d == DialogResult.Yes) {
					FilesDeleter.DeleteFiles(allFiles);
					MessageBox.Show("Files deleted successfully.", "Bulk Delete Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} else if (files.Count == 0) {
				MessageBox.Show(
					"There are no files to delete.", 
					"Bulk Delete Utility", 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Information
				);
			} else {
				files.RemoveRange(15, files.Count - 16);
				DialogResult d = MessageBox.Show(
					DeleteMessage(
						String.Concat(
							String.Join("\n", files), 
							$"\n... and {totalFilesCount - 15} others"
						)
					), "Bulk Delete Utility", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
				);
				if (d == DialogResult.Yes) {
					FilesDeleter.DeleteFiles(allFiles);
					MessageBox.Show("Files deleted successfully.", "Bulk Delete Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
*/