using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0 || args[0] == "help")
            {
                Console.WriteLine(@"
  Usage : pm [command] [option]

     command :

         add : 将当前目录添加至path环境变量
      remove : 将当前目录从path环境变量去除
link|cmd|bat : 为exe文件创建cmd|bat至pm目录
        help : 输出帮助信息
");

                Magicdawn.ConsoleX.WriteLine("  PathManager BY Magicdawn",ConsoleColor.Cyan);
                return;
            }

            var command = args[0].ToLowerInvariant();
            switch(command)
            {
                case "add":
                    Command.Add.Process(args);
                    break;

                case "remove":
                    Command.Remove.Process(args);
                    break;

                //为exe创建bat文件
                case "link":
                case "bat":
                case "cmd":
                    Command.Link.Process(args);
                    break;

                default:
                    Magicdawn.ConsoleX.Warn("未识别命令...");
                    break;
            }


        }
    }
}
