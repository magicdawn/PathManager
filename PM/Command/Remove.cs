using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Magicdawn;

namespace PM.Command
{
    public class Remove
    {
        public static void Process(string[] args)
        {
            string dir;
            if(args.Length > 1)
            {
                dir = args[1]; // addtopath xxx
                if(!Path.IsPathRooted(dir))
                {
                    //相对路径
                    dir = Path.Combine(System.Environment.CurrentDirectory,dir);
                }
            }
            else
            {
                dir = System.Environment.CurrentDirectory;
            }

            var path = System.Environment.GetEnvironmentVariable("path",EnvironmentVariableTarget.Machine);
            if(path.Contains(dir))
            {
                path = path.Replace(dir,"").Replace(";;",";").TrimEnd(';');
                System.Environment.SetEnvironmentVariable("path",path,EnvironmentVariableTarget.Machine);
                ConsoleX.Success("已成功将 {0} 从path环境变量去除",System.Environment.CurrentDirectory);
            }
            else
            {
                ConsoleX.Warn("当前目录不在path环境变量中...");
            }
        }
    }
}
