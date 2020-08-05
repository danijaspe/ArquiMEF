using System;


namespace MEF
{
	// Estructura usada para los monstruos y la cura
	public struct S_objeto
	{
		public bool activo;	// Indica si el objeto es visible o no
		public int x,y;		// Coordenadas del objeto
	}

	public class LogicaMaquina
	{
		// Diferentes estados que puede tomar el héroe
		public enum  estados
		{
			BUSQUEDA,
			NBUSQUEDA,
			BUSCARVIDA, 
			CURARSE,
			MUERTO,
			DETENIDO,
		};

		// Esta variable representa el estado actual de la maquina
		private int Estado;
		private String Estadotxt;

		// Estas variables son las coordenadas del heroe
		private int x,y;

		private S_objeto[] monstruos = new S_objeto[10];
		private S_objeto cura;

		// Indice del objeto que se busca
		private int indice;

		// Aquí se guarda la energía
		private int vida;

		// Creamos las propiedades necesarias
		public int CoordX 
		{
			get {return x;}
		}

		public int CoordY
		{
			get {return y;}
		}
		public int EstadoM
		{
			get {return Estado;}
		}
		public String EstadoStr
		{
			get { return Estadotxt; }
		}
		public int VidaRestante
		{
			get { return vida; }
		}
		public LogicaMaquina()
		{

			Estado=(int)estados.NBUSQUEDA;	// Colocamos el estado de inicio.
			x=320;		// Coordenada X
			y=240;		// Coordenada Y
			indice=-1;	// Empezamos como si no hubiera objeto a buscar
			vida=800;
		}

		public void Inicializa(ref S_objeto [] Pmonstruos, S_objeto Pcura)
		{
			// Creamos una copia de los monstruos y la cura para trabajar con ellos en el programa
			monstruos = Pmonstruos;
			cura=Pcura;
		}

		public void Control()
		{
			// Aquí se hace todo el manejo de los estados
			switch(Estado)
			{
				case (int)estados.BUSQUEDA:
					// Se procede a buscar el objetivo
					Busqueda();

					// Verificamos por transicion
					if (x == monstruos[indice].x && y == monstruos[indice].y)
					{
						// Desactivamos el objeto encontrado
						monstruos[indice].activo = false;

						// Cambiamos de estado
						Estado = (int)estados.NBUSQUEDA;
						Estadotxt = "Buscando nuevo objetivo";

					}
					else if (vida < 300)
					{// Cambiamos el estado si está bajo de vida
						Estado = (int)estados.BUSCARVIDA;
						Estadotxt = "Camino a recuperarse";

					}
					break;

				case (int)estados.NBUSQUEDA:
					// Se procede a localizar un nuevo objetivo
					NuevaBusqueda();

					// Verificamos si no hay más monstruos
					if (indice == -1)
					{   // Si ya no hay monstruos, entonces DETENIDO
						Estado = (int)estados.DETENIDO;
						Estadotxt = "Festejando";
					}

					else
					{
						Estado = (int)estados.BUSQUEDA;
						Estadotxt = "Camino al objetivo";
					}
					break;
					
				case (int)estados.BUSCARVIDA:
					//Se selecciona como objetivo la vida para recuperarse
					BUSCARVIDA();
					if (x == cura.x && y == cura.y)
					{
						Estado = (int)estados.CURARSE;
						Estadotxt = "Recuperandose";
					}

					if (vida == 0)
					{
						Estado = (int)estados.MUERTO;
						Estadotxt = "Fallecido";
					}
					break;

				case (int)estados.CURARSE:
					//Se llego a la cura y procede a reestablecer la vida
					CURARSE();
					Estado=(int)estados.BUSQUEDA;
					//Vuelve por el objetivo buscado
					Estadotxt = "Camino al objetivo";

					break;

				case (int)estados.DETENIDO:
					DETENIDO();
					if (vida == 0)
					{
						Estado = (int)estados.MUERTO;
						Estadotxt = "Fallecido";
					}
					break;

			}

		}

		public void Busqueda()
		{
			//Se mueve hacia el objetivo y se resta vida
			if(x<monstruos[indice].x)
				x++;
			else if(x>monstruos[indice].x)
				x--;
			if(y<monstruos[indice].y)
				y++;
			else if(y>monstruos[indice].y)
				y--;
			vida--;

		}

		public void NuevaBusqueda()
		{
			//Se busca el proximo objetivo activo
			indice=-1;
			for(int n=0;n<10;n++)
			{
				if(monstruos[n].activo==true)
					indice=n;
			}
		}

		public void DETENIDO()
		{
			//Finaliza la caceria
			Random random=new Random();
			int nx=random.Next(0,3);
			int ny=random.Next(0,3);
			x+=nx-1;
			y+=ny-1;
		}

		public void BUSCARVIDA()
		{
			//Se moviliza hacia la cura
			if(x<cura.x)
				x++;
			else if(x>cura.x)
				x--;
			if(y<cura.y)
				y++;
			else if(y>cura.y)
				y--;
			vida--;

		}

		public void CURARSE()
		{
			//Restaura vida
			vida=1000;
		}



	}
}
