using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magicdawn;
using System.IO;

namespace PM.Command
{
    public class Link //alias bat
    {
        public static void Process(string[] args)
        {
            string exe = "";

            if(args.Length > 1) //pm [bat a.exe]
            {
                exe = args[1];
            }
            else
            {
                var exes = System.IO.Directory.GetFiles(System.Environment.CurrentDirectory,"*.exe");
                if(exes.Length < 1)
                {
                    ConsoleX.Error("没有exe文件...");
                    return;
                }
                else if(exes.Length > 1)
                {
                    ConsoleX.Warn("exe文件超过两个,取第一个...");
                }

                if(!string.IsNullOrWhiteSpace(exes[0]))
                {
                    exe = exes[0];
                }
            }

            exe = Path.Combine(System.Environment.CurrentDirectory,exe);


            var name = System.IO.Path.GetFileNameWithoutExtension(exe);
            var content = String.Format("@\"{0}\" %*",exe);

            var ext = ".cmd";
            if(args[0] == "bat") ext = ".bat";
            var dest = AppDomain.CurrentDomain.BaseDirectory + name + ext;

            System.IO.File.WriteAllText(dest,content);
            Console.WriteLine("已为{0}.exe创建.cmd文件:{1}",name,dest);
        }
    }
}
