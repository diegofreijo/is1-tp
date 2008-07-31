using System;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	public class ConfiguracionGeneralDelCasino
	{
		private List<Creditos> fichas_validas;
		private Creditos saldo_casino;
		private String password_admin;


		public List<Creditos> FichasValidas
		{
			get { return fichas_validas; }
		}
		public Creditos SaldoCasino
		{
			get { return saldo_casino; }
		}
		public String PasswordAdmin
		{
			get { return password_admin; }
		}


		/// 
		/// <param name="fichas_validas"></param>
		/// <param name="saldo_casino"></param>
		/// <param name="pass"></param>
		public ConfiguracionGeneralDelCasino(Coleccion<Creditos> fichas_validas, Creditos saldo_casino, String pass)
		{
			this.fichas_validas = fichas_validas;
			this.saldo_casino = saldo_casino;
			this.password_admin = pass;
		}
	}
}
