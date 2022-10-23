namespace BulkDeleteUtil.Components;

public class ExtensionsListBox : ListBox {
	private int SelectedListIndex = -1;
	public ExtensionsListBox() {
		this.Location = new Point(20, 110);
		this.Height = 450;
		this.Width = 150;
		// this.SelectedIndexChanged += e.SelectedItemFromList;
		// l.Leave += ListBoxLostFocus;
	}
	public int GetSelectedListIndex() => SelectedListIndex;
	public void AddItem(string item, Button b){
		this.Items.Add(item);
	}
	public void RemoveItem(){
		
	}
}
