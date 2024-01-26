<Query Kind="Program" />

void Main()
{
	ImprimirArea(new Quadrado(3));
	ImprimirArea(new Retangulo(6, 3));
	ImprimirArea(new CirculoAdapter2(2));

	var circulo = new Circulo(2);
	ImprimirArea(new CirculoAdapter(circulo));
}

void ImprimirArea(IFormaGeometrica forma)
{
	Console.WriteLine(forma.CalcularArea());
}

#region Adapter

record CirculoAdapter(Circulo ObjetoAdaptado) : IFormaGeometrica
{
	public decimal CalcularArea() => (decimal)ObjetoAdaptado.ObterAreaDoCirculo();
}

record CirculoAdapter2(decimal RaioDecimal) : Circulo((double)RaioDecimal), IFormaGeometrica
{	
	public decimal CalcularArea() => (decimal) base.ObterAreaDoCirculo();
}

#endregion

#region Biblioteca geométrica - Nova

interface IFormaGeometrica
{
	decimal CalcularArea();
}

record Quadrado(decimal Lado) : IFormaGeometrica
{
	public decimal CalcularArea() => Lado * Lado;
}

record Retangulo(decimal Base, decimal Altura) : IFormaGeometrica
{
	public decimal CalcularArea() => Base * Altura;
}

#endregion

#region Biblioteca geométrica - antiga

record Circulo(double Raio) 
{
	public double Diametro => Raio * 2;
	public double Circunferencia => 2 * Math.PI * Raio;
	public double ObterAreaDoCirculo() => Math.PI * Raio * Raio;
}

#endregion
