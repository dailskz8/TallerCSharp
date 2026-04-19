using System;
using System.IO;

namespace TallerIujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01 ===\n");			
			
			// 1. El dato del usuario
			string registroUsuario = "     ID_777;    dailskz8;    EVALUACION; 95";
			
			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes [0].Trim();
			string nombre = partes [1].Trim();
			string tarea = partes [2].Trim();
			string nota = partes [3].Trim();
			
			Console.WriteLine(string.Format("El id es: {0} del usuario {1} con la nota {2}",id,nombre,nota));

			
			// Flujo en archivos
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");
			
			string rutaReportes = Path.Combine(rutaraiz, "Reportes");
						
			if (!Directory.Exists(rutaReportes)){
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Directorio creado exitosamente");
			    }
			
			string archivotexto = Path.Combine(rutaraiz,"Notas.txt");
			
			Console.WriteLine(archivotexto);
			
			using(StreamWriter sw = new StreamWriter(archivotexto,true)){
				
				sw.WriteLine(string.Format("ID: {0} | Nota: {1} | Fecha: {2: yyyy-MM-dd HH:mm}", id,nota,DateTime.Now));
				
			}
			
					
			DesafioUno();
    		DesafioDos();
    		DesafioTres();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
    static void DesafioUno() {
			
			
        Console.WriteLine("\n--- Desafío 1: Validador ---\n");
        
        string datos = "usuario;clave123";
        
        string[] partes = datos.Split(';');
        
        if (partes[1].Contains("123")) {
           
            using (StreamWriter sw = new StreamWriter("seguridad.txt", true)) {
        		
                sw.WriteLine("Clave Débil detectada para: " + partes[0]);
                Console.WriteLine("Clave Débil detectada para: " + partes[0]);
                
            }
            Console.WriteLine("Aviso guardado en seguridad.txt\n");
        }
    }

    static void DesafioDos() {
			
			
        Console.WriteLine("--- Desafío 2: Clonador ---\n");
        
        if (File.Exists("avatar.jpg")) {
        	
            using (FileStream origen = new FileStream("avatar.jpg", FileMode.Open))
            	
            using (FileStream destino = new FileStream("respaldo.jpg", FileMode.Create)) {
            	
                byte[] buffer = new byte[1024];
                
                int bytesLeidos;
                
                while ((bytesLeidos = origen.Read(buffer, 0, buffer.Length)) > 0) {
                	
                    destino.Write(buffer, 0, bytesLeidos);
                }
            }
            Console.WriteLine("Imagen copiada byte a byte.\n");
        } else {
            Console.WriteLine("Error: Coloca una imagen llamada 'avatar.jpg' en bin/Debug\n");
        }
    }
		
		static void DesafioTres() {
			
			
        Console.WriteLine("\n--- Desafío 3: Buscador Pesado ---\n");
       
        string ruta = AppDomain.CurrentDomain.BaseDirectory;

        string[] archivos = Directory.GetFiles(ruta);
        
        foreach (string arc in archivos) {
           
            FileInfo info = new FileInfo(arc);
            
            
            if (info.Length > 5120) {
                Console.WriteLine("Archivo detectado (>5KB): " + info.Name);
                
            }
        }
    }
		
	}
	
}