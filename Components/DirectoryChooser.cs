namespace BulkDeleteUtil.Components;

public class DirectoryChooser : Panel {
	private FolderBrowserDialog ofd = new FolderBrowserDialog();
	private string SelectedDirectory = "";
	private Label labelDir = new Label(){
		Text = "Click to select directory",
		BorderStyle = BorderStyle.FixedSingle,
		Width = 500
	};
	public DirectoryChooser(){
		labelDir.Click += OpenFolderDialog;
		this.Location = new Point(20, 72);
		this.Width = labelDir.Width;
		this.Height = labelDir.Height;
		this.Controls.Add(labelDir);
	}
	public string GetSelectedDirectory() => SelectedDirectory;
	public FolderBrowserDialog GetFolderDialog() => ofd;
	public void SetSelectedDirectory(string selected){
		SelectedDirectory = selected;
		labelDir.Text = selected;
	}
	private void OpenFolderDialog(object? sender, EventArgs e){
		ofd.ShowDialog();
		if (ofd.SelectedPath != "") {
			SetSelectedDirectory(ofd.SelectedPath);
		}
	}
}
