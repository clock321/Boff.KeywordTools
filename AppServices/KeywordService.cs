using Boff.KeywordTools.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Boff.KeywordTools.AppServices
{
    public interface IKeywordService
    {
        string ExtractKeyword(string Path, string Suffix, string Keyword, out string result);
    }
    public class KeywordService : IKeywordService
    {

        int foldercount = 0;
        int filecount = 0;
        public string ExtractKeyword(string Path, string Suffix, string Keyword, out string result)
        {

            StringBuilder stringBuilder = new StringBuilder();
            List<string> SuffixFiles = new List<string>();

            if (File.Exists(Path))
            {
                SuffixFiles.Add(Path);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(Path);
                if (!dir.Exists)
                {
                    result = $"操作失败,文件夹路径不存在";
                    return stringBuilder.ToString();
                }


                List<string> files = new List<string>();
                GetAllFiles(Path, ref files);
                Suffix.Split(',').ToList().ForEach(x => SuffixFiles.AddRange(files.Where(y => y.EndsWith(x)).ToList()));
            }
            List<string> KeywordList = new List<string>();
            foreach (var item in SuffixFiles)
            {
                //提取文件中所有包含Keyword的关键词
                string[] text = File.ReadAllLines(item);
                foreach (var line in text)
                {
                    if (line.Contains(Keyword))
                    {
                        string[] words = line.Split(' ');
                        foreach (var word in words)
                        {
                            if (word.Contains(Keyword))
                            {
                                KeywordList.Add(word);
                            }
                        }
                    }
                }
            }
            KeywordList = KeywordList.Distinct().ToList();
            KeywordList.ForEach(x => stringBuilder.AppendLine(x));
            result = "操作成功";
            return stringBuilder.ToString();
        }


        //递归提取path下所有文件
        private void GetAllFiles(string path, ref List<string> files)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                return;
            }
            DirectoryInfo[] subDirectories = dir.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                GetAllFiles(subDirectory.FullName, ref files);
            }
            FileInfo[] subFiles = dir.GetFiles();
            foreach (FileInfo subFile in subFiles)
            {
                files.Add(subFile.FullName);
            }
        }
        //递归提取path下所有文件夹
        private void GetAllDirectories(string path, ref List<string> directories)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                return;
            }
            DirectoryInfo[] subDirectories = dir.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                directories.Add(subDirectory.FullName);
                GetAllDirectories(subDirectory.FullName, ref directories);
            }
        }
    }
}

