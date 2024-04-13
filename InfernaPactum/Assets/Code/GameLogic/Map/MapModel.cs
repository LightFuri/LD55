using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBots.Models.Map
{
    public static class MapModel
    {
        public static ObjectsEnum[,] Map { get; set; }
        private static int _width { get; set; }
        private static int _height { get; set; } 
        public static void Initialize()
        {
            _width = 21;
            _height = 21;
            Map = new ObjectsEnum[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for(int j = 0; j < _height; j++)
                {
                    Map[i, j] = ObjectsEnum.Empty;
                }
            }
        }

        public static void DisplayMap()
        {
            Console.Clear();
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    switch (Map[i, j])
                    {
                        case ObjectsEnum.Empty:
                            Console.Write(". ");
                            break;
                        case ObjectsEnum.Furcas:
                            Console.Write("F ");
                            break;
                        case ObjectsEnum.FurcasEnemy:
                            Console.Write("E ");
                            break;
                        default:
                            Console.Write("? ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
