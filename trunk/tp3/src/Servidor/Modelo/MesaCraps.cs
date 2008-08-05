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
		private int? punto = null;
		private MensajeroDeSalida.IMesaObserver observador_cambios = null;
		private List<ApuestaCraps> apuestas = new List<ApuestaCraps>();
		
		#endregion


		#region Propiedades

		public EstadoRondaCraps Estado
		{
			get { return estado; }
		}
		public int? Punto
		{
			get { return punto; }
		}
		public List<ApuestaCraps> Apuestas
		{
			get { return apuestas; }
		}
		
		#endregion


		#region Metodos Publicos

		public MesaCraps(IdMesa id, MensajeroDeSalida.IMesaObserver observador)
		{
			this.id = id;
			this.observador_cambios = observador;
			estado = EstadoRondaCraps.EstanSaliendo;
		}
		public void TirarDados()
		{
			throw new NotImplementedException();
		}
		public void AgregarApuesta(ApuestaCraps apuesta)
		{
			throw new NotImplementedException();
			observador_cambios.NotificarCambio(this.id);
		}
		public override void AgregarJugador(Jugador jugador)
		{
			jugadores_en_mesa.Add(jugador);

			// Si es el unico jugador en la mesa, pasa a ser el tirador
			if(jugadores_en_mesa.Count == 1)
				proximo_tirador = jugador;

			observador_cambios.NotificarCambio(this.id);
		}
		public override void QuitarJugador(Jugador jugador)
		{
			jugadores_en_mesa.Remove(jugador);
			observador_cambios.NotificarCambio(this.id);

			// AGREGADO: Si no hay nadie mas jugando en mi, me mato
			if (jugadores_en_mesa.Count == 0)
			{
				MesasAbiertas.ObtenerInstancia().BorrarMesaCraps(this.id);
			}
			else
			{
				// Si era el proximo tirador, elijo otro
				if (proximo_tirador == jugador)
				{
					SeleccionarProximoTirador();
				}
			}
		}

		#endregion


		#region Metodos Privados

		private void SeleccionarProximoTirador()
		{
			proximo_tirador = jugadores_en_mesa[new Random().Next(jugadores_en_mesa.Count)];
		}

		#endregion
	}
}
