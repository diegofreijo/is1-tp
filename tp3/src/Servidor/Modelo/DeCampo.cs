using System;
using Servidor.Modelo;
namespace CasinoOnline.Servidor.Modelo
{
	public class DeCampo : ApuestaCraps
	{

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public DeCampo(Diccionario<Creditos, Entero> fichas, Jugador apostador, EstadoApuestaCraps estado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
			return null;
		}

		public override Texto ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
			return null;
		}

	}
}
