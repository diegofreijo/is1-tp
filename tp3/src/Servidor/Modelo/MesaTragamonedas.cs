using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using IdMesa = Int32;

	class MesaTragamonedas : Mesa
	{
		#region Miembros

		private Creditos valor_ficha;
		private ApuestaTragamonedas apuesta = null;
		
		#endregion

		#region Metodos Publicos
		
		public MesaTragamonedas(IdMesa id, Creditos valor_ficha)
		{
			this.id = id;
			this.valor_ficha = valor_ficha;
		}
		public void GirarRodillos()
		{
			throw new NotImplementedException();
		}
		public bool HayApuesta()
		{
			throw new NotImplementedException();
		}
		public void Apostar(ApuestaTragamonedas apuesta)
		{
			throw new NotImplementedException();
		}
		
		#endregion
	}
}
