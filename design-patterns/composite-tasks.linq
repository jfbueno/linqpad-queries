<Query Kind="Program" />

void Main()
{
	ITask simpleTask1 = new SimpleTask("Tarefa Simples 1");
	ITask simpleTask2 = new SimpleTask("Tarefa Simples 2");

	ProductBacklog compositeTask1 = new ProductBacklog("Tarefa Composta 1");
	compositeTask1.AddSubtask(simpleTask1);
	compositeTask1.AddSubtask(simpleTask2);

	ITask simpleTask3 = new SimpleTask("Tarefa Simples 3");
	ITask simpleTask4 = new SimpleTask("Tarefa Simples 4");

	ProductBacklog compositeTask2 = new ProductBacklog("Tarefa Composta 2");
	compositeTask2.AddSubtask(simpleTask3);
	compositeTask2.AddSubtask(simpleTask4);

	// Criando uma tarefa composta que contém outras tarefas simples e compostas
	ProductBacklog mainTask = new ProductBacklog("Tarefa Principal");
	mainTask.AddSubtask(compositeTask1);
	mainTask.AddSubtask(compositeTask2);
	mainTask.AddSubtask(new SimpleTask("Tarefa Simples 5"));

	// Executando a tarefa principal
	Console.WriteLine("Executando a Tarefa Principal:");
	mainTask.Execute();
}

interface ITask
{
	void Execute();
}

record SimpleTask(string Name) : ITask
{
	public void Execute()
		=> Console.WriteLine($"Executando tarefa simples: {Name}");
}

/// <summary>
/// Composite: Implementação específica para tarefa composta (conjunto de subtasks)
/// </summary>
record ProductBacklog(string Name, List<ITask> Subtasks) : ITask
{
	public ProductBacklog(string name) : this(name, new()) { }

	public void AddSubtask(ITask subtask)
		=> Subtasks.Add(subtask);

	public void Execute()
	{
		Console.WriteLine($"Executando tarefa composta: {Name}");
		
		foreach (var subtask in Subtasks)
			subtask.Execute();
	}
}