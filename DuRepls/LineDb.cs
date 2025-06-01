using System.Collections;
using System.Text;

namespace DuRepls;

public class LineDb : IEnumerable<KeyValuePair<string, string>>, IEnumerator<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> _db = new Dictionary<string, string>();
    
    private LineDb()
    {
        // Private constructor to prevent instantiation without parameters
    }

    public static LineDb FromContext(string ctx)
    {
        var l = new LineDb();
        l.ParseLines(ctx);
        return l;
    }

    public static LineDb FromFile(string file)
    {
        var s = File.ReadAllText(file, Encoding.UTF8);
        return FromContext(s);
    }

    private void ParseLines(string ctx)
    {
        _db.Clear();

        var ss = ctx.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        foreach (var l in ss)
        {
            var div = l.IndexOf('〓');
            if (div <= 0)
                continue;

            var name = l[..div];

            if (name[0] == '#' || name.StartsWith("//"))
                continue;

            var value = l[(div + 1)..];

            _db.Add(name.Trim(), value.Trim());
        }
    }

    public string Get(string name)
    {
        return _db.GetValueOrDefault(name, name);
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _db.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _db.GetEnumerator();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public int Count => _db.Count;

    public KeyValuePair<string, string> Current => throw new NotImplementedException();

    object IEnumerator.Current => throw new NotImplementedException();

    public string this[string index] => Get(index);

    public Dictionary<string, string> CloneDb()
    {
        return new Dictionary<string, string>(_db);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
