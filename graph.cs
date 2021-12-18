using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System;

namespace Do_An_Graph
{
    public class Distoriginal
    {
        public int distance; public int parentVert;
        public Distoriginal(int pv, int d)
        {
            distance = d; parentVert = pv;
        }
    }
    public class Vertex
    {
        public Location label;
        public bool isInTree;
        public Vertex(Location lab) { label = lab; isInTree = false; }
    }
    public class Graph
    {
        private const int max_verts = 10;
        int infinity = 100;
        Vertex[] vertexList; int[,] adjMat; int[,] adjMat2;
        int nVerts; int nTree; Distoriginal[] spath;
        int currentVert; int startToCurrent;

        public Graph()
        {
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            adjMat2 = new int[max_verts, max_verts];
            nVerts = 0; nTree = 0;
            for (int j = 0; j < max_verts; j++)
                for (int k = 0; k < max_verts; k++)
                    adjMat[j, k] = infinity;
            spath = new Distoriginal[max_verts];
        }

        public int Property
        {
            get => default;
            set
            {
            }
        }

        public void AddVertex(Location lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start, theEnd] = weight;
            adjMat2[start, theEnd] = 1;
        }
    /*    public void Path()
        {
            int startTree = 0;
            vertexList[startTree].isInTree = true;
            nTree = 1;
            for (int j = 0; j < nVerts; j++)
            {
                int tempDist = adjMat[startTree, j];
                spath[j] = new Distoriginal(startTree, tempDist);
            }
            while (nTree < nVerts)
            {
                int indexMin = GetMin();
                int minDist = spath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = spath[indexMin].distance;
                vertexList[currentVert].isInTree = true;
                nTree++;
                AdjustShortPath();
            }
            int sc = 0;
            DisplayPaths(sc);
            nTree = 0;
            for (int j = 0; j < nVerts; j++)
                vertexList[j].isInTree = false;
        }*/
        public int GetMin()
        {
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 1; j <= nVerts - 1; j++)
                if (!(vertexList[j].isInTree) && spath[j].distance < minDist)
                {
                    minDist = spath[j].distance; indexMin = j;
                }
            return indexMin;
        }
        public void AdjustShortPath()
        {
            int column = 1;
            while (column < nVerts)
                if (vertexList[column].isInTree) column++;
                else
                {
                    int currentToFring = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFring;
                    int sPathDist = spath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        spath[column].parentVert = currentVert;
                        spath[column].distance = startToFringe;
                    }
                    column++;
                }
        }
        public void DisplayPaths(int nVerts)
        {
            for (int j = 0; j <= nVerts - 1; j++)
            {
                Location parent = vertexList[spath[0].parentVert].label;
                Console.Write("Từ " + parent.GetName() + " đến " + vertexList[j].label.GetName() + " = ");
                if (spath[j].distance == infinity) Console.Write("inf");
                    else Console.Write(spath[j].distance + " km");
            }
        }

        public void DisplayPaths2(string cs)
        {
            
            switch (cs)
            {
                case "A": DisplayPaths(0); break;
                case "B": DisplayPaths(1); break;
                case "C": DisplayPaths(2); break;
                case "D": DisplayPaths(3); break;
                case "E": DisplayPaths(4); break;
                case "H": DisplayPaths(5); break;
                case "I": DisplayPaths(6); break;
                case "V": DisplayPaths(7); break;
                case "G": DisplayPaths(8); break;
                case "N": DisplayPaths(9); break;
                default:  Console.WriteLine("Nhập sai xin vui lòng nhập lại !"); break;
            }

        }
        public void ShowVerts()
        {
            foreach (Vertex e in vertexList)
            {
                Console.WriteLine((e.label).ToString());
            }
        }
        public void ShowVertex(int v)
        {
            Console.WriteLine(vertexList[v].label.ToString() + " ");
        }
        private int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j <= nVerts - 1; j++)
                if ((adjMat2[v, j] == 1) && (vertexList[j].isInTree == false))
                    return j;
            return -1;
        }
        public void BreadthFirstSearch()
        {
            Queue gQueue = new Queue();
            vertexList[0].isInTree = true;
            ShowVertex(0);
            gQueue.Enqueue(0);
            int vert1, vert2;
            while (gQueue.Count > 0)
            {
                vert1 = (int)gQueue.Dequeue();
                vert2 = GetAdjUnvisitedVertex(vert1);
                while (vert2 != -1)
                {
                    vertexList[vert2].isInTree = true;
                    ShowVertex(vert2);
                    gQueue.Enqueue(vert2);
                    vert2 = GetAdjUnvisitedVertex(vert1);
                }
            }
            for (int i = 0; i <= nVerts - 1; i++)
                vertexList[i].isInTree = false;
        }
        public void DepthFirstSearch()
        {
            vertexList[0].isInTree = true;
            ShowVertex(0);
            Stack gStack = new Stack();
            gStack.Push(0);
            int v;
            while (gStack.Count > 0)
            {
                v = GetAdjUnvisitedVertex((int)gStack.Peek());
                if (v == -1)
                    gStack.Pop();
                else
                {
                    vertexList[v].isInTree = true;
                    ShowVertex(v);
                    gStack.Push(v);
                }
            }
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isInTree = false;
        }
    }
}
