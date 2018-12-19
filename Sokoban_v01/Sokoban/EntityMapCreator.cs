using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public static class EntityMapCreator
    {
        private static int countBox;
        private static int countBoxParking;
        private static int countPlayer;
        

        public static IMapElement[,] Create(List<string> mapTemplate)
        {
            Exception e = null;
            if (!TryMapTemplate(mapTemplate, e))
                throw e;

            var map = new IMapElement[mapTemplate.Count, mapTemplate[0].Length];

            for (int i = 0; i < mapTemplate.Count; i++)
            {
                for (int j = 0; j < mapTemplate[i].Length; j++)
                    map[i, j] = CreateEntityBySymbol(mapTemplate[i][j], i, j);                  
            }

            //if (countPlayer != 1)
            //    throw new ArgumentException("Can't define current Player position");

            //if (countBox > countBoxParking)
            //    throw new ArgumentException("Count Box more count Box Parking ");

            return map;
        }

        private static void DefaultCounter()
        {
            countBox = 0;
            countBoxParking = 0;
            countPlayer = 0;
        }

        private static bool TryMapTemplate(List<string> mapTemplate, Exception e)
        {
            if (mapTemplate == null)
            {
                e = new ArgumentNullException();
                return false;
            }

            if (mapTemplate.Count == 0)
            {
                e = new ArgumentException("Map template is empty");
                return false;
            }

            int countField = mapTemplate[0].Length;
            foreach (var row in mapTemplate)
                if (countField != row.Length)
                {
                    e = new ArgumentException("Map have not rectangle form");
                    return false;
                }

            return true;
        }

        private static IMapElement CreateEntityBySymbol(char c,int x, int y)
        {
            switch (c)
            {
                case 'W':
                    return (IMapElement)new Wall(x,y);
                case 'X':
                    countBoxParking++;
                    return (IMapElement)new BoxParking(x,y);
                case ' ':
                    return (IMapElement)new Floor(x,y);
                default:
                    return null;
            }
        }


    }
}
