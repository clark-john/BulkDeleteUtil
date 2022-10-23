namespace BulkDeleteUtil.Components;

public class DeleteTypeChooser : ComboBox {
  public DeleteTypeChooser(){
    this.Width = 150;
    this.Location = new Point(530, 70);
    string[] types = {"By Extension", "Regex (soon)"};
    this.Items.AddRange(types);
    var a = new AutoCompleteStringCollection();
    a.AddRange(types);
    this.AutoCompleteCustomSource = a;
    this.SelectedText = types[0];
  }
}
