using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerDev.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerDev.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MemoryController : Controller
    {
        //private IHttpContextAccessor _accessor;
        // GET: api/<controller>
        [HttpGet]
        public List<Memory> GetMemory()
        {

            List<Memory> memories = new List<Memory>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                Memory mem = new Memory();
                if (d.IsReady)
                {
                    if (d.RootDirectory.ToString() != "C:\\")
                    {
                        mem.driveName = d.Name;
                        mem.driveType = d.DriveType.ToString();
                        mem.totalSpace = ((d.TotalSize / 1073741824));
                        mem.freeSpace = (d.AvailableFreeSpace / 1073741824);
                        mem.driveFormat = d.DriveFormat.ToString();
                        mem.rootDirectory = d.RootDirectory.ToString();
                        mem.volumeLabel = d.VolumeLabel.ToString();
                        mem.totalFreeSpace = (d.TotalFreeSpace / 1073741824);
                        memories.Add(mem);
                    }

                }
                
            }

            return memories;

        }
        [HttpGet]
        public double getAvailableMemory()
        {
            double freeSpace = 0;

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {

                Memory mem = new Memory();
                if (d.IsReady && (!d.RootDirectory.FullName.ToString().Equals("C:\\") || d.DriveType.Equals(DriveType.CDRom)))
                {
                    mem.freeSpace = (d.AvailableFreeSpace / 1073741824);
                    freeSpace += mem.freeSpace;
                }

            }
            return freeSpace;
        }
        // GET api/<controller>/5
        [HttpGet]
        public double getTotalMemory()
        {
            double totalSpace = 0;

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                Memory mem = new Memory();
                if (d.IsReady && (d.DriveType != DriveType.Removable))
                {
                    mem.totalSpace = ((d.TotalSize / 1073741824));


                }
                totalSpace += mem.totalSpace;

            }
            return totalSpace;
        }
        [HttpPost]
        public void CreateFun(string b)
        {
            switch (b)
            {
                case "cd":
                    string path = "D:\\";
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    break;
                case "cf":
                    break;
                case "":
                    break;

                default:
                    break;
            }

        }

        [HttpGet]
        public string GetIntenetInfo() {
            { 
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
            }
           
        }
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        //    return HttpContext.Connection.RemoteIpAddress.ToString(); 
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
