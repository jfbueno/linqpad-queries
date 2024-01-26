<Query Kind="Program" />

void Main()
{
	
}

public sealed class OcorrenciaArquivoRetorno
{
	public static readonly string PagamentoDisponivelAntecipacao = "RS";
	public static readonly string PagamentoAntecipado = "PD";
	public static readonly string PagamentoCancelado = "CE";

	public string CodigoOcorrencia { get; }

	private OcorrenciaArquivoRetorno(string codigoOcorrencia)
	{
		CodigoOcorrencia = codigoOcorrencia;
	}

	public override string ToString() => CodigoOcorrencia;

	public static implicit operator string (OcorrenciaArquivoRetorno ocorrencia) => ocorrencia.CodigoOcorrencia;
	
	public static explicit operator OcorrenciaArquivoRetorno(string codOcorrencia) => new OcorrenciaArquivoRetorno(codOcorrencia);
}
