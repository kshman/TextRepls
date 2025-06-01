using System.Text;

namespace DuRepls;

internal class WorkRepls(string replFilename, string listFilename)
{
    private Dictionary<string, string> _rpls = new Dictionary<string, string>();
    public List<string> _files = new List<string>();

    // 파일이 있나 검사
    public string? TestInputs()
    {
        if (!File.Exists(replFilename))
            return "Repls file not found: " + replFilename;
        if (!File.Exists(listFilename))
            return "File list not found: " + listFilename;
        return null;
    }
    
    // 파일 읽기
    public string? ReadInputs()
    {
        try
        {
            var l = LineDb.FromFile(replFilename);
            _rpls = l.ToDictionary();
            if (_rpls.Count == 0)
                return "No repls in repls file: " + replFilename;
        }
        catch(Exception e) 
        {
            return "Error reading repls file: " + e.Message;
        }
        
        try
        {
            var fs = File.ReadAllLines(listFilename, Encoding.UTF8);
            foreach (var f in fs)
            {
                var s = f.Trim();
                if (string.IsNullOrWhiteSpace(s))
                    continue;
                if (s[0] == '#' || s.StartsWith("//"))
                    continue;
                _files.Add(s);
            }
            if (_files.Count == 0)
                return "No files in file list: " + listFilename;
        }
        catch (Exception e)
        {
            return "Error reading file list: " + e.Message;
        }
        
        return null;
    }
    
    private string WorkContext(string ctx) => 
        _rpls.Aggregate(ctx, (current, kv) => current.Replace(kv.Key, kv.Value));

    public int Run()
    {
        var count = 0;
        foreach (var file in _files)
        {
            try
            {
                if (!File.Exists(file))
                    continue;
                
                var ctx = File.ReadAllText(file, Encoding.UTF8);
                var txt = WorkContext(ctx);
                if (txt != ctx)
                {
                    File.WriteAllText(file, txt, Encoding.UTF8);
                    count++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error processing file {file}: {e.Message}");
            }
        }
        return count;
    }
}
