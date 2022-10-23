namespace BulkDeleteUtil.Components;

using BulkDeleteUtil.FileSystem;

public class DeleteButton : Button {
	private DirectoryChooser dc;
	private ExtensionsListBox exlbox;
	private ExtensionInputBox exibox;
	public DeleteButton(DirectoryChooser Dc, ExtensionsListBox lbox, ExtensionInputBox ibox){
		dc = Dc;
		exlbox = lbox;
		exibox = ibox;
		this.Text = "Delete";
		this.Height = 30;
		this.Location = new Point(615, 555);
		this.Enabled = true;
		this.Click += DeleteFiles;
	}
	private void CopyListTo<T>(List<T> l1, ref List<T> l2){
		foreach (T x in l1) {
			l2.Add(x);
		}
	}
	private void DeleteFiles(object? sender, EventArgs e){
		string SelectedDirectory = dc.GetSelectedDirectory();
		if (SelectedDirectory == ""){
			MessageBox.Show(
				"Select a directory", 
				MainForm.Title, 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);
		} else if (exlbox.Items.Count == 0) {
			MessageBox.Show(
				"Select extensions to delete", 
				MainForm.Title, 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);			
		} else {
			var cb = exibox.GetCheckBox();
			string DeleteMessage(string joinedFilesString) => String.Concat(
				"You're about to delete the following:\n\n",
				joinedFilesString,
				"\n\nDelete all of them?"
			);
			var files = FilesSelector.SelectFilesByExt(exlbox.Items, SelectedDirectory, cb.Checked);
			var allFiles = new List<string>();
			CopyListTo<string>(files, ref allFiles);

			int totalFilesCount = files.Count;
			if (files.Count == 0) {
				MessageBox.Show(
					"There are no files to delete.", 
					MainForm.Title, 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Information
				);
			} else if (files.Count < 16) {
				DialogResult d = MessageBox.Show(
					DeleteMessage(
						String.Join("\n", files)
					), MainForm.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning
				);
				if (d == DialogResult.Yes) {
					FilesDeleter.DeleteFiles(allFiles);
					MessageBox.Show("Files deleted successfully.", "Bulk Delete Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} else {
				files.RemoveRange(15, files.Count - 15);
				DialogResult d = MessageBox.Show(
					DeleteMessage(
						String.Concat(
							String.Join("\n", files), 
							$"\n... and {totalFilesCount - 15} others"
						)
					), MainForm.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning
				);
				if (d == DialogResult.Yes) {
					FilesDeleter.DeleteFiles(allFiles);
					MessageBox.Show("Files deleted successfully.", "Bulk Delete Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
