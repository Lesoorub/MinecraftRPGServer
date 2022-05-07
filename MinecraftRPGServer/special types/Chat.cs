using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MineServer;
using System.Globalization;

public struct Chat : ISerializable, IDeserializable
{
    public string text;
    public bool? bold, italic, underlined, strikethrough, obfuscated;
    /// <summary>
    /// ColorNames
    /// </summary>
    public string color;
    public Chat[] extra;
    public string insertion;
    public _clickEvent clickEvent;
    public _hoverEvent hoverEvent;

    private static JsonSerializerSettings notNull = new JsonSerializerSettings() 
    { 
        DefaultValueHandling = DefaultValueHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
    };

    public Chat(string text)
    {
        this.text = text;
        bold = italic = underlined = strikethrough = obfuscated = null;
        color = ColorNames.gray;
        extra = null;
        insertion = null;
        clickEvent = null;
        hoverEvent = null;
    }

    public JToken GetJToken()
    {
        return JToken.FromObject(this);
    }
    public override string ToString()
    {
        if (extra != null && extra.Length == 0)
            extra = null;
        return JsonConvert.SerializeObject(this, Formatting.None, notNull);
    }

    public static string Gradient(string text, int start_color, int end_color)
    {
        string ToColor(byte r, byte g, byte b) => 
            r.ToString("X").PadLeft(2, '0') + 
            g.ToString("X").PadLeft(2, '0') + 
            b.ToString("X").PadLeft(2, '0');
        void FromColor(int color, out byte r, out byte g, out byte b)
        {
            r = (byte)((color >> 16) & 0xFF);
            g = (byte)((color >> 8) & 0xFF);
            b = (byte)(color & 0xFF);
        }
        StringBuilder strb = new StringBuilder();
        float lerp(float a, float b, float t) => a + (b - a) * t;
        FromColor(start_color, out var sr, out var sg, out var sb);
        FromColor(end_color, out var er, out var eg, out var eb);
        for (int k = 0; k < text.Length; k++)
        {
            float t = (float)k / text.Length;
            strb.Append($"&#{ToColor((byte)lerp(sr, er, t), (byte)lerp(sg, eg, t), (byte)lerp(sb, eb, t))}{text[k]}");
        }
        return strb.ToString();
    }
    public static Chat ColoredText(string text)
    {
        string pattern = "&grad(######,######)";//# - skip char

        int[] findGrads()
        {
            List<int> results = new List<int>();

            for (int k = 0; k < text.Length - pattern.Length; k++)
            {
                int i;
                for (i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] == '#')
                        continue;
                    if (text[k + i] != pattern[i])
                        break;
                }
                if (i == pattern.Length)
                    results.Add(k);
            }

