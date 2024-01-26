<Query Kind="Program" />

void Main()
{
	new TextRenderer("Calibri", "Olá");
	new TextRenderer("Calibri", "Hello");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
	new TextRenderer("Verdana", "Hallo");
}

/// <summary>
/// Componente original 
/// </summary>
sealed class TextRenderer
{
	public Font Font { get; }
	public string RawText { get; }
	
	public TextRenderer(string fontFamily, string rawText)
	{
		//Font = new Font(fontFamily);
		RawText = rawText;
		Font = FontFactory.Instance.Get(fontFamily);
	}
	
	public void Render() { }
}

/// <summary>
/// Essa classe é o FlyWeight concreto, uma parte do estado de `TextRenderer`
/// que foi extraída pra ser usada dentro do contexto de compartilhamento de instâncias
/// </summary>
sealed record Font(string Family);

/// <summary>
/// Factory do FlyWeight que permite que instâncias de `Font` sejam compartilhadas
/// </summary>
sealed class FontFactory
{
	private static FontFactory _instance;
	public static readonly FontFactory Instance = (_instance ??= new());
	
	private readonly Dictionary<string, Font> _fonts = new();

	public Font Get(string fontFamily)
	{
		var font = _fonts.GetValueOrDefault(fontFamily);
		
		if (font is null)
		{
			Console.WriteLine($"Creating new font {fontFamily}");
			font = new Font(fontFamily);
			_fonts.Add(fontFamily, font);
		}
		
		return font;
	}
}