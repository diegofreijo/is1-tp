using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;
	using System.Xml.Linq;

	class JuegoCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoCraps();
			}
			return instancia;
		}
		#endregion


		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		public void ResponderApuestaCraps(IdTerminalVirtual id_terminal, Nombre usuario, IdMesa id_mesa, Boolean aceptado, String descripcion)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("apuestaCraps", new object[] {
				new XAttribute("vTerm", id_terminal),
				new XAttribute("usuario", usuario),
				new XAttribute("mesa", id_mesa),
				new XElement("aceptado", (aceptado ? "si" : "no")),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaApuestaCraps", id_terminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		public void ResponderTiroCraps(IdTerminalVirtual id_terminal, Nombre usuario, IdMesa id_mesa, Boolean aceptado, String descripcion)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("tiroCraps", new object[] {
				new XAttribute("vTerm", id_terminal),
				new XAttribute("usuario", usuario),
				new XAttribute("mesa", id_mesa),
				new XElement("aceptado", (aceptado ? "si" : "no")),
				new XElement("descripcion", descripcion)
			});

			if (aceptado)
			{
				parametros.Add(new object[] {
					new XElement("tipoJugada", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TipoJugadaUltimoTiro(id_mesa)),
					new XElement("resultado", new object[] {
						new XElement("dado1", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado1UltimoTiro(id_mesa)),
						new XElement("dado2", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado2UltimoTiro(id_mesa))
					})
				});
			}
			else
			{
				parametros.Add(new object[] {
					new XElement("tipoJugada"),	new XElement("resultado")
				});
			}

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaTiroCraps", id_terminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

	}
}
