using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace worldmap
{
    internal class Class1
    {
        List<int>[] adj = new List<int>[1000];
        public int[] color = new int[1000];
        int n, m;
        bool is_safe(int v, int c)
        {
            for (int i = 0; i < adj[v].LongCount(); i++)
            {
                int u = adj[v][i];
                if (color[u] == c)
                {
                    return false;
                }
            }
            return true;
        }
        int get_remaining_values(int v)
        {
            int remaining = 0;
            // khai báo 1 mảng 10 phần tử đều bằng false
            bool[] used_color = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                used_color[i] = false;
            }

            for (int i = 0; i < adj[v].Count(); i++)
            {
                int u = adj[v][i];
                if (color[u] != -1)
                {
                    used_color[color[u]] = true;
                }
            }

            for (int i = 0; i <= 9; i++)
            {
                if (!used_color[i])
                {
                    remaining++;
                }
            }
            return remaining;
        }
        int tinh_bac(int v)
        {
            return adj[v].Count();
        }
        bool graph_coloring(int v)
        {

            if (v == n + 1)
            {
                return true;
            }

            List<int> nodes = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (color[i] == -1)
                {
                    nodes.Add(i);
                }
            }
            Console.WriteLine("\nCac dinh trong nodes: ");
            foreach (int i in nodes)
            {
                Console.Write("{0} ", i);
            }
            for (int i = 1; i < nodes.Count; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    if (tinh_bac(nodes[j]) > tinh_bac(nodes[i]))
                    {
                        int temp = nodes[j];
                        nodes[j] = nodes[i];
                        nodes[i] = temp;
                    }
                    if (tinh_bac(nodes[j]) == tinh_bac(nodes[i]))
                    {
                        if (get_remaining_values(nodes[j]) < get_remaining_values(nodes[i]))
                        {
                            int temp = nodes[j];
                            nodes[j] = nodes[i];
                            nodes[i] = temp;
                        }

                    }
                }
            }
            Console.WriteLine("\nCac dinh trong nodes sau khi sap xep: ");
            foreach (int i in nodes)
            {
                Console.Write("{0} ", i);
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                int u = nodes[i];
                for (int c = 0; c <= 9; c++)
                {
                    if (is_safe(u, c))
                    {
                        color[u] = c;
                        if (graph_coloring(v + 1))
                        {
                            return true;
                        }
                        color[u] = -1; // backtrack
                    }
                }
            }
            return false;

        }
        public Class1()
        {
            string filePath = "C:\\Users\\ezernt\\source\\repos\\worldmap\\worldmap\\input.txt";

            // Đọc các dòng của tệp tin
            string[] lines = File.ReadAllLines(filePath);
            string[] firstLine = lines[0].Split(' ');
            n = int.Parse(firstLine[0]); // Số đỉnh
            m = int.Parse(firstLine[1]); // Số cạnh
            Console.WriteLine(n);
            Console.WriteLine(m);
            // khởi tạo List trong mảng
            for (int i = 1; i <= n; i++)
            {
                adj[i] = new List<int>();
            }
            // Lặp qua từng dòng, bắt đầu từ dòng thứ hai
            for (int i = 1; i <= m; i++)
            {
                // Tách các đỉnh của cạnh bằng khoảng trắng
                string[] vertices = lines[i].Split(' ');

                // Lấy ra 2 đỉnh và thêm vào danh sách kề
                int vertex1 = int.Parse(vertices[0]);
                int vertex2 = int.Parse(vertices[1]);
                adj[vertex1].Add(vertex2);
                adj[vertex2].Add(vertex1);
            }
            for (int i = 1; i <= n; i++)
            {              
                Console.Write("Danh sách kề của đỉnh {0}: ", i);
                foreach (int j in adj[i])
                {
                    Console.Write("{0} ", j);
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                color[i] = -1; // mac dinh cac dinh chua to.
            }
            if (graph_coloring(1))
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine("dinh {0} co mauu: {1}", i, color[i]);
                }
            }
        }

    }
}
