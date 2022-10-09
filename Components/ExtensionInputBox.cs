namespace BulkDeleteUtil.Components;

partial class PartialPanel {
	private int WidthFromExtsList = 0;
	Button Add = new Button(){
		Text = "Add",
		Location = new Point(15, 55),
		Height = 30
	};
	Button Remove = new Button(){
		Text = "Remove",
		Location = new Point(15, 95),
		Height = 30,
		Enabled = false
	};
	CheckBox cb = new CheckBox(){
		Text = "Walk through directories",
		Location = new Point(15, 135),
		Width = 200
	};
	TextBox tb = new TextBox(){ 
		Width = 150,
		Location = new Point(15, 15)
	};
	public Panel initializeExtInputBox() {
		WidthFromExtsList = ExtensionsListBox.Width;
		Panel p = new Panel(){
			Location = new Point(WidthFromExtsList + 40, 110),
			Width = 260,
			Height = 180
		};
		Add.Click += AddItemToExtsList;
		Remove.Click += DeleteItemFromExtsList;		
		p.Controls.Add(tb);
		p.Controls.Add(Add);
		p.Controls.Add(Remove);
		p.Controls.Add(cb);
		p.BorderStyle = BorderStyle.FixedSingle;
		return p;
	}
}
