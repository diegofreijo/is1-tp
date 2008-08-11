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
			// Pido los dados
			KeyValuePair<Dado, Dado> dados = ServidorJugadas.ObtenerInstancia().CalcularDados(this.id);
			int sumaDados = dados.Key.Numero + dados.Value.Numero;

			// Pido el tipo de jugada
			TipoJugada tipoJugada = ServidorJugadas.ObtenerInstancia().CalcularTipoJugadaDeCasinoCraps(this.id);

			// Creo el resultado y la jugada
			ResultadoCraps resultado = new ResultadoCraps(dados.Key, dados.Value, this.estado, this.punto);
			JugadaCraps jugada = new JugadaCraps(this.proximo_tirador, resultado, tipoJugada, 
				Pozos.ObtenerInstancia().PozoFeliz, this.estado, this.punto, this.apuestas);

			// Le pido a la jugada que se resuelva
			jugada.Resolverse();

			// Veo como seguir segun mi estado y lo que salio en los dados
			if(estado == EstadoRondaCraps.EstanSaliendo)
			{
				if(new int[] { 2, 3, 12 }.Contains(sumaDados))
				{
					// El tirador pierde de una
					CambiarTirador();
				}
				else if (new int[] { 4, 5, 6, 8, 9, 10 }.Contains(sumaDados))
				{
					// Se establece el punto
					punto = sumaDados;
					estado = EstadoRondaCraps.PuntoEstablecido;
				}
				else
				{
					// Es porque los dados son 7 u 11, entonces el jugador ganaria con lo cual seguiria siendo 
					// el tirador y el estado para la proxima ronda sigue siendo estanSaliendo
				}
			}
			else
			{
				if(sumaDados == 7)
				{
					// El tirador pierde
					CambiarTirador();
					estado = EstadoRondaCraps.EstanSaliendo;
					punto = null;
				}
				else if(sumaDados == (int)punto)
				{
					// Sale punto antes que 7, tirador gana
					estado = EstadoRondaCraps.EstanSaliendo;
					punto = null;
				}
				else
				{
					// Cualquier otro numero que salga es indiferente y todo se mantiene igual
				}
			}

			// Le pido a la jugada las apuestas no resueltas
			apuestas = jugada.ApuestasNoResueltas();

			// Guardo la jugada en el historial y la registro como que fue mi ultima jugada
			HistorialJugadas.ObtenerInstancia().JugadasCraps.Add(jugada);
			this.ultima_jugada = jugada;

			// Notifico el cambio en la mesa
			observador_cambios.NotificarCambio(this.id);
		}
		public void AgregarApuesta(ApuestaCraps apuesta)
		{
			// Agrego la apuesta
			apuestas.Add(apuesta);

			// Aviso el cambio
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
					CambiarTirador();
				}
			}
		}

		#endregion


		#region Metodos Privados

		private void CambiarTirador()
		{
			// Pongo al primero en la lista como siguiente
			proximo_tirador = jugadores_en_mesa[0];

			// Saco a este tirador y pongo al que sigue como siguiente tirador
			jugadores_en_mesa.RemoveAt(0);
			jugadores_en_mesa.Add(proximo_tirador);
		}

		#endregion
	}
}
