using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	enum EstadoApuestaCraps { Iniciada, EnTranscurso, Cerrada };
	enum EstadoRondaCraps { EstanSaliendo, PuntoEstablecido };
	enum ValorPuntoCraps { Cuatro, Cinco, Seis, Ocho, Nueve, Diez };
	enum FiguraRodillo { Blanco, Cereza, BarSimple, BarDoble, BarTriple, Dinosaurio };
}