            return results.ToArray();
        }

        var grads = findGrads();
        if (grads.Length > 0)
        {
            for (int k = grads.Length - 1; k >= 0; k--)
            { 
                int gradIndex = grads[k];
                string a = text.Substring(gradIndex + 6, 6);
                string b = text.Substring(gradIndex + 13, 6);
                if (!int.TryParse(a, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int gradStartColor) ||
                    !int.TryParse(b, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int gradEndColor))
                    continue;
                int gradTextIndex = gradIndex + pattern.Length;
                string s = text.Substring(
                    gradTextIndex,
                    text.IndexOf('&', gradTextIndex) != -1 
                    ? text.IndexOf('&', gradTextIndex) - gradTextIndex
                    : text.Length - gradTextIndex);
                text = text
                    .Remove(gradIndex, pattern.Length + s.Length)
                    .Insert(gradIndex, Gradient(s, gradStartColor, gradEndColor));
            }
        }

        var spl = text.Split('&');
        if (spl.Length == 1)
            return new Chat(text);

        List<Chat> list = new List<Chat>();

        bool? bold, italic, underlined, strikethrough, obfuscated;
        bold = italic = underlined = strikethrough = obfuscated = null;
        string str = spl[0];

        const string colors = "0123456789abcdef";
        const string modifers = "lnomkr";
        int index = 0;
        foreach (var s in spl)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (index != 0 && index != spl.Length - 1)
                    str += "&";
                continue;
            }
            index++;
            if (s.StartsWith("#"))
            {
                list.Add(new Chat(str + s.Substring(7))
                {
                    color = s.Substring(0, 7),
                    bold = bold,
                    italic = italic,
                    underlined = underlined,
                    strikethrough = strikethrough,
                    obfuscated = obfuscated,
                });
                str = string.Empty;
                continue;
            }
            if (modifers.Contains(s[0].ToString()))
            {
                switch (s[0])
                {
                    case 'l': bold = true; break;
                    case 'n': underlined = true; break;
                    case 'o': italic = true; break;
                    case 'm': strikethrough = true; break;
                    case 'k': obfuscated = true; break;
                    case 'r':
                        obfuscated = strikethrough = italic = underlined = bold = false;
                        break;
                }
                str += s.Substring(1);
                continue;
            }
            if (colors.Contains(s[0].ToString()))
            {
                list.Add(new Chat(str + s.Substring(1))
                {
                    color = ColorNameArray[ColorIndexesArray.IndexOf(s[0])],
                    bold = bold,
                    italic = italic,
                    underlined = underlined,
                    strikethrough = strikethrough,
                    obfuscated = obfuscated,
                });
                str = string.Empty;
                continue;
            }
        }
        return new Chat()
        {
            text = "",
            extra = list.ToArray(),
        };
    }
    public byte[] ToByteArray()
    {
        var writer = new ArrayWriter(true);
        writer.Write(ToString());
        return writer.ToArray();
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        var reader = new ArrayReader(bytes, offset, true);
        JsonConvert.PopulateObject(reader.Read<string>(), this);
        length = reader.offset - offset;
    }

    public sealed class _clickEvent
    {
        public string action;
        public JToken value;

        public const string open_url = "open_url";
        public const string run_command = "run_command";//Выполняет данную команду. Не обязательно быть командой - щелчок по этой кнопке только заставляет клиента отправлять заданный контент в виде сообщения чата, поэтому, если он не имеет префикса /, вместо этого он произнесет заданный текст. Если используется в графическом интерфейсе книги, графический интерфейс закрывается после нажатия
        public const string suggest_command = "suggest_command";//Можно использовать только для сообщений в чате. Заменяет содержимое окна чата заданным текстом - обычно это команда, но не обязательно, чтобы это была команда (команды должны начинаться с префикса /).
        public const string change_page = "change_page";
        public const string copy_to_clipboard = "copy_to_clipboard";

        public static _clickEvent ChangePage(int page) =>
            new _clickEvent() { action = change_page, value = page };
    }
    public sealed class _hoverEvent
    {
        public string action;
        public JToken value;

        public const string show_text = "show_text";
        public const string show_item = "show_item";
        public const string show_entity = "show_entity";
        public static _hoverEvent ShowText(string text) =>
            new _hoverEvent() { action = show_text, value = text };
        public static _hoverEvent ShowText(Chat text) =>
            new _hoverEvent() { action = show_text, value = text.GetJToken() };
        public static _hoverEvent ShowEntity(Guid id, string name, string type = null) =>
            new _hoverEvent() { action = show_entity, value = JToken.FromObject(new entity(id, type, name)) };

        public class entity
        {
            public Guid id;
            public string type;
            public string name = "";

            public entity(Guid id, string type, string name)
            {
                this.id = id;
                this.type = type;
                this.name = name;
            }
        }
    }
    public readonly struct ColorNames
    {
        public const string black = "black";
        public const string dark_blue = "dark_blue";
        public const string dark_green = "dark_green";
        public const string dark_aqua = "dark_aqua";
        public const string dark_red = "dark_red";
        public const string dark_purple = "dark_purple";
        public const string gold = "gold";
        public const string gray = "gray";
        public const string dark_gray = "dark_gray";
        public const string blue = "blue";
        public const string green = "green";
        public const string aqua = "aqua";
        public const string red = "red";
        public const string light_purple = "light_purple";
        public const string yellow = "yellow";
        public const string white = "white";
        public const string obfuscated = "obfuscated";
        public const string bold = "bold";
        public const string strikethrough = "strikethrough";
        public const string underline = "underline";
        public const string italic = "italic";
        public const string reset = "reset";

    }
    public const string ColorIndexesArray = "0123456789abcdefklmnor";
    public static readonly string[] ColorNameArray = Enum.GetNames(typeof(ColorName));
    public enum ColorName : byte
    {
        black, dark_blue, dark_green, dark_aqua, dark_red, dark_purple,
        gold, gray, dark_gray, blue, green, aqua,
        red, light_purple, yellow, white, obfuscated, bold,
        strikethrough, underline, italic, reset
    }
    public readonly struct ColorIndexes
    {
        public const char black =         '0';
        public const char dark_blue =     '1';
        public const char dark_green =    '2';
        public const char dark_aqua =     '3';
        public const char dark_red =      '4';
        public const char dark_purple =   '5';
        public const char gold =          '6';
        public const char gray =          '7';
        public const char dark_gray =     '8';
        public const char blue =          '9';
        public const char green =         'a';
        public const char aqua =          'b';
        public const char red =           'c';
        public const char light_purple =  'd';
        public const char yellow =        'e';
        public const char white =         'f';
        public const char obfuscated =    'k';
        public const char bold =          'l';
        public const char strikethrough = 'm';
        public const char underline =     'n';
        public const char italic =        'o';
        public const char reset =         'r';
    }
}