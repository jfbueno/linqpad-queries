<Query Kind="Program" />

void Main()
{
	IFileReader reader = new FileReader();
	reader.ReadFile("abc.txt");

	IFileReader encryptionReader = new EncryptionDecorator(new FileReader());
	encryptionReader.ReadFile("def.txt");

	IFileReader compressionReader = new CompressionDecorator(new EncryptionDecorator(new FileReader()));
	compressionReader.ReadFile("ghij.txt");
}

sealed class CompressionDecorator : IFileReader
{
	private IFileReader _fileReader;

	public CompressionDecorator(IFileReader fileReader)
		=> _fileReader = fileReader;

	public string ReadFile(string path)
	{
		Console.WriteLine("Decompressing file...");
		return _fileReader.ReadFile(path);
	}
}

sealed class EncryptionDecorator : IFileReader
{
	private readonly IFileReader _fileReader;

	public EncryptionDecorator(IFileReader fileReader)
		=> _fileReader = fileReader;

	public string ReadFile(string path)
	{
		Console.WriteLine("Decrypting file...");
		return _fileReader.ReadFile(path);
	}
}

sealed class FileReader : IFileReader
{
	public string ReadFile(string path)
	{
		Console.WriteLine("Reading file: " + path);
		// File.ReadAllText, etc.
		return "File contents";
	}
}

interface IFileReader
{
	string ReadFile(string path);
}