namespace BulkDeleteUtil.Components;

partial class PartialPanel {
	public Button initializeDelButton(){
		Button b = new Button(){
			Text = "Delete",
			Height = 30,
			Location = new Point(615, 555),
			Enabled = true
		};
		b.Click += LookForCorrectInfo;
		return b;
	}
}
