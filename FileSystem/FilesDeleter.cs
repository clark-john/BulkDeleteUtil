namespace BulkDeleteUtil.FileSystem;

public static class FilesDeleter {
	public static void DeleteFiles(List<string> files) {
		foreach (string x in files) {
			File.Delete(x);
		}
	}
}
