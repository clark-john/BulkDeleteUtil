namespace BulkDeleteUtil;

using BulkDeleteUtil.Components;

public class MainForm : Form {
	public static readonly int FormWidth = 700;
	public static readonly string Title = "Bulk Delete Utility";
	public MainForm(){
		Label l = new Label(){
			Text = Title,
			Height = 60,
			Width = FormWidth,
			Font = new Font("Segoe UI", 20),
			TextAlign = ContentAlignment.MiddleLeft,
			Location = new Point(15, 0)
		};

		this.Controls.Add(l);
		this.ClientSize = new Size(FormWidth, 600);
		this.Text = Title;

		this.Controls.Add(new MainPanel());
	}
}
