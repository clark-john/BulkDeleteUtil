namespace BulkDeleteUtil.Components;

public class MainPanel : Panel {
	public MainPanel(){
		this.ClientSize = new Size(MainForm.FormWidth, 600);

		var dchooser = new DirectoryChooser();
		this.Controls.Add(dchooser);
		this.Controls.Add(new DeleteTypeChooser());
		var exlbox = new ExtensionsListBox();
		var exibox = new ExtensionInputBox(exlbox);
		this.Controls.Add(exibox);
		this.Controls.Add(exlbox);
		this.Controls.Add(new DeleteButton(dchooser, exlbox, exibox));
	}
}
