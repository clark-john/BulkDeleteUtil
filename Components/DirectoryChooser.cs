namespace BulkDeleteUtil.Components;

partial class PartialPanel {
	FolderBrowserDialog ofd = new FolderBrowserDialog();
	string SelectedDirectory = "";
	Label labelDir = new Label(){
		Text = "Click to select directory",
		BorderStyle = BorderStyle.FixedSingle,
		Width = 500
	};
	public Panel initializeDirectoryChooser(){
		labelDir.Click += OpenFolderDialog;
		Panel p = new Panel(){
			Location = new Point(20, 72),
			Width = labelDir.Width,
			Height = labelDir.Height
		};
		p.Controls.Add(labelDir);
		return p;
	}
}
