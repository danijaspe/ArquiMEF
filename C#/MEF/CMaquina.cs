using System;


namespace MEF
{
	// Estructura usada para los monstruos y la cura
	public struct S_objeto
	{
		public bool activo;	// Indica si el objeto es visible o no
		public int x,y;		// Coordenadas del objeto
	}

	public class CMaquina
	{
		// Enumeracion de los diferentes estados
		public enum  estados
		{
			BUSQUEDA,
			NBUSQUEDA,
			BUSCARVIDA,
			CURARSE,
			MUERTO,
			ALEATORIO,
		};

		// Esta variable representa el estado actual de la maquina
		private int Estado;
		private String Estadotxt;

		// Estas variables son las coordenadas del heroe
		private int x,y;

		private S_objeto[] monstruos = new S_objeto[10];
		private S_objeto cura;

		// Variable del indice del objeto que buscamos
		private int indice;

		// Variable para la energia;
		private int energia;

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
			get { return energia; }
		}

		public CMaquina()
		{

			Estado=(int)estados.NBUSQUEDA;	// Colocamos el estado de inicio.
			x=320;		// Coordenada X
			y=240;		// Coordenada Y
			indice=-1;	// Empezamos como si no hubiera objeto a buscar
			energia=800;
		}

		public void Inicializa(ref S_objeto [] Pmonstruos, S_objeto Pcura)
		{
			// Colocamos una copia de los monstruos y la cura
			// para pode trabajar internamente con la informacion
			monstruos=Pmonstruos;
			cura=Pcura;
		}

		public void Control()
		{
			// Esta funcion controla la logica principal de la maquina de estados
			
			switch(Estado)
			{
				case (int)estados.BUSQUEDA:
					// Llevamos a cabo la accion del estado
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
					else if (energia < 400)
					{// Checamos condicion de transicion
						Estado = (int)estados.BUSCARVIDA;
						Estadotxt = "Camino a recuperarse";

					}
					break;

				case (int)estados.NBUSQUEDA:
					// Llevamos a cabo la accion del estado
					NuevaBusqueda();

					// Verificamos por transicion
					if (indice == -1)
					{   // Si ya no hay monstruos, entonces aleatorio
						Estado = (int)estados.ALEATORIO;
						Estadotxt = "Festejando";
					}

					else
					{
						Estado = (int)estados.BUSQUEDA;
						Estadotxt = "Camino al objetivo";
					}

					break;
					
				case (int)estados.BUSCARVIDA:
					BUSCARVIDA();
					if (x == cura.x && y == cura.y)
					{
						Estado = (int)estados.CURARSE;
						Estadotxt = "Recuperandose";
					}

					if (energia == 0)
					{
						Estado = (int)estados.MUERTO;
						Estadotxt = "Fallecido";
					}

					break;

				case (int)estados.CURARSE:
					CURARSE();
					Estado=(int)estados.BUSQUEDA;
					Estadotxt = "Camino al objetivo";

					break;

				case (int)estados.MUERTO:
					Muerto();					
					break;

				case (int)estados.ALEATORIO:
					Aleatorio();

					if (energia == 0)
					{
						Estado = (int)estados.MUERTO;
						Estadotxt = "Fallecido";
					}
					break;

			}

		}

		public void Busqueda()
		{
			if(x<monstruos[indice].x)
				x++;
			else if(x>monstruos[indice].x)
				x--;
			if(y<monstruos[indice].y)
				y++;
			else if(y>monstruos[indice].y)
				y--;
			energia--;

		}

		public void NuevaBusqueda()
		{
			indice=-1;
			for(int n=0;n<10;n++)
			{
				if(monstruos[n].activo==true)
					indice=n;
			}
		}

		public void Aleatorio()
		{
			Random random=new Random();
			int nx=random.Next(0,3);
			int ny=random.Next(0,3);
			x+=nx-1;
			y+=ny-1;
		}

		public void BUSCARVIDA()
		{
			if(x<cura.x)
				x++;
			else if(x>cura.x)
				x--;
			if(y<cura.y)
				y++;
			else if(y>cura.y)
				y--;
			energia--;

		}

		public void CURARSE()
		{
			energia=1000;
		}

		public void Muerto()
		{
		}



	}
}
