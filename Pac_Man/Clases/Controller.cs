using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pac_Man.Clases
{
    class Controller
    {
        private static List<Characters> characters;
        private static List<Usuarios> usuarios;
        private static List<Fruits> frutas;
        private static Usuarios current;

        public static void Serializar()
        {
            BinaryFormatter serializador = new BinaryFormatter();
            Stream miStream = new FileStream("Characters.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            serializador.Serialize(miStream, characters);
            miStream.Close();

            BinaryFormatter serializador2 = new BinaryFormatter();
            Stream miStream2 = new FileStream("Usuarios.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            serializador2.Serialize(miStream2, usuarios);
            miStream2.Close();

            BinaryFormatter serializador3 = new BinaryFormatter();
            Stream miStream3 = new FileStream("Frutas.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            serializador3.Serialize(miStream3, frutas);
            miStream3.Close();
        }

        public static void Deserializar()
        {
            if (File.Exists("Characters.txt"))
            {
                BinaryFormatter serializador = new BinaryFormatter();
                Stream miStream = new FileStream("Characters.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                characters = (List<Characters>)serializador.Deserialize(miStream);
                miStream.Close();
            }
            if (File.Exists("Usuarios.txt"))
            {
                BinaryFormatter serializador2 = new BinaryFormatter();
                Stream miStream2 = new FileStream("Usuarios.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                usuarios = (List<Usuarios>)serializador2.Deserialize(miStream2);
                miStream2.Close();
            }
            if (File.Exists("Frutas.txt"))
            {
                BinaryFormatter serializador3 = new BinaryFormatter();
                Stream miStream3 = new FileStream("Frutas.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                frutas = (List<Fruits>)serializador3.Deserialize(miStream3);
                miStream3.Close();
            }

        }
    }
}
