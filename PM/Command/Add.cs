using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PM.Command
{

    public class Add
    {
        //添加当前目录至path
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
                Magicdawn.ConsoleX.Warn("{0} 目录已经在path环境变量里...",dir);
            }
            else
            {
                System.Environment.SetEnvironmentVariable("path",path + ";" + dir,
                    EnvironmentVariableTarget.Machine);
                Magicdawn.ConsoleX.Success("已成功将 {0} 添加到path环境变量",dir);
            }
        }
    }
}
