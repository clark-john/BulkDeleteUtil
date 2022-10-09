namespace BulkDeleteUtil.FileSystem;

public static class FilesSelector {
	public static List<string> SelectFilesByExt(ListBox.ObjectCollection extensions, string path, bool isRecursive = false){
		List<object> obj = new();
		List<string> files = new();
		foreach (object x in extensions) {
			obj.Add(x);
		}
		foreach (object y in obj) {
			foreach (string x in Directory.EnumerateFiles(
				path, 
				String.Concat("*", y.ToString()), 
				isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
			)) {
				files.Add(x);
			}
		}
		return files;
	}
}
