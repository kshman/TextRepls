using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextRepls
{
    internal class WorkRepls
    {
        private Dictionary<string, string> _rpls = new Dictionary<string, string>();
        private List<string> _dests = new List<string>();

        public WorkRepls(string replFilename, string destFilename)
        {
            // 리플 읽기
            try
            {
                var l = new LineDb(replFilename, Encoding.UTF8);
                _rpls = l.CloneDb();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error reading repls from {replFilename}: {ex.Message}");
                throw;
            }

            // 목록 읽기
            try
            {
                var txt = File.ReadAllText(destFilename, Encoding.UTF8);
                var ss = txt.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var l in ss)
                {
                    var s = l.Trim();
                    if (s.Length > 0 && s[0] != '#')
                        _dests.Add(s);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error reading destinations from {destFilename}: {ex.Message}");
                throw;
            }
        }

        // 하나만 일해
        private string WorkWorkWork(string ctx) =>
            _rpls.Aggregate(ctx, (current, i) => current.Replace(i.Key, i.Value));

        // 바꾸자
        public int BatchRun()
        {
            if (_rpls.Count == 0)
            {
                Console.WriteLine("No replacements defined.");
                return 0;
            }
            if (_dests.Count == 0)
            {
                Console.WriteLine("No destinations to process.");
                return 0;
            }

            var count = 0;
            foreach (var dest in _dests)
            {
                try
                {
                    if (!File.Exists(dest))
                    {
                        Console.WriteLine($"File not found: {dest}");
                        continue;
                    }

                    var ctx = File.ReadAllText(dest, Encoding.UTF8);
                    var txt = WorkWorkWork(ctx);
                    if (txt == ctx) // 변경이 있을 때만 저장
                        continue;

                    File.WriteAllText(dest, txt, Encoding.UTF8);
                    count++;
                    Console.WriteLine($"Processed: {dest}");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Error processing {dest}: {ex.Message}");
                }
            }

            return count;
        }
    }
}
