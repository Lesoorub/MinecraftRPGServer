using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MineServer;

public struct Chat : ISerializable, IDeserializable
{
    public string text;
    public bool bold, italic, underlined, strikethrough, obfuscated;
    /// <summary>
    /// ColorNames
    /// </summary>
    public string color;
    public Chat[] extra;
    public string insertion;
    public _clickEvent clickEvent;
    public _hoverEvent hoverEvent;

    private static JsonSerializerSettings notNull = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore };

    public Chat(string text)
    {
        this.text = text;
        bold = italic = underlined = strikethrough = obfuscated = false;
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

    public static Chat ColoredText(string text)
    {
        var sp = text.Split('&');
        if (sp.Length == 1)
        {
            return new Chat(sp[0]);
        }
        var body = new Chat("");
        List<Chat> t = new List<Chat>();
        Chat last = new Chat(sp[0]);
        string colors = "0123456789abcdef";
        string modifers = "lnomkr";
        foreach (string s in sp)
        {
            if (string.IsNullOrEmpty(s)) continue;
            if (s.StartsWith("#"))
            {
                if (!last.Equals(default))
                    t.Add(last);
                last = new Chat(s.Substring(7));
                last.color = s.Substring(0, 7);
                continue;
            }
            if (modifers.Contains(s[0].ToString()) && !last.Equals(default))
            {
                switch (s[0])
                {
                    case 'l': last.bold = true;          break;
                    case 'n': last.underlined = true;    break;
                    case 'o': last.italic = true;        break;
                    case 'm': last.strikethrough = true; break;
                    case 'k': last.obfuscated = true;    break;
                    case 'r':
                        last.obfuscated = last.strikethrough = last.italic = last.underlined = last.bold = false;
                        break;
                }
                last.text += s.Substring(1);
            }
            if (colors.Contains(s[0].ToString()))
            {
                if (!last.Equals(default))
                    t.Add(last);
                last = new Chat("")
                {
                    color = ColorNameArray[ColorIndexesArray.IndexOf(s[0])]
                };
                last.text += s.Substring(1);
            }
        }
        if (!last.Equals(default))
            t.Add(last);
        body.extra = t.ToArray();
        return body;
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