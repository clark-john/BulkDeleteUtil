namespace BulkDeleteUtil.Components;

partial class PartialPanel {
	private int SelectedListIndex = -1;
	public ListBox initializeExtsListBox() {
		ListBox l = new ListBox(){
			Location = new Point(20, 110),
			Height = 450,
			Width = 150
		};
		l.SelectedIndexChanged += SelectedItemFromList;
		// l.Leave += ListBoxLostFocus;
		return l;
	}	
}
