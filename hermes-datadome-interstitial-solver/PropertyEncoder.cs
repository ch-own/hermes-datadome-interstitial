using System.Text;
using System.Text.Json;

namespace hermes_datadome_interstitial_solver
{
    internal class PayloadBuilder
    {
        private const long _X = 4046101435;
        private const string _r3n = "r3n";

        private long _date;
        private long _date2;
        private int _k;

        private readonly List<int> _kBytes = new();
        private readonly List<int[]> _keyBytes = new();
        private readonly List<int[]> _valueBytes = new();

        private string _cid;
        private string _hash;
        private int _seed;
        private int _r1;
        private int _r2;
        private int _F;
        private int _u;

        public PayloadBuilder(string cid, string hash)
        {
            _cid = cid;
            _hash = hash;
            _u = -1;
            _r1 = Random.Shared.Next(100, 1000);
            _r2 = Random.Shared.Next(100, 1000);
            _date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            _date2 = _date + (_r1 + _r2 * 2);
            _k = (int)(255 & _date);
            _seed = GetPayloadEncoderSeed();
            _F = (int)(_seed ^ _date2);
        }

        public string Build()
        {
            var r = new List<int>();
            for (int i = 0; i < _keyBytes.Count; i++)
            {
                var B = i == 0 ? 123 : 44;
                r.Add(B ^ _kBytes[2 * i]);
                r.AddRange(_keyBytes[i]);
                r.Add(58 ^ _kBytes[(2 * i) + 1]);
                r.AddRange(_valueBytes[i]);
            }

            var e = new List<int>();
            e.Add(44 ^ GetByte());
            e.AddRange(EncodeString(_r3n));
            e.Add(58 ^ GetByte());
            e.AddRange(EncodeString(255 & _seed));
            r.AddRange(e);
            r.Add(125 ^ GetByte());
            var L = new List<char>();
            for (int i = 0; i < r.Count;)
            {
                var R = (SafeXor(r, i++, _k) << 16) | (SafeXor(r, i++, _k) << 8) | SafeXor(r, i++, _k);
                L.Add((char)M((R >> 18) & 63));
                L.Add((char)M((R >> 12) & 63));
                L.Add((char)M((R >> 6) & 63));
                L.Add((char)M(63 & R));
            }
            var V = r.Count % 3;
            if (V != 0)
            {
                for (int i = 0; i < 3 - V; i++)
                    L.RemoveAt(L.Count - 1);
            }
            return string.Concat(L);
        }

        private static int SafeXor(List<int> l, int index, int kval)
        {
            if (index >= l.Count)
                return kval;
            return l[index] ^ kval;
        }

        private static int M(int j)
        {
            if (j > 37)
                return 59 + j;
            else if (j > 11)
                return 53 + j;
            else if (j > 1)
                return 46 + j;
            else
                return (50 * j) + 45;
        }

        public void AddPair(string key, object value)
        {
            _kBytes.Add(GetByte());
            _keyBytes.Add(EncodeString(key));
            _kBytes.Add(GetByte());
            _valueBytes.Add(EncodeString(value));
        }

        private int[] EncodeString(object str)
        {
            var s = JsonSerializer.Serialize(str);
            var e = Encoding.UTF8.GetBytes(s);
            var r = new int[e.Length];
            for (int i = 0; i < e.Length; i++)
                r[i] = e[i] ^ GetByte();
            return r;
        }

        private int GetByte()
        {
            unchecked
            {
                if (++_u > 2)
                {
                    _F ^= _F << 13;
                    _F ^= _F >> 17;
                    _F ^= _F << 5;
                    _u = 0;
                }
                var K = 16 - (8 * _u);
                int j = 0;
                for (int g = 3; g >= 0; g--)
                    j |= _k << (8 * g);
                return ((j ^ _F) >> K) & 255;
            }
        }

        private int GetPayloadEncoderSeed()
        {
            unchecked
            {
                int c = D(_cid) ^ (int)(_date + _r1 + 2 * _r2) ^ D(_hash);
                return (int)(c ^ _X);
            }
        }

        private static int D(string s)
        {
            int S = 0;
            for (int F = 0; F < s.Length; F++)
                S = ((S << 5) - S + s[F]) << 0;
            return S == 0 ? 1789537805 : S;
        }

        public static int EncodeSeed(string ddmSeed)
        {
            int r = 0;
            for (int i = 0; i < ddmSeed.Length; ++i)
                r += ddmSeed[i % 240];
            return r;
        }
    }
}
