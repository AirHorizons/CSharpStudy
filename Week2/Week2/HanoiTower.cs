using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class HanoiTower
    {
        private readonly int maxDisks;
        public int[] Disks { get; private set; }
        private int height = 0;
        public int DiskCount // 디스크의 개수 세기
        {
            get
            {
                int n = 0;
                while (Disks[n] != 0) n++;
                return n;
            }
        }
        public bool Empty
        {
            get { return Disks[0] == 0; }
        }
        public HanoiTower(int maxDisks)
        {
            this.maxDisks = maxDisks;
            Disks = new int[maxDisks];
        }
        public void InsertAllDisks()
        {
            for (int i = maxDisks; i >= 1; i--) InsertDisk(i);
        }
        public void InsertDisk(int n)
        {
            Disks[height] = n;
            height += 1;
        }
        public int RemoveDisk()
        {
            height -= 1;
            int num = Disks[height];
            Disks[height] = 0;
            return num;        
        }
    }
}
