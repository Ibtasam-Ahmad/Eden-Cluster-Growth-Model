using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace EdenClusterModel
{
    class EdenCluster
    {
        // Decleare Data Variables
        int size = 100;
        //int pszie = 4;
        int[,] cluster; // 2 Dimentional Region, Represents the cluster region
        float x0 = 0, y0 = 0, dx, dy; // Center Coordinates of TextBox1
        Random obj;
        int x, y;
        bool check = false;
        
        // Graphical Setup
        Graphics gg;
        SolidBrush bb, br;
        Pen bl;

        // Now defining Constructor
        public EdenCluster(Form1 frm)
        {
            gg = frm.textBox1.CreateGraphics();

            x0 = (float)frm.textBox1.Width/2;
            y0 = (float)frm.textBox1.Height/2;
            // By this coordinates of the ceter are find

            dx = (float)frm.textBox1.Width/(2 * size);
            dy = (float)frm.textBox1.Height/(2 * size);

            bb = new SolidBrush(Color.Blue);
            br = new SolidBrush(Color.Red);
            bl = new Pen(Color.Black);

            obj = new Random();

            cluster = new int[2 * size + 1, 2 * size + 1];
            // Initialization of the CLuster Class
            for (int i = 0; i < (2 * size + 1); i++)
            {
                for (int j = 0; j < (2 * size + 1); j++)
                {
                    cluster[i, j] = 0;
                    gg.DrawEllipse(bl, j * dx, i * dy, 5, 5);
                    if (i == size && j == size)
                    {
                        cluster[i, j] = 1; // Seed has been Placed
                        gg.FillEllipse(br, j * dx, i * dy, 5, 5);
                    } // Seed has been Placed
                }
            }
        }
        // End of CLuster
        // Now Defining other functions

        public void Growth(bool filled)
        {
            while (!filled)
            {
                for (int i = 1; i < (2 * size); i++)
                {
                    for (int j = 1; j < (2 * size); j++)
                    {
                        x = obj.Next(1, 2 * size);
                        y = obj.Next(1, 2 * size);
                        if (cluster[x, y] == 0)
                        {
                            //filled = false;
                            if (decide(x, y))
                                // if decide is true then this loop will execute
                            {
                                cluster[x, y] = 1;
                                //Thread.Sleep(1);
                                gg.FillEllipse(br, y * dx, x * dy, 5, 5);
                            }
                        }
                    }
                }
            }
        }
    
        // End of Growth Function
        public bool decide(int x, int y)
            // To decide ka koi nearest site occupied ha k nhi 
        {
            if(cluster[x - 1, y] == 1)
            {
                check = true;
                
            }
            else if (cluster[x + 1, y] == 1)
            {
                check = true;
                
            }
            else if (cluster[x, y - 1] == 1)
            {
                check = true;
                
            }
            else if (cluster[x, y + 1] == 1)
            {
                check = true;
                
            }
            else
            {
                check = false;
            }
            return check;
        }
    }
}
