using System;

public class Entry
{
    static Prompts prompt1 = new Prompts();
    static DateTime theCurrentTime = DateTime.Now;
    static DateTime datePartOnly = theCurrentTime.Date;

    // 👇 función que devuelve un emoji según la hora del día
    private static string EmojiForNow()
    {
        int hour = DateTime.Now.Hour;
        if (hour < 12) return "🌅";     // mañana
        if (hour < 18) return "🌞";     // tarde
        return "🌙";                    // noche
    }

    public string _date { get; set; } = datePartOnly.ToString("MM/dd/yyyy");

    // 👇 se agrega el emoji al final del prompt
    public string _prompt { get; set; } = $"{prompt1.RandomizePrompt()} {EmojiForNow()}";

    public string _response { get; set; } = "";

    public override string ToString()
        => $"[{_date}] {_prompt}\n{_response} \n";

    public string ToLine() => $"{_date}|{_prompt}|{_response}";

    public static Entry FromLine(string line)
    {
        var parts = line.Split('|');
        if (parts.Length < 3) return new Entry();
        return new Entry
        {
            _date = parts[0],
            _prompt = parts[1],
            _response = parts[2]
        };
    }
}
