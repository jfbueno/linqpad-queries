<Query Kind="Program" />

void Main()
{
	var jef = new IndividualContributor("Jéf");
	var agostini = new IndividualContributor("Agostini");

	var katia = new Manager("Katia", new[] { jef, agostini });

	var cassio = new IndividualContributor("Cássio");
	var daniel = new Manager("Daniel", new[] { cassio });
	
	var hoffman = new Head("Hoffman", new [] { katia, daniel });
	
	hoffman.PrintInfo();
}

interface IEmployee
{
	string Name { get; }
	void PrintInfo();
}

interface IPeoplesManager 
{
	IEmployee[] Subordinates { get; }
}

record IndividualContributor(string Name) : IEmployee
{
	public void PrintInfo()
		=> Console.WriteLine($"\t\t{Name}");
}

record Manager(string Name, IEmployee[] Subordinates) : IEmployee, IPeoplesManager
{
	public void PrintInfo()
	{
		Console.WriteLine($"\tGerente: {Name}, que gerencia:");
		
		foreach (var s in Subordinates)
			s.PrintInfo();
	}
}

record Head(string Name, IEmployee[] Subordinates) : IEmployee, IPeoplesManager
{
	public void PrintInfo()
	{
		Console.WriteLine($"Diretor: {Name} coordena:");

		foreach (var s in Subordinates)
		{
			Console.WriteLine("-------------");
			s.PrintInfo();
		}
	}
}
