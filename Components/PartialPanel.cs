namespace BulkDeleteUtil.Components;

public partial class PartialPanel : Panel {
	Panel DirectoryChooser;
	ListBox ExtensionsListBox;
	Panel ExtensionInputBox;
	Button DeleteButton;
	ComboBox DeleteTypeChooser;
	public PartialPanel(){
		this.ClientSize = new Size(MainForm.FormWidth, 600);

		DirectoryChooser = initializeDirectoryChooser();
		ExtensionsListBox = initializeExtsListBox();
		ExtensionInputBox = initializeExtInputBox();
		DeleteTypeChooser = initializeDeleteTypeChooser();
		DeleteButton = initializeDelButton();
		this.Controls.Add(DirectoryChooser);
		this.Controls.Add(ExtensionsListBox);
		this.Controls.Add(DeleteTypeChooser);
		// exts panel
		this.Controls.Add(ExtensionInputBox);
		this.Controls.Add(DeleteButton);
	}
}
