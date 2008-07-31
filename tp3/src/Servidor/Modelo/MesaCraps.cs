using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using IdMesa = Int32;

	class MesaCraps : Mesa
	{
		#region Miembros

		private EstadoRondaCraps estado;
		private int punto;
		private MesaCrapsObserver observador_cambios;
		private List<ApuestaCraps> apuestas;
		
		#endregion


		#region Metodos Publicos
		
		public MesaCraps(IdMesa id, MesaCrapsObserver observador)
		{
			this.id = id;
			this.observador_cambios = observador;
		}
		public void TirarDados()
		{
			throw new NotImplementedException();
		}
		public void AgregarApuesta(ApuestaCraps apuesta)
		{
			throw new NotImplementedException();
		}
		
		#endregion
	}
}
