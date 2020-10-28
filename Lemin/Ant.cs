using System;
using System.Collections.Generic;
using System.Text;

namespace Lemin
{
    class Ant
    {
        public string name;
        public List<Room> Path = new List<Room>();
        Room current_room;
        int x;
        int y;

        public void Create(string line, int ind, Map map)
        {
            this.name = line.Substring(0, ind);
            this.Path.Add(map.start_room);
            this.current_room = map.Search_room(line.Substring(ind + 1));
            this.Path.Add(current_room);
            this.x = current_room.coords[0];
            this.y = current_room.coords[1];
        }

        public void Step(string line, Map map, int ind)
        {
            this.current_room = map.Search_room(line.Substring(ind + 1));
            Path.Add(current_room);
            this.x = current_room.coords[0];
            this.y = current_room.coords[1];
        }
    }
}
