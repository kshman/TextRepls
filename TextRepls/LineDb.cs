﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRepls
{
	class LineDb : IEnumerable<KeyValuePair<string, string>>, IEnumerator<KeyValuePair<string, string>>
    {
        private Dictionary<string, string> _db = new Dictionary<string, string>();

        public LineDb(string ctx)
        {
            ParseLines(ctx);
        }

        public LineDb(string filename, Encoding enc)
        {
            string s = File.ReadAllText(filename, enc);
            ParseLines(s);
        }

        private void ParseLines(string ctx)
        {
            _db.Clear();

            var ss = ctx.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var l in ss)
            {
                var div = l.IndexOf('〓');
                if (div <= 0)
                    continue;

                var name = l.Substring(0, div);

                if (name[0] == '#' || name.StartsWith("//"))
                    continue;

                var value = l.Substring(div + 1);

                _db.Add(name.Trim(), value.Trim());
            }
        }

        public string Get(string name)
        {
            if (!_db.TryGetValue(name, out string value))
                return name;
            return value;
        }

        public bool Try(string name, out string value)
        {
            return _db.TryGetValue(name, out value);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _db.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _db.GetEnumerator();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public int Count { get { return _db.Count; } }

        public KeyValuePair<string, string> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public string this[string index]
        {
            get
            {
                return Get(index);
            }
        }

        public Dictionary<string, string> CloneDb()
		{
            return new Dictionary<string, string>(_db);
		}
    }
}
