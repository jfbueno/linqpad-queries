<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	ITransferenciaRepository repo = new TransferenciaProxyRepository();

	Console.WriteLine(await repo.ObterPorId(Guid.Parse("92f0e101-07f6-4687-bfd2-6f401001b146")));
	Console.WriteLine(DateTime.Now);

	Console.WriteLine(await repo.ObterPorId(Guid.Parse("dd8bb553-c6db-48da-abfe-916084ca50c9")));
	Console.WriteLine(DateTime.Now);

	Console.WriteLine(await repo.ObterPorId(Guid.Parse("92f0e101-07f6-4687-bfd2-6f401001b146")));
	Console.WriteLine(DateTime.Now);
}

interface IDecoracao { }

sealed class TransferenciaProxyRepository : ITransferenciaRepository, IDecoracao
{
	private readonly TransferenciaRepository _repositorioReal = new();
	private readonly Dictionary<Guid, Transferencia> _cacheInterno = new();	
		
	public async Task<Transferencia> ObterPorId(Guid id)
	{
		var transferenciaInternalizada = _cacheInterno.GetValueOrDefault(id);
		
		if (transferenciaInternalizada is not null) 
			return transferenciaInternalizada;
		
		var transferenciaBanco = await _repositorioReal.ObterPorId(id);
		
		_cacheInterno.Add(id, transferenciaBanco);
		
		return transferenciaBanco;
	}
}

interface ITransferenciaRepository
{
	Task<Transferencia> ObterPorId(Guid id);
}

sealed class TransferenciaRepository : ITransferenciaRepository
{
	public async Task<Transferencia> ObterPorId(Guid id)
	{
		await Task.Delay(2_000); // Busca no banco, operação demorada...
		return new(id, 10_00);
	}
}

sealed record Transferencia(Guid id, decimal Valor);