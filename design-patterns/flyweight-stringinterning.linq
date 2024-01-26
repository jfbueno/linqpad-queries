<Query Kind="Program" />

void Main()
{
	Console.WriteLine(object.ReferenceEquals("Hello, World!", "Hello, World!")); 
	
	Console.WriteLine(object.ReferenceEquals("Hello, World!", new string("Hello, World!")));
}

