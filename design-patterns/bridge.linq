<Query Kind="Program" />

void Main()
{
	var acessoAoBanco = new ServicoDeAcessoAoBancoDeDados(TipoAcessoBanco.Oracle);
	
	acessoAoBanco.Add(new { });
}

enum TipoAcessoBanco { Oracle, SqlServer, Postgres };

/// <summary>
/// Aqui é possível ter uma API simplificada (ou com features extra) de acesso aos repos
/// </summary>
class ServicoDeAcessoAoBancoDeDados
{
	private readonly IRepository _repository;

	public ServicoDeAcessoAoBancoDeDados(TipoAcessoBanco tipoAcesso)
	{
		_repository = tipoAcesso switch 
		{
			TipoAcessoBanco.SqlServer => new SqlServerRepository(),
			TipoAcessoBanco.Oracle => new OracleRepository(),
			TipoAcessoBanco.Postgres => new PostgresRepository(),
			_ => throw new NotImplementedException()
		};
	}

	public void Add(object obj)
	{
		// Controle de transação - BEGIN TRAN

		if (obj is not null && true) { } // Validações de campos...
		
		
		_repository.Add(obj);
		
		// COMMIT TRAN
	}
}

interface IRepository
{
	void Add(object obj);
}

sealed class SqlServerRepository : IRepository
{
	public void Add(object obj) => Console.WriteLine($"Adicionando pelo {nameof(SqlServerRepository)}");
}

sealed class OracleRepository : IRepository
{
	public void Add(object obj) => Console.WriteLine($"Adicionando pelo {nameof(OracleRepository)}");
}

sealed class PostgresRepository : IRepository
{
	public void Add(object obj) => Console.WriteLine($"Adicionando pelo {nameof(PostgresRepository)}");
}
