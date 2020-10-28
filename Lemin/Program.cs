using System;
using System.IO;
using System.Text;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Graphviz;
using System.Drawing;
using System.Diagnostics;
using QuickGraph.Graphviz.Dot;

namespace Lemin
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int check = 1;
            StreamReader sr;

            Map map = new Map();
            try
            {
                sr = new StreamReader(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            map.Count_Ants(sr);
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length == 0)
                    break;
                What_Is_It(line, sr, map, ref check);
            }
            map.Search_Start_End();
            Solution(sr, map);
            map.PrintAll();
        }

        static void What_Is_It(string line, StreamReader sr, Map map, ref int check)
        {
            string[] split_line;

            if (line.IndexOf("#") == 0)
                check = Is_Comment(line, sr);
            else if (((split_line = line.Split(' ')).Length) == 3)
                Is_Room(split_line, ref check, map);
            else if (((split_line = line.Split('-')).Length) == 2)
                Is_Link(split_line, map);
            else
                Error();
        }
        static void Is_Room(string[] split_line, ref int check, Map map)
        {
            Room room;

            room = new Room();
            room.Create_Room(split_line, check);
            map.Add_Room(room);
            check = 1;
        }

        static void Is_Link(string[] split_line, Map map)
        {
            Link link;

            link = new Link();
            map.Add_Link(link, split_line);
        }

        static int Is_Comment(string line, StreamReader sr)
        {
            if (String.Compare(line, "##start") == 0)
            {
                return 0;
            }
            else if (String.Compare(line, "##end") == 0)
            {
                return 2;
            }
            return 1;
        }

        static void Error()
        {
            Console.WriteLine("Ошибка");
            Environment.Exit(1);
        }

        static void Solution(StreamReader sr, Map map)
        {
            string line;
            string[] split_line;

            while ((line = sr.ReadLine()) != null)
            {
                split_line = line.Split(' ');
                foreach (string item in split_line)
                    Movement_Ant(item, map);
            }
        }

        static void Movement_Ant(string line, Map map)
        {
            Ant ant;
            int ind;

            ind = line.IndexOf('-');
            if ((ant = map.Is_in_list_ants(line, ind)) != null)
            {
                ant.Step(line, map, ind);
            }
            else
            {
                ant = new Ant();
                ant.Create(line, ind, map);
                map.Add_Ant(ant);
            }
        }


    }
}
