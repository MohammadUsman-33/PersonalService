using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerDev.Models
{
    public class Memory 
    {
       
        
        public long totalSpace { get; set; }
        public long freeSpace { get; set; }
        public string driveName { get; set; }
        public string driveType { get; set; }
        public string rootDirectory { get; set; }
        public string volumeLabel { get; set; }
        public long totalFreeSpace { get; set; }
        public string driveFormat { get; set; }




    }
}
