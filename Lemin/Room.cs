using System;
using System.Collections.Generic;
using System.Text;

namespace Lemin
{
    enum Roomtype
    {
        start,
        usual,
        end
    }
    class Room
    {
        public string name;
        public int[] coords = new int[2];
        public Roomtype type;

        public void Create_Room(string[] item, int check)
        {
            this.name = item[0];
            this.coords[0] = Convert.ToInt32(item[1]);
            this.coords[1] = Convert.ToInt32(item[2]);
            this.type = (Roomtype)check;
        }
    }
}
