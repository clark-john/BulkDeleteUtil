namespace BulkDeleteUtil.Components;
partial class PartialPanel {
  public ComboBox initializeDeleteTypeChooser(){
    ComboBox combo = new ComboBox(){
      Width = 150,
      Location = new Point(530, 70)
    };
    string[] types = {"By Extension", "Regex (soon)"};
    combo.Items.AddRange(types);
    var a = new AutoCompleteStringCollection();
    a.AddRange(types);
    combo.AutoCompleteCustomSource = a;
    combo.SelectedText = types[0];
    return combo;
  }
}
