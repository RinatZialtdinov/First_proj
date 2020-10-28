using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lemin
{
    class Map
    {
        static int number_of_ant;
        static int number_of_rooms = 0;
        //static int number_of_links = 0;
        public List<Room> rooms = new List<Room>();
        public List<Link> links = new List<Link>();
        List<Ant> ants = new List<Ant>();
        public Room start_room;
        public Room end_room;

        public void Count_Ants(StreamReader sr)
        {
            string line;

            line = sr.ReadLine();
            number_of_ant = Convert.ToInt32(line);
        }

        public void Add_Room(Room item)
        {
            rooms.Add(item);
            number_of_rooms++;
        }

        public void Add_Link(Link item, string[] split_line)
        {
            foreach (Room i in rooms)
            {
                if (i.name == split_line[0])
                {
                    item.from = i;
                }
                else if (i.name == split_line[1])
                {
                    item.to = i;
                }
            }
            links.Add(item);
        }

        public void Add_Ant(Ant ant)
        {
            ants.Add(ant);
        }

        public Ant Is_in_list_ants(string item, int ind)
        {
           // if (ants.name.IndexOf(item.Substring(ind)))
            foreach (Ant ant in ants)
            {
                if (String.Compare(item.Substring(0, ind), ant.name) == 0)
                {
                    return ant;
                }
            }
            return null;
        }

        public void Search_Start_End()
        {
            foreach (Room item in rooms)
            {
                if (item.type == (Roomtype) 0)
                {
                    start_room = item;
                }
                else if (item.type == (Roomtype) 2)
                {
                    end_room = item;
                }
            }
        }
        
        public Room Search_room(string name_room)
        {
            foreach (Room item in rooms)
            {
                if (String.Compare(item.name, name_room) == 0)
                    return item;
            }
            return null;
        }

        public void PrintAll()
        {
            Console.WriteLine($"Кол-во муравьев {number_of_ant}");
            Console.WriteLine($"Кол-во комнат {number_of_rooms}");
            foreach (Room item in rooms)
            {
                Console.WriteLine($"Название: {item.name}, координаты: x-{item.coords[0]}, y-{item.coords[1]}, тип {item.type}");
            }
            Console.WriteLine();
            foreach (Ant item in ants)
            {
                Console.Write($"Имя муравья: {item.name}, путь: ");
                foreach (Room room in item.Path)
                {
                    Console.Write($"{room.name}->");
                }
                Console.WriteLine();
            }

        }
    }
}