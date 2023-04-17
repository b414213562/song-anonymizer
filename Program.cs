
Dictionary<string, int> songLookup = new Dictionary<string, int>
{
    ["01 - Duje (Eurovision 2023 - Albania).mp3"] = 4055,
    ["02 - Future lover (Eurovision 2023 - Armenia).mp3"] = 7596,
    ["03 - Who The Hell Is Edgar_ (Eurovision 2023 - Austria).mp3"] = 9467,
    ["04 - Promise (Eurovision 2023 - Australia).mp3"] = 4846,
    ["05 - Tell Me More (Eurovision 2023 - Azerbaijan).mp3"] = 2662,
    ["06 - Because Of You (Eurovision 2023 - Belgium).mp3"] = 1066,
    ["07 - Watergun (Eurovision 2023 - Switzerland).mp3"] = 3983,
    ["08 - Break a Broken Heart (Eurovision 2023 - Cyprus).mp3"] = 5424,
    ["09 - My Sister's Crown (Eurovision 2023 - Czech Republic).mp3"] = 7335,
    ["10 - Blood & Glitter (Eurovision 2023 - Germany).mp3"] = 9179,
    ["11 - Breaking My Heart (Eurovision 2023 - Denmark).mp3"] = 7977,
    ["12 - Bridges (Eurovision 2023 - Estonia).mp3"] = 3132,
    ["13 - Eaea (Eurovision 2023 - Spain).mp3"] = 4852,
    ["14 - Cha Cha Cha (Eurovision 2023 - Finland).mp3"] = 3409,
    ["15 - Évidemment (Eurovision 2023 - France).mp3"] = 6379,
    ["16 - I Wrote A Song (Eurovision 2023 - United Kingdom).mp3"] = 3314,
    ["17 - Echo (Eurovision 2023 - Georgia).mp3"] = 7793,
    ["18 - What Τhey Say (Eurovision 2023 - Greece).mp3"] = 9374,
    ["19 - Mama ŠČ! (Eurovision 2023 - Croatia).mp3"] = 7214,
    ["20 - We Are One (Eurovision 2023 - Ireland).mp3"] = 4226,
    ["21 - Unicorn (Eurovision 2023 - Israel).mp3"] = 2736,
    ["22 - Power (Eurovision 2023 - Iceland).mp3"] = 3476,
    ["23 - Due Vite (Eurovision 2023 - Italy).mp3"] = 2205,
    ["24 - Stay (Eurovision 2023 - Lithuania).mp3"] = 9639,
    ["25 - Aijā (Eurovision 2023 - Latvia).mp3"] = 7656,
    ["26 - Soarele și Luna (Eurovision 2023 - Moldova).mp3"] = 9124,
    ["27 - Dance (Our Own Party) (Eurovision 2023 - Malta).mp3"] = 4306,
    ["28 - Burning Daylight (Eurovision 2023 - Netherlands).mp3"] = 1994,
    ["29 - Queen of Kings (Eurovision 2023 - Norway).mp3"] = 2950,
    ["30 - Solo (Eurovision 2023 - Poland).mp3"] = 6349,
    ["31 - Ai Coração (Eurovision 2023 - Portugal).mp3"] = 9580,
    ["32 - D.G.T. (Off and on) (Eurovision 2023 - Romania).mp3"] = 4471,
    ["33 - Samo Mi Se Spava (Eurovision 2023 - Serbia).mp3"] = 6667,
    ["34 - Tattoo (Eurovision 2023 - Sweden).mp3"] = 9189,
    ["35 - Carpe Diem (Eurovision 2023 - Slovenia).mp3"] = 6827,
    ["36 - Like an Animal (Eurovision 2023 - San Marino).mp3"] = 1649,
    ["37 - Heart of Steel (Eurovision 2023 - Ukraine).mp3"] = 6830,
};

var songDirectory = @"C:\Users\bkckx\Downloads\Eurovision Song Contest Liverpool 2023";

// Get all MP3 files in the directory
var mp3Files = Directory.GetFiles(songDirectory, "*.mp3");

// foreach .mp3 file in the directory
// Remove metadata from each MP3 file
foreach (string mp3FileName in mp3Files)
{
    try
    {
        // Load the file and remove its metadata
        TagLib.File file = TagLib.File.Create(mp3FileName);
        file.RemoveTags(TagLib.TagTypes.AllTags);
        file.Save();

        Console.WriteLine("Metadata removed from: " + mp3FileName);

        var mp3BaseName = Path.GetFileName(mp3FileName);

        if (songLookup.ContainsKey(mp3BaseName))
        {
            var newName = Path.Combine(songDirectory, (songLookup[mp3BaseName].ToString() + ".mp3"));
            File.Move(mp3FileName, newName);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error removing metadata from " + mp3FileName + ": " + ex.Message);
    }
}


