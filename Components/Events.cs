namespace BulkDeleteUtil.Components;

using BulkDeleteUtil.FileSystem;

partial class PartialPanel {
	private void AddItemToExtsList(object? sender, EventArgs e){
		string item = String.Concat(".", tb.Text);
		if (!ExtensionsListBox.Items.Contains(item) && tb.Text != "") {
			ExtensionsListBox.Items.Add(item);
		}
	}
	private void OpenFolderDialog(object? sender, EventArgs e) {
		ofd.ShowDialog();
		if (ofd.SelectedPath != "") {
			labelDir.Text = ofd.SelectedPath;
			SelectedDirectory = ofd.SelectedPath;
		}
	}
	private void SelectedItemFromList(object? sender, EventArgs e){
		if (ExtensionsListBox.SelectedIndex != -1) {
			SelectedListIndex = ExtensionsListBox.SelectedIndex;
		}
		Remove.Enabled = true;
	}
	private void DisableDeleteButton(object? sender, EventArgs e){
		Remove.Enabled = false;
	}
	private void ListBoxLostFocus(object? sender, EventArgs e){
		int SelectedIndex = ExtensionsListBox.SelectedIndex;
		if (SelectedIndex != -1) {
			ExtensionsListBox.SetSelected(SelectedIndex, false);
		}
	}
	private void DeleteItemFromExtsList(object? sender, EventArgs e){
		int SelectedIndex = ExtensionsListBox.SelectedIndex;
		if (SelectedIndex != -1) {
			ExtensionsListBox.Items.RemoveAt(SelectedListIndex);
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
	private void LookForCorrectInfo(object? sender, EventArgs e){
		if (SelectedDirectory == "") {
			MessageBox.Show(
				"Select a directory", 
				"Bulk Delete Utility", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);
		} else if (ExtensionsListBox.Items.Count == 0) {
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
			var files = FilesSelector.SelectFilesByExt(ExtensionsListBox.Items, SelectedDirectory, cb.Checked);
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
